using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inCapsulam.Optimization.Methods
{
    public class GaussZeidelMethod
    {
        public class Settings
        {
            /// <summary>
            /// Starting set of parameters
            /// </summary>
            public double[] FirstX;
            /// <summary>
            /// Left border of scalar search interval; should be negative
            /// </summary>
            public double LeftBorder;
            /// <summary>
            /// Right border of scalar search interval; should be positive
            /// </summary>
            public double RightBorder;
            /// <summary>
            /// Accuracy value for result value Y
            /// </summary>
            public double Epsilon;
            /// <summary>
            /// Accuracy value for parameter X
            /// </summary>
            public double Delta;
            /// <summary>
            /// HalfOnHalf; GoldenSection
            /// </summary>
            public string ScalarMethod;
        }

        public class Process
        {
            BlackBoxScalar TheScalarObject;
            /// <summary>
            /// Settings used in process
            /// </summary>
            public Settings TheSettings;
            /// <summary>
            /// Result parameters found delivering minimum to output
            /// </summary>
            public double[] MinX;
            /// <summary>
            /// Minimum value of the output
            /// </summary>
            public double MinY;
            string Method;
            double LeftBorder;
            double RightBorder;
            double Epsilon;
            double Delta;

            List<double[]> Logging_X = new List<double[]>();
            List<double> Logging_Y = new List<double>();

            public Process(BlackBox theObject, Settings theSettings)
            {
                theObject.Parameters = theSettings.FirstX;
                TheScalarObject = new BlackBoxScalar(theObject);
                MinX = new double[theSettings.FirstX.Length];
                theSettings.FirstX.CopyTo(MinX, 0);
                MinY = TheScalarObject.TargetFunction();
                Method = theSettings.ScalarMethod;
                LeftBorder = theSettings.LeftBorder;
                RightBorder = theSettings.RightBorder;
                Epsilon = theSettings.Epsilon;
                Delta = theSettings.Delta;
            }

            public double[] RunToTheEnd()
            {
                int iteration = 0;
                do
                {
                    for (int i = 0; i < MinX.Length; i++)
                    {
                        ScalarIntervalDividingMethod.Settings settings = new ScalarIntervalDividingMethod.Settings();
                        settings.Method = Method;
                        settings.LeftBorder = Logging_X.Last()[i] + LeftBorder;
                        settings.RightBorder = Logging_X.Last()[i] + RightBorder;
                        ScalarIntervalDividingMethod.Process process = new ScalarIntervalDividingMethod.Process(TheScalarObject, settings);
                        TheScalarObject.SetScalarParameter(i);
                        do
                        {
                            process.Run();
                        } while (process.AB > Epsilon);
                        MinX = TheScalarObject.VectorParameters;
                        MinY = TheScalarObject.TargetFunction();
                    }
                    Logging_X.Add(MinX);
                    Logging_Y.Add(MinY);
                    iteration++;
                    if (iteration > 1000) break;
                } while 
                    (
                        (VectorDifference(Logging_X[iteration - 1], Logging_X[iteration]) > Delta) ||
                         (Math.Abs(Logging_Y[iteration] - Logging_Y[iteration - 1]) > Epsilon)
                    );
                return MinX;
            }

            double VectorDifference(double[] x1, double[] x2)
            {
                double value = 0;
                for (int i = 0; i < x1.Length; i++)
                {
                    value += Math.Abs(x1[i] - x2[i]);
                }
                return value;
            }
        }
    }
}
