using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using inCapsulam.Optimization;

namespace inCapsulam.Optimization.Correction
{
    public class OneStepCorrectionMethod
    {
        public Task task;
        public int calculations = 0;
        public OneStepCorrectionMethod(Task task)
        {
            this.task = task;
        }

        public List<double[]> correctSolutions(List<double[]> mixed)
        {
            List<double[]> bad = new List<double[]>();
            List<double[]> good = new List<double[]>();

            List<double[]> corrected = new List<double[]>();

            for (int i = 0; i < mixed.Count; i++)
            {
                if (violationOf(mixed[i]) > 0)
                {
                    bad.Add(mixed[i]);
                }
                else
                {
                    good.Add(mixed[i]);
                }
            }

            if (good.Count == 0) return new List<double[]>();

            for (int i = 0; i < good.Count; i++)
            {
                for (int j = 0; j < bad.Count; j++)
                {
                    if (Program.rndm.NextDouble() < task.ga_Settings.Precision)
                        corrected.Add(GoldenSection(good[i], bad[j]));
                }
            }

            good.AddRange(corrected.ToArray());
            good.Sort(compareSolutions);

            return good;
        }

        int compareSolutions(double[] s1, double[] s2)
        {
            double y1 = task.Target.Calculate(s1);
            calculations++;
            double y2 = task.Target.Calculate(s2);
            calculations++;

            if (y1 == y2) return 0;
            else if (y1 > y2) return 1;
            else return -1;
        }

        public double violationOf(double[] solution)
        {
            if (object.Equals(task.Constraints, null)) return 0;
            double value = 0;
            for (int i = 0; i < task.Constraints.Length; i++)
            {
                task.Constraints[i].Parameters = solution;
                double res = task.Constraints[i].TargetFunction();
                calculations++;
                if (task.IsEquality[i])
                {
                    res = Math.Abs(res);
                    if (res >= task.ga_Settings.Precision) value += Math.Pow(res, 2);
                }
                else if (res <= task.ga_Settings.Precision)
                {
                    value += Math.Pow(res, 2);
                }
            }
            return Math.Sqrt(value);
        }

        double[] GoldenSection(double[] good, double[] bad)
        {
            Vector A = new Vector(good);
            Vector B = new Vector(bad);
            double gs = 1.618033988749895;
            Vector X1, X2, AB, Xmin, Xgood;
            AB = B - A;
            Xmin = (A + B) / 2;
            Xgood = A;
            while (AB.EuklidNorm > 1)
            {
                X1 = A + (B - A) / gs;
                X2 = B - (B - A) / gs;
                double y1 = task.Target.Calculate(X1.Values);
                double y2 = task.Target.Calculate(X2.Values);
                double v1 = violationOf(X1.Values);
                double v2 = violationOf(X2.Values);
                calculations += 2;
                if (v1 >= v2)
                {
                    if (v1 <= task.ga_Settings.Precision)
                    {
                        if (y1 >= y2) B = X1;
                        else A = X2;
                    }
                    else B = X1;
                }
                else if (v2 <= task.ga_Settings.Precision)
                {
                    if (y1 >= y2) B = X1;
                    else A = X2;
                }
                else A = X2;

                Xmin = (A + B) / 2;
                if (violationOf(Xmin.Values) < task.ga_Settings.Precision) 
                    Xgood = new Vector(Xmin.Values);
                AB = B - A;
            }
            return Xgood.Values;
        }
    }
}
