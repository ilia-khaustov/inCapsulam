using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using inCapsulam.Optimization;

namespace inCapsulam.Optimization.Correction
{
    public class OneStepCorrectionMethod : CorrectionMethod
    {
        public OneStepCorrectionMethod (Task t)
        {
            task = t;
        }

        public override List<double[]> correctSolutions(List<double[]> mixed)
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
                    if (Program.rndm.NextDouble() < task.ga_Settings.PostOptimizationCoefficient)
                        corrected.Add(GoldenSection(good[i], bad[j]));
                }
            }

            corrected.Sort(compareSolutions);

            return corrected;
        }
    }
}
