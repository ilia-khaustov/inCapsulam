using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inCapsulam.Optimization
{
    public class Vector
    {
        double[] _Values;

        public int Dimensions
        {
            get { return _Values.Length; }
        }

        public double[] Values
        {
            get
            {
                return _Values;
            }
            set
            {
                if (value.Length != Dimensions)
                {
                    throw new Exception("Vector dimensions do not match.");
                }
                else
                {
                    value.CopyTo(_Values, 0);
                }
            }
        }

        public double this[int index]
        {
            get { return _Values[index]; }
            set { _Values[index] = value; }
        }

        public Vector()
        {
            _Values = new double[0];
        }

        public Vector(int dimensions)
        {
            _Values = new double[dimensions];
        }

        public Vector(double[] values)
        {
            _Values = new double[values.Length];
            values.CopyTo(_Values, 0);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            if (v1.Dimensions != v2.Dimensions)
            {
                throw new Exception("Vector dimensions do not match.");
            }
            double[] newValues = new double[v1.Dimensions];
            for (int i = 0; i < newValues.Length; i++)
            {
                newValues[i] = v1[i] + v2[i];
            }
            Vector newVector = new Vector(newValues);
            return newVector;
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            if (v1.Dimensions != v2.Dimensions)
            {
                throw new Exception("Vector dimensions do not match.");
            }
            double[] newValues = new double[v1.Dimensions];
            for (int i = 0; i < newValues.Length; i++)
            {
                newValues[i] = v1[i] - v2[i];
            }
            Vector newVector = new Vector(newValues);
            return newVector;
        }

        public static Vector operator *(Vector v, double value)
        {
            Vector newVector = new Vector(v.Values);
            for (int i = 0; i < v.Dimensions; i++)
            {
                newVector[i] = newVector[i] * value;
            }
            return newVector;
        }

        public static Vector operator /(Vector v, double value)
        {
            Vector newVector = new Vector(v.Values);
            for (int i = 0; i < v.Dimensions; i++)
            {
                newVector[i] = newVector[i] * (1 / value);
            }
            return newVector;
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            if (v1.Dimensions != v2.Dimensions)
            {
                throw new Exception("Vector dimensions do not match.");
            }
            for (int i = 0; i < v1.Dimensions; i++)
            {
                if (v1[i] != v2[i]) return false;
            }
            return true;
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            if (v1.Dimensions != v2.Dimensions)
            {
                throw new Exception("Vector dimensions do not match.");
            }
            for (int i = 0; i < v1.Dimensions; i++)
            {
                if (v1[i] != v2[i]) return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return _Values.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            string line = "";
            for (int i = 0; i < Dimensions; i++)
            {
                line += Math.Round(this[i], 3);
                if (i < Dimensions - 1) line += "\t";
            }
            return line;
        }

        public double EuklidNorm
        {
            get
            {
                double value = 0;
                for (int i = 0; i < Dimensions; i++)
                {
                    value += _Values[i] * _Values[i];
                }
                value = Math.Sqrt(value);
                return value;
            }
        }
    }
}
