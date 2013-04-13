using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inCapsulam.Optimization
{
    public class Solution
    {
        public double[] Parameters;

        public Task task;

        public Solution(Task t)
        {
            task = t;
        }

        public Solution() { }

        public double Violation
        {
            get
            {
                return ViolationCalculate(this);
            }
        }

        static public double ViolationCalculate(Solution s)
        {
            if (object.Equals(s.task.Constraints, null)) return 0;
            double value = 0;
            for (int i = 0; i < s.task.Constraints.Length; i++)
            {
                s.task.Constraints[i].Parameters = s.Parameters;
                double res = s.task.Constraints[i].TargetFunction();
                if (s.task.IsEquality[i])
                {
                    res = Math.Abs(res);
                    if (res >= s.task.ga_Settings.Precision) value += Math.Pow(res, 2);
                }
                else if (res <= s.task.ga_Settings.Precision)
                {
                    value += Math.Pow(res, 2);
                }
            }
            return Math.Sqrt(value);
        }

        public bool IsFeasible
        {
            get
            {
                if (Violation > task.ga_Settings.Precision)
                {
                    return false;
                }
                else return true;
            }
        }

    }
}
