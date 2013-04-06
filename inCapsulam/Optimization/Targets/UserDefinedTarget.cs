using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using inCapsulam.Optimization;
using System.Collections;
using info.lundin.math;

namespace inCapsulam.Optimization.Targets
{
    [Serializable()]
    public class UserDefinedTarget : BlackBox, ITarget
    {
        [NonSerialized()]
        Hashtable htable;
        [NonSerialized()]
        ExpressionParser parser = new ExpressionParser();
        public String expression;
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
                return "Произвольнвя функция";
            }
        }

        public UserDefinedTarget()
        {
            expression = "1";
            Parameters = new double[1];
        }

        public UserDefinedTarget(string expression, int variablesCount)
        {
            this.expression = expression;
            Parameters = new double[variablesCount];
        }

        public override double TargetFunction()
        {
            double result = double.NaN;
            try
            {
                if (object.Equals(htable, null)) htable = new Hashtable();
                else htable.Clear();
                double error = Various.GenerateNormallyDistributedValue(0, 3 * Blur);
                if (object.Equals(parser, null)) parser = new ExpressionParser();
                for (int i = 0; i < Parameters.Length; i++)
                {
                    htable.Add("x" + (i + 1), Parameters[i].ToString());
                }
                result = parser.Parse(expression, htable) + error;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
