using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totally_Recoded_Minicraft.level;
using Totally_Recoded_Minicraft.level.tile;
using MiniCraftOnline;

namespace Totally_Recoded_Minicraft.levelgen
{
    class LevelGen
    {
      //  public static  Random random = new Random((int)((unchecked(DateTime.Now.Ticks.GetHashCode()))));
        public static Random random ;
        public double[] values;
        private int w, h;

		public LevelGen(int w, int h, int featureSize,Random randoms)
        {
            this.w = w;
            this.h = h;
			random = randoms;
            //values = new double[w * h];
            values = new double[w * h];
            for (int y = 0; y < w; y += featureSize)
            {
                for (int x = 0; x < w; x += featureSize)
                {
                    setSample(x, y, random.NextDouble() * 2 - 1); 
                }
            }

            int stepSize = featureSize;
            double scale = 1.0 / w;
            double scaleMod = 1;
            do
            {
                int halfStep = stepSize / 2;
                for (int y = 0; y < w; y += stepSize)
                {
                    for (int x = 0; x < w; x += stepSize)
                    {
                        double a = sample(x, y);
                        double b = sample(x + stepSize, y);
                        double c = sample(x, y + stepSize);
                        double d = sample(x + stepSize, y + stepSize);

                        double e = (a + b + c + d) / 4.0 + (random.NextDouble() * 2 - 1) * stepSize * scale;
                        setSample(x + halfStep, y + halfStep, e);
                    }
                }
                for (int y = 0; y < w; y += stepSize)
                {
                    for (int x = 0; x < w; x += stepSize)
                    {
                        double a = sample(x, y);
                        double b = sample(x + stepSize, y);
                        double c = sample(x, y + stepSize);
                        double d = sample(x + halfStep, y + halfStep);
                        double e = sample(x + halfStep, y - halfStep);
                        double f = sample(x - halfStep, y + halfStep);

                        double H = (a + b + d + e) / 4.0 + (random.NextDouble() * 2 - 1) * stepSize * scale * 0.5;
                        double g = (a + c + d + f) / 4.0 + (random.NextDouble() * 2 - 1) * stepSize * scale * 0.5;
                        setSample(x + halfStep, y, H);
                        setSample(x, y + halfStep, g);
                    }
                }
                stepSize /= 2;
                scale *= (scaleMod + 0.8);
                scaleMod *= 0.3;
            } while (stepSize > 1);
        }
        private double sample(int x, int y)
        {
         return values[(x & (w - 1)) + (y & (h - 1)) * w];
        }
        private void setSample(int x, int y, double value)
        {
            values[(x & (w - 1)) + (y & (h - 1)) * w] = value;
        }
        public static int stringTonum(string str)
        {
			int num=0;
			List<int> ints = new List<int> ();
			foreach (char t in str) {
				ints.Add (t- '0');
			}
			foreach (int i in ints) {
				num += i;
			}
			Console.WriteLine (str.GetHashCode());
			Console.WriteLine ("Tick : " + Environment.TickCount);
		//	return str.GetHashCode();
		//	return  Environment.TickCount;
			return str.GetHashCode();
        }
        public static List<Tile> createAndValidateTopMap(int w, int h,string seed)
        {
			random = new Random(stringTonum(seed));
            int attempt = 0;
                  do
                 {

            List<Tile> result = createTopMap(w, h,seed);
            int numGrass=0;
            int numSand=0;
				int numRock=0;
   foreach(Tile t in result)
   {
       if (t.GetType() == typeof(GrassTile))
       {
           numGrass++;
       }
       else   if (t.GetType() == typeof(SandTile))
       {
           numSand++;
       }
				/*	else   if (t.GetType() == typeof(RockTile))
					{
						numRock++;
					}*/
   }
//if (numRock < 100) continue;
 if (numGrass < 100) continue;
 if (numSand < 100) continue;
            return result;

               } while (true);
        }

        private static List<Tile> createTopMap(int w, int h,string seed)
        {
            //     byte[] map = new byte[w * h];
                List<Tile> data = new List<Tile>();
			LevelGen mnoise1 = new LevelGen(w, h, 16,random);
			LevelGen mnoise2 = new LevelGen(w, h, 16, random);
                LevelGen mnoise3 = new LevelGen(w, h, 16, random);

                LevelGen noise1 = new LevelGen(w, h, 32, random);
                LevelGen noise2 = new LevelGen(w, h, 32,random);

            //    byte[] map = new byte[w * h];
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        int i = x + y * w;

                        double val = Math.Abs(noise1.values[i] - noise2.values[i]) * 3 - 2;
                        double mval = Math.Abs(mnoise1.values[i] - mnoise2.values[i]);
                        mval = Math.Abs(mval - mnoise3.values[i]) * 3 - 2;

                        double xd = x / (w - 1.0) * 2 - 1;
                        double yd = y / (h - 1.0) * 2 - 1;
                        if (xd < 0) xd = -xd;
                        if (yd < 0) yd = -yd;
                        double dist = xd >= yd ? xd : yd;
                        dist = dist * dist * dist * dist;
                        dist = dist * dist * dist * dist;
                        val = val + 1 - dist * 20;

                        if (val < -0.5)
                        {
                            data.Add(new WaterTile(new Vector2(x*16,y*16)));
                        }
                        else if (val > 0.5 && mval < -1.5)
                        {
						data.Add(new RockTile(new Vector2(x * 16, y * 16)));
                        }
                        else
                        {

                            data.Add(new GrassTile(new Vector2(x * 16, y * 16)));
                        }
                    }
                }
                for (int i = 0; i < w * h / 2800; i++)
                {
                    int xs = random.Next(w);
                    int ys = random.Next(h);
                    for (int k = 0; k < 10; k++)
                    {
                        int x = xs + random.Next(21) - 10;
                        int y = ys + random.Next(21) - 10;
                        for (int j = 0; j < 100; j++)
                        {
                            int xo = x +  random.Next(5) -  random.Next(5);
                            int yo = y +  random.Next(5) -  random.Next(5);
                            for (int yy = yo - 1; yy <= yo + 1; yy++)
                                for (int xx = xo - 1; xx <= xo + 1; xx++)
                                    if (xx >= 0 && yy >= 0 && xx < w && yy < h)
                                    {
                                        if (data[xx + yy * w].GetType() == typeof(GrassTile))
                                        {
                                            data[xx + yy * w] = new SandTile(data[xx + yy * w].position);
                                        }
                                    }
                        }
                    }
                }
                for (int i = 0; i < w * h / 400; i++)
                {
                    int x = random.Next(w);
                    int y = random.Next(h);
                    for (int j = 0; j < 200; j++)
                    {
                        int xx = x + random.Next(15) - random.Next(15);
                        int yy = y + random.Next(15) - random.Next(15);
                        if (xx >= 0 && yy >= 0 && xx < w && yy < h)
                        {
                            if (data[xx + yy * w].GetType() == typeof(GrassTile))
                            {
                            data[xx + yy * w] = new TreeTile(data[xx + yy * w].position);
                            }
                        }
                    }
                }
                for (int i = 0; i < w * h / 400; i++)
                {
                    int x = random.Next(w);
                    int y = random.Next(h);
                    int col = random.Next(4); 
                    for (int j = 0; j < 30; j++)
                    {
                        int xx = x + random.Next(5) - random.Next(5);
                        int yy = y + random.Next(5) - random.Next(5);
                        if (xx >= 0 && yy >= 0 && xx < w && yy < h)
                        {
                            if (data[xx + yy * w].GetType() == typeof(GrassTile))
                            {
                                data[xx + yy * w] = new FlowerTile(data[xx + yy * w].position, (byte)(col + random.Next(4) * 16));
                              //  data[xx + yy * w] = (byte)(col + random.nextInt(4) * 16);
                            }
                        }
                    }
                }
				for (int i = 0; i < w * h / 100; i++) {
				int xx = random.Next(w);
				int yy = random.Next(h);
				if (xx >= 0 && yy >= 0 && xx < w && yy < h) {
					if (data[xx + yy * w].GetType() == typeof(SandTile)) {
						data[xx + yy * w] = new CactusTile(data[xx + yy * w].position);
					}
				}
				}

                  return data;





        }
        public static int positive(int num)
        {
        if(num <0)
        return -num;
        else return num;
        }

    }
}
