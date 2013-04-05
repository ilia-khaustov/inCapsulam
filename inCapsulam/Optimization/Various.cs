using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inCapsulam.Optimization
{
    /// <summary>
    /// Various help: arrays, strings etc.
    /// </summary>
    public class Various
    {
        /// <summary>
        /// Orders double array as descending (ascending), with indexing
        /// </summary>
        /// <param name="values">Ref array</param>
        /// <param name="indexes">Ref indexes</param>
        /// <param name="desc">TRUE - descending, FALSE - ascending</param>
        static public void OrderByDesc(ref double[] values, ref int[] indexes, bool desc)
        {
            indexes = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                indexes[i] = i;
            }
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = i; j < values.Length; j++)
                {
                    if (desc)
                    {
                        if (values[j] > values[i])
                        {
                            double val = values[i];
                            int ind = indexes[i];
                            values[i] = values[j];
                            indexes[i] = indexes[j];
                            values[j] = val;
                            indexes[j] = ind;
                        }
                    }
                    else
                    {
                        if (values[j] < values[i])
                        {
                            double val = values[i];
                            int ind = indexes[i];
                            values[i] = values[j];
                            indexes[i] = indexes[j];
                            values[j] = val;
                            indexes[j] = ind;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Orders integer array as descending (ascending), with indexing
        /// </summary>
        /// <param name="values">Ref array</param>
        /// <param name="indexes">Ref indexes</param>
        /// <param name="desc">TRUE - descending, FALSE - ascending</param>
        static public void OrderByDesc(ref int[] values, ref int[] indexes, bool desc)
        {
            indexes = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                indexes[i] = i;
            }
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = i; j < values.Length; j++)
                {
                    if (desc)
                    {
                        if (values[j] > values[i])
                        {
                            int val = values[i];
                            int ind = indexes[i];
                            values[i] = values[j];
                            indexes[i] = indexes[j];
                            values[j] = val;
                            indexes[j] = ind;
                        }
                    }
                    else
                    {
                        if (values[j] < values[i])
                        {
                            int val = values[i];
                            int ind = indexes[i];
                            values[i] = values[j];
                            indexes[i] = indexes[j];
                            values[j] = val;
                            indexes[j] = ind;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Orders double array as descending (ascending), without indexing
        /// </summary>
        /// <param name="values">Ref array</param>
        /// <param name="desc">TRUE - descending, FALSE - ascending</param>
        static public void OrderByDesc(ref double[] values, bool desc)
        {
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = i; j < values.Length; j++)
                {
                    if (desc)
                    {
                        if (values[j] > values[i])
                        {
                            double val = values[i];
                            values[i] = values[j];
                            values[j] = val;
                        }
                    }
                    else
                    {
                        if (values[j] < values[i])
                        {
                            double val = values[i];
                            values[i] = values[j];
                            values[j] = val;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Orders integer array as descending (ascending), without indexing
        /// </summary>
        /// <param name="values">Ref array</param>
        /// <param name="desc">TRUE - descending, FALSE - ascending</param>
        static public void OrderByDesc(ref int[] values, bool desc)
        {
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = i; j < values.Length; j++)
                {
                    if (desc)
                    {
                        if (values[j] > values[i])
                        {
                            int val = values[i];
                            values[i] = values[j];
                            values[j] = val;
                        }
                    }
                    else
                    {
                        if (values[j] < values[i])
                        {
                            int val = values[i];
                            values[i] = values[j];
                            values[j] = val;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Returns the closest to chosen position index of matched value.
        /// </summary>
        /// <param name="values">Array of double</param>
        /// <param name="value">Value to search</param>
        /// <param name="position">The last entry index. If equals -1, returns the last entry index.</param>
        /// <returns>Index of matched value</returns>
        static public int GetIndexOfValue(double[] values, double value, int position = 0)
        {
            int index = -1;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == value)
                {
                    index = i;
                    if (position == 0)
                    {
                        break;
                    }
                    position--;
                }
            }
            return index;
        }
        /// <summary>
        /// Returns the closest to chosen position index of matched value.
        /// </summary>
        /// <param name="values">Array of int</param>
        /// <param name="value">Value to search</param>
        /// <param name="position">The last entry index. If equals -1, returns the last entry index.</param>
        /// <returns>Index of matched value</returns>
        static public int GetIndexOfValue(int[] values, int value, int position = 0)
        {
            int index = -1;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == value)
                {
                    index = i;
                    if (position == 0)
                    {
                        break;
                    }
                    position--;
                }
            }
            return index;
        }

        static public string DoubleToString(double value, int decimalPlaces)
        {
            string valueString = Math.Round(value, decimalPlaces).ToString();
            string[] splitted = valueString.Split(new char[1] { ',' });
            string afterComma = "";
            if (splitted.Length > 1)
            {
                afterComma = splitted[1];
            }
            else
            {
                if (decimalPlaces > 0) valueString += ",";
            }
            if (afterComma.Length < decimalPlaces)
            {
                for (int i = afterComma.Length; i < decimalPlaces; i++)
                {
                    valueString += "0";
                }
            }
            return valueString;
        }

        /// <summary>
        /// Generates normally distributed value
        /// </summary>
        /// <param name="a">Mean value</param>
        /// <param name="d">Dispersion</param>
        /// <param name="n">Iterations, more than 15 recommended</param>
        /// <returns></returns>
        static public double GenerateNormallyDistributedValue(double a = 0, double d = 1, int n = 15)
        {
            double x = 0;
            for (int i = 0; i < n; i++)
            {
                x += Program.rndm.NextDouble();
            }
            x = (x - 0.5 * n) / Math.Sqrt(((double)1 / (double)12) * n);
            x = a + x * d;
            return x;
        }
    }
}
