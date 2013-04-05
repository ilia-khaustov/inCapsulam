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
    public partial class UserControlTasksList : UserControlEmpty
    {
        public UserControlTasksList()
        {
            InitializeComponent();
            RefreshList();
        }

        private void RefreshList()
        {
            listBoxTasks.Items.Clear();
            for (int i = 0; i < Program.TasksList.Count; i++)
            {
                listBoxTasks.Items.Add("Исследование №"+(i+1)+". Запусков: " + Program.TasksList[i].TimesToRun);
            }
        }

        private void TasksList_Resize(object sender, EventArgs e)
        {
            listBoxTasks.Width = this.Width - 6;
            richTextBoxDescription.Height = this.Height - 183;
            richTextBoxDescription.Width = this.Width - 6;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedIndices != null)
            {
                ListBox.SelectedIndexCollection collection = listBoxTasks.SelectedIndices;
                for (int i = 0; i < collection.Count; i++)
                {
                    Program.TasksList.RemoveAt(collection[i]);
                    listBoxTasks.Items.RemoveAt(collection[i]);
                    i--;
                }
            }
            RefreshList();
        }

        private void checkedListBoxTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedIndex < 0)
            {
                richTextBoxDescription.Clear();
                return;
            }
            richTextBoxDescription.Text = Program.TasksList[listBoxTasks.SelectedIndex].GetSettingsInfo();
        }

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Вы уверены? Действие нельзя отменить.", "Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Program.TasksList.Clear();
                RefreshList();
            }
        }
    }
}
