using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using inCapsulam.Optimization.Targets;

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
            textBoxX.Width = this.Width - 1;
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
            Program.TaskCurrent.TargetType = Optimization.Task.TargetType_PreDefinedFunction;
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

        private void UserControlPredefinedTarget_Load(object sender, EventArgs e)
        {

        }

        private void variablesCountSpin_ValueChanged(object sender, EventArgs e)
        {
            string value = "";
            for (int i = 0; i < variablesCountSpin.Value; i++)
            {
                value += "0";
                if (i < variablesCountSpin.Value - 1) value += " ";
            }
            textBoxX.Text = value;
        }

        private void textBoxX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string x_text = textBoxX.Text;
                string[] x_textArray = x_text.Split(new char[1] { ' ' });
                double[] newPointOfMinimum = new double[x_textArray.Length];
                for (int i = 0; i < newPointOfMinimum.Length; i++)
                {
                    newPointOfMinimum[i] = Double.Parse(x_textArray[i]);
                }
                Program.TaskCurrent.PointOfMinimum = newPointOfMinimum;
                saveButton.Enabled = true;
            }
            catch (Exception ex)
            {
                saveButton.Enabled = false;
            }
        }
    }
}
