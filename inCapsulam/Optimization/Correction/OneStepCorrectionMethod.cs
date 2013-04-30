using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using inCapsulam.Optimization;
using inCapsulam.Optimization.Methods;

namespace inCapsulam.Optimization.Correction
{
    public class OneStepCorrectionMethod : CorrectionMethod
    {
        public OneStepCorrectionMethod (Task t)
        {
            task = t;
        }

        public override List<Solution> correctSolutions(List<Solution> mixed)
        {
            List<Solution> bad = new List<Solution>();
            List<Solution> good = new List<Solution>();

            List<Solution> corrected = new List<Solution>();

            for (int i = 0; i < mixed.Count; i++)
            {
                if (violationOf(mixed[i].Parameters) > 0)
                {
                    bad.Add(mixed[i]);
                }
                else
                {
                    good.Add(mixed[i]);
                }
            }

            if (good.Count == 0) return new List<Solution>();

            for (int i = 0; i < good.Count; i++)
            {
                for (int j = 0; j < bad.Count; j++)
                {
                    if (Program.rndm.NextDouble() < task.ga_Settings.PostOptimizationCoefficient)
                        corrected.Add(BitSearch(
                            (GeneticApproachMethod.SolutionGA)good[i], 
                            (GeneticApproachMethod.SolutionGA)bad[j]
                            ));
                }
            }

            corrected.Sort(compareSolutions);

            return corrected;
        }
    }
}
