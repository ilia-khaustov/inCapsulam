using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inCapsulam.Optimization
{
    /// <summary>
    /// Provides built-in mathematical functions and other stuff.
    /// </summary>
    public static class Function
    {

        public static double Griewank(double x, double y)
        {
            double val = 0;
            val = -10;
            val = val / (0.005 * (x * x + y * y) - Math.Cos(x) * Math.Cos(y / Math.Sqrt(2)) + 2);
            val += 10;
            return val;
        }

        public static double Parabola(double[] xSet, double parA = 1.0, double parB = 0.0, double parC = 0.0)
        {
            double value = 0;
            int count = xSet.Count();
            for (int i = 0; i < count; i++)
            {
                value += parA * xSet[i] * xSet[i] + parB * xSet[i] + parC;
            }
            return value;
        }

        public static double ParabolaWithWait(double[] xSet, double parA = 1.0, double parB = 0.0, double parC = 0.0)
        {
            double value = 0;
            int count = xSet.Count();
            for (int i = 0; i < count; i++)
            {
                value += parA * xSet[i] * xSet[i] + parB * xSet[i] + parC;
            }
            System.Threading.Thread.Sleep(1);
            return value;
        }

        public static double Rozenbrok(double x, double y)
        {
            double val = 0;

            val = 100 * (y - x * x) * (y - x * x) + (1 - x) * (1 - x);

            return val;
        }

        public static double Sombrero(double x, double y)
        {
            double val = 0;
            val = 1 - Math.Sin(Math.Sqrt(x * x + y * y)) * Math.Sin(Math.Sqrt(x * x + y * y));
            val = val / 0.001 * (x * x + y * y);
            return val;
        }

        public static double Rastrigina(double[] x)
        {
            double val = 10 * (double)x.Length;
            for (int i = 0; i < x.Length; i++)
            {
                val += x[i] * x[i] - 10 * Math.Cos(2 * Math.PI * x[i]);
            }
            return val;
        }

        public static double Schwefel(double[] x)
        {
            double val = 0;
            for (int i = 0; i < x.Length; i++)
            {
                val += -x[i] * Math.Sin(Math.Sqrt(Math.Abs(x[i])));
            }
            return val - 420.9687;
        }

        public static double FibonacciValue(int n)
        {
            long n1 = 0, n2 = 1, fibo = 0;
            n++;

            for (int i = 1; i < n; i++)
            {
                n1 = n2;
                n2 = fibo;
                fibo = n1 + n2;
            }

            return fibo;
        }

        public static double SopovFunction(double x, double y)
        {
            double alpha = Math.PI / 2;
            double kx = 1.5;
            double ky = 0.8;
            double A = x * Math.Cos(alpha) - y * Math.Sin(alpha);
            double B = x * Math.Sin(alpha) + y * Math.Cos(alpha);
            return Math.Pow(0.1 * kx * A, 2) + 
                Math.Pow(0.1 * ky * B, 2) - 
                4 * Math.Cos(0.8 * kx * A) - 
                4 * Math.Cos(0.8 * ky * B) + 8;
        }
    }
}
