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
    public partial class UserControlConstraintsManager : UserControlEmpty
    {
        string tempExpression = "";
        bool tempIsEquality = false;
        int tempIndex = -1;

        public UserControlConstraintsManager()
        {
            InitializeComponent();
            if (object.Equals(Program.TaskCurrent.Target, null))
            {
                expressionTextBox.Font = new Font(expressionTextBox.Font.FontFamily, 18);
                expressionTextBox.Enabled = false;
                expressionTextBox.Text = "Сначала следует задать объект исследования.";
            }
            else
            {
                buttonRemove.Enabled = false;
                buttonSave.Enabled = false;
                RefreshList();
            }
        }

        private void RefreshList()
        {
            constraintsListBox.Items.Clear();
            if (object.Equals(Program.TaskCurrent.Constraints, null)) return;
            for (int i = 0; i < Program.TaskCurrent.Constraints.Length; i++)
            {
                constraintsListBox.Items.Add(
                    ((UserDefinedTarget)Program.TaskCurrent.Constraints[i]).expression +
                    (Program.TaskCurrent.IsEquality[i] ? " = 0" : " >= 0"));
            }
            if (tempIndex >= 0)
            {
                constraintsListBox.Focus();
                constraintsListBox.SelectedIndex = tempIndex;
                constraintsListBox.SetSelected(tempIndex, true);
                constraintsListBox.Refresh();
            }
            else
            {
                constraintsListBox.ClearSelected();
                buttonRemove.Enabled = false;
            }
        }

        private void UserControlConstraintsManager_Resize(object sender, EventArgs e)
        {
            expressionTextBox.Width = this.Width - 1;
            constraintsListBox.Width = this.Width - 1;
            constraintsListBox.Height = this.Height - constraintsListBox.Location.Y;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (expressionTextBox.Enabled)
            {
                expressionTextBox.Clear();
                tempExpression = "";
                tempIsEquality = false;
                tempIndex = -1;
                constraintsListBox.ClearSelected();
                buttonRemove.Enabled = false;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (expressionTextBox.Enabled)
            {
                expressionTextBox_TextChanged(expressionTextBox, new EventArgs());
                if (tempIndex >= 0)
                {
                    if (!Program.TaskCurrent.EditConstraint(tempIndex, tempExpression, tempIsEquality))
                    {
                        MessageBox.Show("Не удалось изменить ограничение.", "Ошибка сохранения", MessageBoxButtons.OK);
                        return;
                    }
                }
                else
                {
                    if (!Program.TaskCurrent.AddConstraint(tempExpression, tempIsEquality))
                    {
                        MessageBox.Show("Не удалось добавить ограничение.", "Ошибка сохранения", MessageBoxButtons.OK);
                        return;
                    }
                }
                expressionTextBox.Clear();
                tempIndex = -1;
                tempExpression = "";
                tempIsEquality = false;
                RefreshList();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (expressionTextBox.Enabled)
            {
                Program.TaskCurrent.RemoveConstraint(tempIndex);
                tempIndex--;
            }
            RefreshList();
        }

        private void expressionTextBox_TextChanged(object sender, EventArgs e)
        {
            string buffer = expressionTextBox.Text;
            if (!expressionTextBox.Enabled) return;
            if (!buffer.Contains('=') && !buffer.Contains('>') && !buffer.Contains('<'))
            {
                if (Program.TaskCurrent.CheckConstraint(buffer))
                {
                    tempExpression = buffer;
                    tempIsEquality = false;
                    buttonSave.Enabled = true;
                    return;
                }
                else
                {
                    buttonSave.Enabled = false;
                    return;
                }
            }
            else
            {
                if (buffer.Contains(">="))
                {
                    string[] parts = buffer.Split(new string[1] { ">=" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parts.Length; i++) parts[i] = parts[i].Trim();
                    if (parts.Length != 2)
                    {
                        buttonSave.Enabled = false;
                        return;
                    }
                    else
                    {
                        tempIsEquality = false;
                        if (parts[1] != "0" && parts[1] != "") tempExpression = parts[0] + " - (" + parts[1] + ")";
                        else tempExpression = parts[0];
                        buttonSave.Enabled = true;
                        return;
                    }
                }
                else if (buffer.Contains("<="))
                {
                    string[] parts = buffer.Split(new string[1] { "<=" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parts.Length; i++) parts[i] = parts[i].Trim();
                    if (parts.Length != 2)
                    {
                        buttonSave.Enabled = false;
                        return;
                    }
                    else
                    {
                        tempIsEquality = false;
                        if (parts[1] != "0" && parts[1] != "") tempExpression = "-(" + parts[0] + ") + " + parts[1];
                        else tempExpression = "-(" + parts[0] + ")";
                        buttonSave.Enabled = true;
                        return;
                    }
                }
                else if (buffer.Contains(">"))
                {
                    string[] parts = buffer.Split(new string[1] { ">" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parts.Length; i++) parts[i] = parts[i].Trim();
                    if (parts.Length != 2)
                    {
                        buttonSave.Enabled = false;
                        return;
                    }
                    else
                    {
                        tempIsEquality = false;
                        if (parts[1] != "0" && parts[1] != "") tempExpression = parts[0] + " - (" + parts[1] + ") - " + Program.TaskCurrent.ga_Settings.Precision;
                        else tempExpression = parts[0] + " - " + Program.TaskCurrent.ga_Settings.Precision;
                        buttonSave.Enabled = true;
                        return;
                    }
                }
                else if (buffer.Contains("<"))
                {
                    string[] parts = buffer.Split(new string[1] { "<" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parts.Length; i++) parts[i] = parts[i].Trim();
                    if (parts.Length != 2)
                    {
                        buttonSave.Enabled = false;
                        return;
                    }
                    else
                    {
                        tempIsEquality = false;
                        if (parts[1] != "0" && parts[1] != "") tempExpression = "-(" + parts[0] + ") + " + parts[1] + " - " + Program.TaskCurrent.ga_Settings.Precision;
                        else tempExpression = "-(" + parts[0] + ")" + " - " + Program.TaskCurrent.ga_Settings.Precision;
                        buttonSave.Enabled = true;
                        return;
                    }
                }
                else if (buffer.Contains("="))
                {
                    string[] parts = buffer.Split(new string[1] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parts.Length; i++) parts[i] = parts[i].Trim();
                    if (parts.Length != 2)
                    {
                        buttonSave.Enabled = false;
                        return;
                    }
                    else
                    {
                        tempIsEquality = true;
                        if (parts[1] != "0" && parts[1] != "") tempExpression = parts[0] + " - (" + parts[1] + ")";
                        else tempExpression = parts[0];
                        buttonSave.Enabled = true;
                        return;
                    }
                }
                else
                {
                    buttonSave.Enabled = false;
                    return;
                }
            }
        }

        private void constraintsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (constraintsListBox.SelectedIndex >= 0)
            {
                tempIndex = constraintsListBox.SelectedIndex;
                tempIsEquality = Program.TaskCurrent.IsEquality[tempIndex];
                tempExpression = (string)constraintsListBox.SelectedItem;
                expressionTextBox.Text = tempExpression;
                buttonRemove.Enabled = true;
            }
            else
            {
                buttonRemove.Enabled = false;
            }
        }
    }
}
