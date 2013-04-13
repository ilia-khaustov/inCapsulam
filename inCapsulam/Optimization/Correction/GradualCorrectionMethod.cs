using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inCapsulam.Optimization.Correction
{
    class GradualCorrectionMethod : CorrectionMethod
    {
        public GradualCorrectionMethod(Task t)
        {
            task = t;
        }

        public override List<double[]> correctSolutions(List<double[]> mixed)
        {
            List<double[]> corrected = new List<double[]>();

            List<double[]> bad = new List<double[]>();
            List<double[]> good = new List<double[]>();

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

            bad.Sort(compareSolutions);

            while (bad.Count > 0)
            {
                for (int i = 0; i < good.Count; i++)
                {
                    if (Program.rndm.NextDouble() > task.ga_Settings.PostOptimizationCoefficient) continue;
                    corrected.Add(GoldenSection(good[i], bad.First()));
                    good.Add(corrected.Last());
                    bad.RemoveAt(0);
                    if (bad.Count == 0) break;
                }
            }

            return corrected;
        }
    }
}
