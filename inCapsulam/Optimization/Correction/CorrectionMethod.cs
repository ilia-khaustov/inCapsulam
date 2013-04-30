using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using inCapsulam.Optimization.Methods;

namespace inCapsulam.Optimization.Correction
{
    public abstract class CorrectionMethod
    {
        public Task task;
        public int calculations = 0;

        public CorrectionMethod() { }
        public abstract List<Solution> correctSolutions(List<Solution> mixed);

        public int compareSolutions(Solution s1, Solution s2)
        {
            double y1 = task.Target.Calculate(s1.Parameters);
            double y2 = task.Target.Calculate(s2.Parameters);

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

        public double[] GoldenSection(Solution good, Solution bad)
        {
            Vector A = new Vector(good.Parameters);
            Vector B = new Vector(bad.Parameters);
            double gs = 1.618033988749895;
            Vector X1, X2, AB, Xmin, Xgood;
            AB = B - A;
            double E = AB.EuklidNorm / 10;
            Xmin = (A + B) / 2;
            Xgood = A;
            while (AB.EuklidNorm > E)
            {
                X1 = B - (B - A) / gs;
                X2 = A + (B - A) / gs;
                double y1 = task.Target.Calculate(X1.Values);
                double y2 = task.Target.Calculate(X2.Values);
                double v1 = violationOf(X1.Values);
                double v2 = violationOf(X2.Values);
                calculations += 2;
                if (v1 >= v2)
                {
                    if (v1 <= task.ga_Settings.Precision)
                    {
                        if (y1 >= y2) A = X1;
                        else B = X2;
                    }
                    else A = X1;
                }
                else if (v2 <= task.ga_Settings.Precision)
                {
                    if (y1 >= y2) A = X1;
                    else B = X2;
                }
                else B = X2;
                AB = B - A;
            }
            Xmin = (A + B) / 2;
            if (violationOf(Xmin.Values) < task.ga_Settings.Precision)
                Xgood = new Vector(Xmin.Values);
            calculations++;
            return Xgood.Values;
        }

        public GeneticApproachMethod.SolutionGA BitSearch(
            GeneticApproachMethod.SolutionGA bad,
            GeneticApproachMethod.SolutionGA good
            )
        {
            GeneticApproachMethod.SolutionGA corrected;
            corrected = new GeneticApproachMethod.SolutionGA(bad);
            corrected.ParametersBoolean = (bool[][])bad.ParametersBoolean.Clone();
            int bitsTotal = bad.ParametersBoolean.Length * bad.ParametersBoolean[0].Length;
            byte[] indexes = new byte[bitsTotal];
            Program.rndm.NextBytes(indexes);
            double goodValue = task.Target.Calculate(good.ParametersDouble);
            for (int i = 0; i < bitsTotal; i++)
            {
                corrected = GeneticApproachMethod.SolutionGA.Crossover(good, bad);
                if (i % 1 == 0)
                {
                    if (violationOf(corrected.ParametersDouble) < task.ga_Settings.Precision &&
                        task.Target.Calculate(corrected.ParametersDouble) < goodValue)
                    {
                        break;
                    }
                }
            }
            return corrected;
        }
    }
}
