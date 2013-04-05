using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace inCapsulam
{
    public partial class UserControlBlur : UserControlEmpty
    {
        public UserControlBlur()
        {
            InitializeComponent();
            blur.Value = (decimal)((ITarget)Program.TaskCurrent.Target).Blur * 100;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ITarget t = (ITarget)Program.TaskCurrent.Target;
            t.Blur = (double)blur.Value / 100.0;
        }
    }
}
