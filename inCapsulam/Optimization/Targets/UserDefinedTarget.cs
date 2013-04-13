using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using inCapsulam.Optimization;
using System.Collections;
using YAMP;

namespace inCapsulam.Optimization.Targets
{
    [Serializable()]
    public class UserDefinedTarget : BlackBox, ITarget
    {
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
                return expression;
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
            double error = Various.GenerateNormallyDistributedValue(0, 3 * Blur);

            fillConstants();

            var parser = Parser.Parse(expression);
            result = ((ScalarValue)parser.Execute()).Value + error;

            return result;
        }

        void fillConstants()
        {
            for (int i = 0; i < Parameters.Length; i++)
            {
                string key = "x" + (i + 1);
                Parser.AddCustomConstant(key, Parameters[i]);
            }
        }
    }
}
