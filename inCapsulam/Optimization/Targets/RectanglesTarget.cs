using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using inCapsulam.Rectangles;

namespace inCapsulam.Optimization.Targets
{
    [Serializable()]
    public class RectanglesTarget : BlackBox, ITarget
    {
        public double[] Heights;
        public double[] Widths;

        public override double TargetFunction()
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            for (int i = 0; i < Parameters.Length; i += 2)
            {
                rectangles.Add(
                    new Rectangle(
                        Parameters[i],
                        Parameters[i+1],
                        Parameters[i] + Widths[rectangles.Count],
                        Parameters[i+1] + Heights[rectangles.Count]
                        )
                    );
            }

            double usefulSpace = 0;
            for (int i = 0; i < rectangles.Count; i++)
            {
                usefulSpace += rectangles[i].Space;
            }

            double allSpace = 0;
            double xMax = 0;
            double yMax = 0;
            for (int i = 0; i < rectangles.Count; i++)
            {
                if (rectangles[i].FirstPoint[0] > xMax)
                {
                    xMax = rectangles[i].FirstPoint[0];
                }
                if (rectangles[i].SecondPoint[0] > xMax)
                {
                    xMax = rectangles[i].SecondPoint[0];
                }

                if (rectangles[i].FirstPoint[1] > yMax)
                {
                    yMax = rectangles[i].FirstPoint[1];
                }
                if (rectangles[i].SecondPoint[1] > yMax)
                {
                    yMax = rectangles[i].SecondPoint[1];
                }
            }

            allSpace = xMax * yMax;

            return Math.Abs(allSpace - usefulSpace) / allSpace;
        }

        double _Blur;
        public double Blur
        {
            get
            {
                return _Blur;
            }
            set
            {
                _Blur = value;
            }
        }

        public string Description
        {
            get
            {
                string description = "Задача о размещении " + Widths.Length + " прямоугольников.";
                for (int i = 0; i < Widths.Length; i++)
                {
                    description += "\r\n\tПрямоугольник " + Widths[i] + "x" + Heights[i];
                }
                return description;
            }
        }

        public class Constraint_NoIntersection : BlackBox
        {
            public RectanglesTarget target;

            public override double TargetFunction()
            {
                List<Rectangle> rectangles = new List<Rectangle>();
                for (int i = 0; i < Parameters.Length; i += 2)
                {
                    rectangles.Add(
                        new Rectangle(
                            Parameters[i],
                            Parameters[i + 1],
                            Parameters[i] + target.Widths[rectangles.Count],
                            Parameters[i + 1] + target.Heights[rectangles.Count]
                            )
                    );
                }

                double total = 0;
                for (int i = 0; i < rectangles.Count; i++)
                {
                    for (int j = 0; j < rectangles.Count; j++)
                    {
                        if (j == i) continue;
                        Rectangle intersection = rectangles[i] - rectangles[j];
                        total += intersection.Space;
                    }
                }

                return -total;
            }
        }
    }
}
