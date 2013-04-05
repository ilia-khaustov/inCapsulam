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
    public class UserControlEmpty : UserControl
    {

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UserControlEmpty
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "UserControlEmpty";
            this.ResumeLayout(false);

        }
    }
}
