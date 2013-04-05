using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inCapsulam.Optimization.Methods
{
    /// <summary>
    /// Provides scalar optimization method using search interval dividing.
    /// </summary>
    public class ScalarIntervalDividingMethod
    {
        public class Settings
        {
            public double LeftBorder;
            public double RightBorder;
            /// <summary>
            /// Sets which method to use; HalfOnHalf/Fibonacci/GoldenSection
            /// </summary>
            public string Method;
            public double Epsilon = 0.05;
            public int FibonacciIterations;
            public double FibonacciEpsilon;
        }

        public class Process
        {
            /// <summary>
            /// Object used in process
            /// </summary>
            public BlackBox TheObject;
            /// <summary>
            /// Settings used in process
            /// </summary>
            public Settings TheSettings;
            /// <summary>
            /// Length of interval, which is checked in every step with accuracy value you choose.
            /// </summary>
            public double AB;
            /// <summary>
            /// Value found on current step.
            /// </summary>
            public double MinX;
            // Method to use
            string MethodChosen;
            // HalfOnHalf, GoldenSection
            double A, B, X1, X2, Eps;
            // Fibonacci
            int N;
            double E;

            public Process(BlackBox theObject, Settings theSettings)
            {
                TheObject = theObject;
                TheSettings = theSettings;
                A = TheSettings.LeftBorder;
                B = TheSettings.RightBorder;
                MethodChosen = TheSettings.Method;
                N = TheSettings.FibonacciIterations;
                E = theSettings.FibonacciEpsilon;
                Eps = theSettings.Epsilon;
            }

            public void Run()
            {
                if (MethodChosen == "HalfOnHalf")
                {
                    HalfOnHalf();
                }
                else if (MethodChosen == "Fibonacci")
                {
                    Fibonacci();
                }
                else if (MethodChosen == "GoldenSection")
                {
                    GoldenSection();
                }
            }

            public double[] RunToTheEnd()
            {
                do
                {
                    Run();
                } while (AB < Eps);
                return new double[1] { MinX };
            }

            void HalfOnHalf()
            {
                double fx1, fx2, fxMin;
                MinX = (A + B) / 2;
                AB = B - A;
                fxMin = ScalarCalculate(MinX);
                X1 = A + AB / 4;
                X2 = B - AB / 4;
                fx1 = ScalarCalculate(X1);
                fx2 = ScalarCalculate(X2);
                if (fx1 < fxMin)
                {
                    B = MinX;
                    MinX = X1;
                }
                else
                {
                    if (fxMin > fx2)
                    {
                        A = MinX;
                        MinX = X2;
                    }
                    else
                    {
                        A = X1;
                        B = X2;
                    }
                }
                AB = B - A;
            }

            void Fibonacci()
            {
                double x1, x2;
                for (int i = 0; i < N; i++)
                {
                    AB = B - A;
                    double L2 = (double)Function.FibonacciValue(N - i - 1) / (double)Function.FibonacciValue(N - i);
                    L2 = L2 * AB;
                    if (i % 2 == 0)
                    {
                        L2 += E / Function.FibonacciValue(N - i);
                    }
                    else
                    {
                        L2 -= E / Function.FibonacciValue(N - i);
                    }
                    x1 = A + L2;
                    x2 = B - L2;
                    double y1 = ScalarCalculate(x1);
                    double y2 = ScalarCalculate(x2);
                    if (x1 < x2)
                    {
                        if (y1 < y2) B = x2;
                        else A = x1;
                    }
                    else
                    {
                        if (y1 > y2) B = x1;
                        else A = x2;
                    }
                    AB = B - A;
                    MinX = (A + B) / 2;
                }
            }

            void GoldenSection()
            {
                double gs = 1.618033988749895;
                X1 = A + (B - A) / gs;
                X2 = B - (B - A) / gs;
                double y1 = ScalarCalculate(X1);
                double y2 = ScalarCalculate(X2);
                if (y1 >= y2) B = X1;
                else A = X2;
                MinX = (A + B) / 2;
                AB = B - A;
            }

            public double ScalarCalculate(double x)
            {
                double[] X = new double[1];
                X[0] = x;
                TheObject.Parameters = X;
                return TheObject.TargetFunction();
            }
        }
    }
}
