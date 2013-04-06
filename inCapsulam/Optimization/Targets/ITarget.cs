using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inCapsulam
{
    public interface ITarget
    {
        double Blur
        {
            get;
            set;
        }

        string Description
        {
            get;
        }
    }
}
