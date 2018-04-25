using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Globalization;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Management;
using System.Runtime.InteropServices;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {


        private double[,] parMultiple(double[,] A, double[,] B)
        {
            int mA = A.GetLength(0);
            int mB = B.GetLength(0);
            int nB = B.GetLength(1);

            double[,] C = new double[mA, nB];

            Parallel.For(0, mA, new ParallelOptions { MaxDegreeOfParallelism = 6 }, i =>
            {
                for (int j = 0; j < nB; j++)
                {
                    C[i, j] = 0;
                    for (int k = 0; k < mB; k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            });

            return C;
        }

        private void saveMatrixToFile(double[,] parC, int Cm, int Cn, string filepath)
        {
            FileStream fs = File.Create(filepath);
            fs.Close();

            using (TextWriter tw = new StreamWriter(filepath))
            {
                for (int i = 0; i < Cm; i++)
                {
                    if (i != 0)
                        tw.WriteLine();

                    for (int j = 0; j < Cn; j++)
                    {
                        if (j != 0)
                        {
                            tw.Write(" ");
                        }
                        tw.Write(parC[i, j]);

                    }

                }
            }
        }

        private void saveMatrixToFile(string A, int Am, int An, string filepath)
        {
            FileStream fs = File.Create(filepath);
            fs.Close();

            string[] rows = A.Split('\n');


            using (TextWriter tw = new StreamWriter(filepath))
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i] = rows[i].Trim();

                    string[] values = rows[i].Split(' ');

                    if (i != 0)
                        tw.WriteLine();

                    for (int j = 0; j < values.Length; j++)
                    {
                        if (j != 0)
                        {
                            tw.Write(" ");
                        }
                        tw.Write(values[j]);
                    }
                }
            }
        }

        private double[,] readMatrix(string X, int m, int n)
        {
            double[,] Y = new double[m, n];
            string[] rows = X.Split('\n');

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i] = rows[i].Trim();
                Debug.WriteLine(rows[i]);
                string[] values = rows[i].Split(' ');
                for (int j = 0; j < values.Length; j++)
                {
                    Y[i, j] = double.Parse(values[j], CultureInfo.InvariantCulture);

                }
            }

            return Y;
        }

        [WebMethod]
        public string SendMatrix(string A)
        {
            A = A.TrimEnd(Environment.NewLine.ToCharArray());

            int Am = Regex.Matches(A, "\n").Count + 1;

            int An;
            if (Am > 1)
            {
                An = Regex.Matches(A.Substring(0, A.IndexOf("\n")), " ").Count + 1;
            }
            else
            {
                An = Regex.Matches(A, " ").Count + 1;
            }

            string filename = string.Format("{0}.txt", Guid.NewGuid());
            string filepath = Server.MapPath("~/files/uploads/" + filename);

            saveMatrixToFile(A, Am, An, filepath);

            return filename.Substring(0, filename.IndexOf(".txt"));
        }

        [WebMethod]
        public string MultipleMatrix(string idA, string idB)
        {
            string pathA = Server.MapPath("~/files/uploads/" + idA + ".txt");
            string pathB = Server.MapPath("~/files/uploads/" + idB + ".txt");

            string stringA = File.ReadAllText(pathA);
            string stringB = File.ReadAllText(pathB);

            stringA = stringA.TrimEnd(Environment.NewLine.ToCharArray());
            stringB = stringB.TrimEnd(Environment.NewLine.ToCharArray());

            /* Checking A dimensions */
            int Am = Regex.Matches(stringA, "\n").Count + 1;
            int An;
            if (Am > 1)
            {
                An = Regex.Matches(stringA.Substring(0, stringA.IndexOf("\n")), " ").Count + 1;
            }
            else
            {
                An = Regex.Matches(stringA, " ").Count + 1;
            }
            /* Checking B dimensions */
            int Bm = Regex.Matches(stringB, "\n").Count + 1;
            int Bn;
            if (Bm > 1)
            {
                Bn = Regex.Matches(stringB.Substring(0, stringB.IndexOf("\n")), " ").Count + 1;
            }
            else
            {
                Bn = Regex.Matches(stringB, " ").Count + 1;
            }

            if (An == Bm)
            {
                double[,] mxA = readMatrix(stringA, Am, An);
                double[,] mxB = readMatrix(stringB, Bm, Bn);

                double[,] mxC = parMultiple(mxA, mxB);

                string filename = string.Format("{0}.txt", Guid.NewGuid());
                string filepath = Server.MapPath("~/files/computed/" + filename);

                int Cm = Am;
                int Cn = Bn;

                saveMatrixToFile(mxC, Cm, Cn, filepath);

                File.Delete(pathA);
                File.Delete(pathB);

                return filename.Substring(0, filename.IndexOf(".txt"));
            }
            else
            {
                return "error";
            }
        }
        [WebMethod]
        public byte[] GetMatrix(string id)
        {
            string pathA = Server.MapPath("~/files/computed/" + id + ".txt");

            byte[] _Buffer = null;

            try
            {
                System.IO.FileStream _FileStream = new System.IO.FileStream(pathA, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(_FileStream);
                long _TotalBytes = new System.IO.FileInfo(pathA).Length;
                _Buffer = _BinaryReader.ReadBytes((Int32)_TotalBytes);
                _FileStream.Close();
                _FileStream.Dispose();
                _BinaryReader.Close();
            }
            catch (Exception _Exception)
            {
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }

            File.Delete(pathA);

            return _Buffer;
        }


        /* =============================== MANDELBROT =============================== */

        [WebMethod]
        public string GenerateMandelbrot(int width, int height, int numThreadsPar, string coloring)
        {
            double rMin = -2.5;
            double rMax = 1.0;
            double iMin = -1.0;
            double iMax = 1.0;
            int iter = 3000;


            List<Color> colors = new List<Color>();
            System.Array colorsSystem = Enum.GetValues(typeof(KnownColor));
            int iteration = 0;
            foreach (KnownColor knowColor in colorsSystem)
            {
                if (iteration > 50) {
                    Color color = Color.FromKnownColor(knowColor);
                    colors.Add(color);
                }
                iteration++;
            }

            Pixel[,] fractal = Fractal.GenerateMandelbrot(width, height, rMin, rMax, iMin, iMax, iter, colors, numThreadsPar, coloring);

            string filename = string.Format("{0}.bmp", Guid.NewGuid());
            string filepath = Server.MapPath("~/files/fractals/" + filename);

            int widthImg = fractal.GetLength(0);
            int heightImg = fractal.GetLength(1);

            Bitmap Image = new Bitmap(widthImg, heightImg);

            for (int i = 0; i < widthImg; i++)
                for (int j = 0; j < heightImg; j++)
                {
                    Pixel pixel = fractal[i, j];
                    Image.SetPixel(i, j, pixel.color);
                }

            Image.Save(filepath);

            return filename.Substring(0, filename.IndexOf(".bmp"));
        }

        [WebMethod]
        public byte[] GetMandelbrot(string id)
        {
            string path = Server.MapPath("~/files/fractals/" + id + ".bmp");

            byte[] _Buffer = null;

            try
            {
                System.IO.FileStream _FileStream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(_FileStream);
                long _TotalBytes = new System.IO.FileInfo(path).Length;
                _Buffer = _BinaryReader.ReadBytes((Int32)_TotalBytes);
                _FileStream.Close();
                _FileStream.Dispose();
                _BinaryReader.Close();
            }
            catch (Exception _Exception)
            {
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }

            File.Delete(path);

            return _Buffer;
        }

    }


    public class Pixel {
        public Color color;

        public Pixel()
        {
        }
        public Pixel(int r, int g, int b)
        {
            this.color = System.Drawing.Color.FromArgb(r, g, b);
        }

        public void FromColor(Color c)
        {
            this.color = c;
        }
    }


    public class Fractal
    {
        [DllImport("kernel32.dll")]
        static extern int GetCurrentProcessorNumber();
        public static Pixel[,] GenerateMandelbrot(int width, int height, double realMin, double realMax, double imagMin,
                                            double imagMax, int iterations, List<Color> colorSet, int numThreadsPar, string coloring = "cores", bool runParallel = true)
        {
            // info on mandelbrot and fractals
            // https://classes.yale.edu/fractals/MandelSet/welcome.html
            Pixel[,] image = new Pixel[width, height];

            // scale for cartesian -> complex translation
            double realScale = (realMax - realMin) / width;
            double imagScale = (imagMax - imagMin) / height;

            if (runParallel)
            {

                // Parallel Version
                Parallel.For(0, width, new ParallelOptions { MaxDegreeOfParallelism = numThreadsPar },
                (xPixel) =>
                {
                    for (int yPixel = 0; yPixel < height; yPixel++)
                    {
                // complex plane is similar to cartesian, 
                // so translation just requires scaling and an offset
                // (x, y) => (real, imag) = (realScale * x + realMin, imagScale * y + imagMin)
                Complex c = new Complex(realScale * xPixel + realMin, imagScale * yPixel + imagMin);
                        Complex z = new Complex(0, 0);

                        // black is the default
                        // assumes point will be in the mandelbrot set
                        // iterations will determine if it is not

                        

                image[xPixel, yPixel] = new Pixel();
                        if (coloring.Equals("cores"))
                            image[xPixel, yPixel].FromColor(colorSet[GetCurrentProcessorNumber()]);
                        else if (coloring.Equals("threads"))
                            image[xPixel, yPixel].FromColor(colorSet[Thread.CurrentThread.ManagedThreadId]);

                        for (int iterIdx = 0; iterIdx < iterations; iterIdx++)
                        {
                    // the basic iteration rule
                    z = z * z + c;

                    // does it tend to infinity?
                    // yes, it seems strange, but there is a proof
                    // for this (https://classes.yale.edu/fractals/MandelSet/JuliaSets/InfinityProof.html)
                    // Essentially, if the distance of z from the origin (magnitude), is greater than 2
                    // then the iteration will go to infinity, which means it is NOT in the mandelbrot
                    // set
                    if (z.Magnitude > 2.0)
                            {
                                double percentage = (double)iterIdx / (double)iterations;
                                Color chosen = colorSet[(int)(percentage * colorSet.Count)];
                                image[xPixel, yPixel].FromColor(chosen);
                                break;
                            }
                        }
                    }
                });
            }
            else
            {
                // Sequential Version
                for (int xPixel = 0; xPixel < width; xPixel++)
                {
                    for (int yPixel = 0; yPixel < height; yPixel++)
                    {
                        Complex c = new Complex(realScale * xPixel + realMin, imagScale * yPixel + imagMin);
                        Complex z = new Complex(0, 0);
                        image[xPixel, yPixel] = new Pixel(0, 0, 0);
                        for (int iterIdx = 0; iterIdx < iterations; iterIdx++)
                        {
                            z = z * z + c;
                            if (z.Magnitude > 2.0)
                            {
                                double percentage = (double)iterIdx / (double)iterations;
                                Color chosen = colorSet[(int)(percentage * colorSet.Count)];
                                image[xPixel, yPixel].FromColor(chosen);
                                break;
                            }
                        }
                    }
                }
            }

            return image;
        }
    }


}
