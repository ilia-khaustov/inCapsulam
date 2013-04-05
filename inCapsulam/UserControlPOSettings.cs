using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using inCapsulam.Optimization;
using inCapsulam.Optimization.Methods;

namespace inCapsulam
{
    public partial class UserControlPOSettings : UserControlEmpty
    {
        public UserControlPOSettings()
        {
            InitializeComponent();
            RefreshData();
        }

        void RefreshData()
        {
            GeneticApproachMethod.Settings s;
            s = Program.TaskCurrent.ga_Settings;

            coefficient.Value = (decimal)s.PostOptimizationCoefficient;
            mode.SelectedIndex = s.PostOptimizationMode;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            GeneticApproachMethod.Settings s;
            s = Program.TaskCurrent.ga_Settings;

            s.PostOptimizationCoefficient = (double)coefficient.Value;
            s.PostOptimizationMode = (short)mode.SelectedIndex;

            Program.TaskCurrent.ga_Settings = s;
        }
    }
}
