using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using inCapsulam.Optimization.Targets;

namespace inCapsulam.Optimization
{
    [Serializable(), XmlInclude(typeof(PreDefinedTarget)), XmlInclude(typeof(UserDefinedTarget))]
    /// <summary>
    /// Inheritable class, used in analysis as a "black box" model.
    /// </summary>
    abstract public class BlackBox
    {
        private double[] _Parameters;

        private void SetParameters(double[] newParameters)
        {
            _Parameters = new double[newParameters.Length];
            for (int i = 0; i < _Parameters.Length; i++)
            {
                Parameters[i] = newParameters[i];
            }
        }

        /// <summary>
        /// Set of Parameters, describing process.
        /// </summary>
        public double[] Parameters
        {
            set
            {
                SetParameters(value);
            }
            get
            {
                return _Parameters;
            }
        }

        /// <summary>
        /// Needs to be overrided; should calculate cost/fitness/value/etc.
        /// </summary>
        /// <returns>Calculated with current set of Parameters value</returns>
        abstract public double TargetFunction();

        public double[] Gradient()
        {
            double[] grad = new double[_Parameters.Length];
            double dX = 0.00000000001, Y, Y1;
            for (int i = 0; i < grad.Length; i++)
            {
                Y = TargetFunction();
                _Parameters[i] += dX;
                Y1 = TargetFunction();
                _Parameters[i] -= dX;
                grad[i] = (Y1 - Y) / dX;
            }
            return grad;
        }

        public double Calculate(double[] x)
        {
            double[] temp = Parameters;
            Parameters = x;
            double value = TargetFunction();
            Parameters = temp;
            return value;
        }
    }
}
