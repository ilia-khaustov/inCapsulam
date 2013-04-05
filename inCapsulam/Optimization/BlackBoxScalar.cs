using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inCapsulam.Optimization
{
    public class BlackBoxScalar : BlackBox
    {
        BlackBox VectorObject;
        int ScalarIndex;

        public BlackBoxScalar(BlackBox VectorObject)
        {
            this.VectorObject = VectorObject;
            ScalarIndex = 0;
            Parameters = new double[1];
            Parameters[0] = VectorParameters[0];
        }

        public void SetScalarParameter(int index)
        {
            Parameters = new double[1];
            Parameters[0] = VectorObject.Parameters[index];
            ScalarIndex = index;
        }

        void SetScalarParameter()
        {
            VectorObject.Parameters[ScalarIndex] = Parameters[0];
        }

        public double[] VectorParameters
        {
            get
            {
                double[] arr = new double[VectorObject.Parameters.Length];
                VectorObject.Parameters.CopyTo(arr, 0);
                return arr;
            }

            set
            {
                VectorObject.Parameters = value;
            }
        }

        public override double TargetFunction()
        {
            SetScalarParameter();
            return VectorObject.TargetFunction();
        }
    }
}
