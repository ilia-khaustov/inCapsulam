using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using inCapsulam.Optimization;
using Noesis.Javascript;

namespace inCapsulam.Optimization.Targets
{
    [Serializable()]
    class JsTarget : BlackBox, ITarget
    {
        public string jsCode = "";

        public override double TargetFunction()
        {
            using (JavascriptContext context = new JavascriptContext())
            {
                // Setting external parameters for the context
                context.SetParameter("params", Parameters);
                context.SetParameter("result", 0);

                // Running the script
                context.Run(jsCode);

                // Getting a result
                double result = double.NaN;
                if (context.GetParameter("result").GetType() == typeof(double))
                {
                    result = (double)context.GetParameter("result");
                }
                else if (context.GetParameter("result").GetType() == typeof(int))
                {
                    result = (int)context.GetParameter("result");
                }
                return result;
            }
        }

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
                return "Код на JavaScript";
            }
        }
    }
}
