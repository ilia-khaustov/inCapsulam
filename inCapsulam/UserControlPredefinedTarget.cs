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
    public partial class UserControlPredefinedTarget : UserControlEmpty
    {
        public UserControlPredefinedTarget()
        {
            InitializeComponent();
            if (object.Equals(Program.TaskCurrent.Target, null)) return;
            if (Program.TaskCurrent.Target.GetType() == typeof(PreDefinedTarget))
            {
                functionsComboBox.SelectedIndex = ((PreDefinedTarget)Program.TaskCurrent.Target).IdSelected;
                variablesCountSpin.Value = ((PreDefinedTarget)Program.TaskCurrent.Target).Parameters.Length;
            }
        }

        private void UserControlPredefinedTarget_Resize(object sender, EventArgs e)
        {
            functionsComboBox.Width = this.Width - 1;
        }

        private void functionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (functionsComboBox.SelectedIndex > 2)
            {
                variablesCountSpin.Value = 2;
                variablesCountSpin.Enabled = false;
            }
            else variablesCountSpin.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Program.TaskCurrent.Target = new PreDefinedTarget((short)functionsComboBox.SelectedIndex, (short)variablesCountSpin.Value);
            Program.TaskCurrent.TargetType = Task.TargetType_PreDefinedFunction;
            if (object.Equals(Program.TaskCurrent.Constraints, null)) return;
            else
            {
                for (int i = 0; i < Program.TaskCurrent.Constraints.Length; i++)
                {
                    if (!Program.TaskCurrent.CheckConstraint(((UserDefinedTarget)Program.TaskCurrent.Constraints[i]).expression))
                    {
                        Program.TaskCurrent.RemoveConstraint(i);
                        i--;
                    }
                }
            }
        }
    }
}
