using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using inCapsulam.Optimization.Targets;
using inCapsulam.Optimization;

namespace inCapsulam
{
    public partial class UserControlUserDefinedTarget : UserControlEmpty
    {
        UserDefinedTarget tempTarget = new UserDefinedTarget("", 0);

        public UserControlUserDefinedTarget()
        {
            InitializeComponent();
            saveButton.Enabled = false;
            if (object.Equals(Program.TaskCurrent.Target, null)) return;
            if (Program.TaskCurrent.Target.GetType() == typeof(UserDefinedTarget))
            {
                expressionTextBox.Text = ((UserDefinedTarget)Program.TaskCurrent.Target).expression;
                variablesCountSpin.Value = ((UserDefinedTarget)Program.TaskCurrent.Target).Parameters.Length;
                tempTarget = new UserDefinedTarget(expressionTextBox.Text, (int)variablesCountSpin.Value);
            }
        }

        private void expressionTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void UserControlUserDefinedTarget_Resize(object sender, EventArgs e)
        {
            expressionTextBox.Width = this.Width - 1;
            expressionTextBox.Height = this.Height - 48;
            label2.Location = new Point(label2.Location.X, this.Height - 19);
            variablesCountSpin.Location = new Point(variablesCountSpin.Location.X, this.Height - 23);
            saveButton.Location = new Point(saveButton.Location.X, this.Height - 23);
        }

        private void variablesCountSpin_ValueChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = false;
            try
            {
                tempTarget.expression = expressionTextBox.Text;
                tempTarget.Parameters = new double[(int)variablesCountSpin.Value];
                tempTarget.TargetFunction();
                saveButton.Enabled = true;
            }
            catch
            {

            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Program.TaskCurrent.Target = new UserDefinedTarget(expressionTextBox.Text, (int)variablesCountSpin.Value);
            Program.TaskCurrent.TargetType = Task.TargetType_UserDefinedFunction;
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
