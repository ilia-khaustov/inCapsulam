using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inCapsulam.Rectangles
{
    public class Rectangle
    {
        private double[] firstPoint;
        public double[] FirstPoint
        {
            get { return firstPoint; }
        }

        private double[] secondPoint;
        public double[] SecondPoint
        {
            get { return secondPoint; }
        }

        private int dims;
        public int Dims
        {
            get { return dims; }
        }

        public Rectangle()
        {

        }

        public Rectangle(double[][] points)
        {
            if (points.Length != 2)
            {
                throw new Exception("Too many points for rectangle.");
            }
            dims = points[0].Length;
            if (dims != points[1].Length)
            {
                throw new Exception("Points dimensions mismatch.");
            }

            firstPoint = (double[])points[0].Clone();
            secondPoint = (double[])points[1].Clone();
        }

        public Rectangle(params double[] points)
        {
            if (points.Length % 2 == 1)
            {
                throw new Exception("Points count is not even.");
            }
            List<double> p1 = new List<double>();
            List<double> p2 = new List<double>();

            for (int i = 0; i < points.Length / 2; i++)
            {
                p1.Add(points[i]);
            }
            for (int i = points.Length / 2; i < points.Length; i++)
            {
                p2.Add(points[i]);
            }

            firstPoint = p1.ToArray();
            secondPoint = p2.ToArray();

            dims = firstPoint.Length;
            if (dims != secondPoint.Length)
            {
                throw new Exception("Points dimensions mismatch.");
            }
        }

        public Rectangle(Rectangle old)
        {
            firstPoint = old.FirstPoint;
            secondPoint = old.SecondPoint;
        }

        public double[] Ribs
        {
            get
            {
                double[] ribs = new double[firstPoint.Length];
                for (int i = 0; i < ribs.Length; i++)
                {
                    ribs[i] = Math.Abs(firstPoint[i] - secondPoint[i]);
                }
                return ribs;
            }
        }

        public double Space
        {
            get
            {
                double[] ribs = Ribs;
                return ribs.Aggregate(1.0, (accumulator, current) => accumulator * current);
            }
        }

        public static bool operator >= (Rectangle r1, Rectangle r2)
        {
            return r1.Space >= r2.Space ? true : false;
        }

        public static bool operator <= (Rectangle r1, Rectangle r2)
        {
            return r1.Space <= r2.Space ? true : false;
        }

        public static Rectangle operator -(Rectangle r1, Rectangle r2)
        {
            if (r1.Dims != r2.Dims)
            {
                throw new Exception("Dimensions mismatch; " + r1.Dims + " is not equal to " + r2.Dims + "."); 
            }

            double[] newFirstPoint = new double[r1.Dims];
            double[] newSecondPoint = new double[r1.Dims];

            // going through each projection
            for (int i = 0; i < r1.Dims; i++)
            {
                double a1, a2, b1, b2; // such as a2 > a1 and b2 > b1

                if (r1.FirstPoint[i] >= r1.SecondPoint[i])
                {
                    a1 = r1.SecondPoint[i];
                    a2 = r1.FirstPoint[i];
                }
                else
                {
                    a1 = r1.FirstPoint[i];
                    a2 = r1.SecondPoint[i];
                }
                if (r2.FirstPoint[i] >= r2.SecondPoint[i])
                {
                    b1 = r2.SecondPoint[i];
                    b2 = r2.FirstPoint[i];
                }
                else
                {
                    b1 = r2.FirstPoint[i];
                    b2 = r2.SecondPoint[i];
                }

                /*
                 *      a1-------a2
                 * b1------------------b2
                 * 
                 * */
                if (a2 <= b2 && a1 >= b1)
                {
                    newFirstPoint[i] = a1;
                    newSecondPoint[i] = a2;
                }
                /*
                 * a1----------------a2
                 *      b1------b2
                 * 
                 * */
                else if (a2 >= b2 && a1 <= b1)
                {
                    newFirstPoint[i] = b1;
                    newSecondPoint[i] = b2;
                }
                /*
                 * a1--------------a2
                 *       b1---------------b2
                 * 
                 * */
                else if (a1 <= b1 && a2 <= b2 && a2 >= b1)
                {
                    newFirstPoint[i] = b1;
                    newSecondPoint[i] = a2;
                }
                /*
                 *        a1--------------a2
                 * b1---------------b2
                 * 
                 * */
                else if (a1 <= b2 && a1 >= b1 && a2 >= b2)
                {
                    newFirstPoint[i] = a1;
                    newSecondPoint[i] = b2;
                }
                
            }

            return new Rectangle(new double[2][] { newFirstPoint, newSecondPoint });
        }

        public static bool isBetween(double x, double a, double b)
        {
            if (a > b)
            {
                return (x <= a && x >= b);
            }
            else if (b > a)
            {
                return (x <= b && x >= a);
            }
            else
            {
                return false;
            }
        }
    }
}
