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
    public partial class UserControlJsTarget : UserControlEmpty
    {
        JsTarget tempTarget = new JsTarget();

        public UserControlJsTarget()
        {
            InitializeComponent();
        }

        private void UserControlJsTarget_Resize(object sender, EventArgs e)
        {
            labelPrompt.Width = this.Width;
            textBoxJsCode.Width = this.Width;
            textBoxJsCode.Height = this.Height - 94;
            textBoxResult.Width = this.Width - 210;
            maskedTextBoxParams.Width = this.Width - 210;

            int level1 = labelPrompt.Height + textBoxJsCode.Height + 5;
            int level2 = level1 + 30;

            labelParamsCount.Location = new Point(
                labelParamsCount.Location.X,
                level1 + 3);
            numericUpDownParamsCount.Location = new Point(
                numericUpDownParamsCount.Location.X,
                level1);
            maskedTextBoxParams.Location = new Point(
                maskedTextBoxParams.Location.X,
                level1);

            buttonSave.Location = new Point(
                buttonSave.Location.X,
                level2);
            buttonTest.Location = new Point(
                buttonTest.Location.X,
                level2);
            textBoxResult.Location = new Point(
                textBoxResult.Location.X,
                level2);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            maskedTextBoxParams.Mask = "[ ";
            for (int i = 0; i < numericUpDownParamsCount.Value; i++)
            {
                maskedTextBoxParams.Mask += "00.00";
                if (i < numericUpDownParamsCount.Value - 1) maskedTextBoxParams.Mask += " ; ";
            }
            maskedTextBoxParams.Mask += " ]";
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            try
            {
                tempTarget.jsCode = textBoxJsCode.Text;
                string paramsString = maskedTextBoxParams.Text;
                paramsString = paramsString.Substring(1, paramsString.Length - 2);
                string[] paramsArray = paramsString.Split(new string[1] { " ; " }, StringSplitOptions.None );
                tempTarget.Parameters = new double[paramsArray.Length];
                for (int i = 0; i < paramsArray.Length; i++)
                {
                    tempTarget.Parameters[i] = double.Parse(paramsArray[i]);
                }
                textBoxResult.Text = tempTarget.TargetFunction() + "";
                buttonSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Program.TaskCurrent.Target = tempTarget;
            Program.TaskCurrent.TargetType = Task.TargetType_JavaScriptCode;
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

        private void UserControlJsTarget_Load(object sender, EventArgs e)
        {
            numericUpDown1_ValueChanged(null, null);
            buttonSave.Enabled = false;
            if (object.Equals(Program.TaskCurrent.Target, null)) return;
            if (Program.TaskCurrent.Target.GetType() == typeof(JsTarget))
            {
                textBoxJsCode.Text = ((JsTarget)Program.TaskCurrent.Target).jsCode;
                numericUpDownParamsCount.Value = ((JsTarget)Program.TaskCurrent.Target).Parameters.Length;
                tempTarget = new JsTarget();
                tempTarget.jsCode = ((JsTarget)Program.TaskCurrent.Target).jsCode;
                tempTarget.Parameters = new double[((JsTarget)Program.TaskCurrent.Target).Parameters.Length];
            }
        }

        private void textBoxJsCode_TextChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = false;
        }
    }
}
