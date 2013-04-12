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
    public partial class UserControlGASettings : UserControlEmpty
    {
        bool auto = true;

        public UserControlGASettings()
        {
            InitializeComponent();
            leftBorderInterval_ValueChanged(new object(), new EventArgs());
            rightBorderInterval_ValueChanged(new object(), new EventArgs());
            useChildSelection_CheckedChanged(new object(), new EventArgs());
            RefreshData();
            auto = false;
        }

        void RefreshData()
        {
            GeneticApproachMethod.Settings settings = Program.TaskCurrent.ga_Settings;
            bitsCount.Value = settings.BitCount;
            crossoverType.SelectedIndex = settings.CrossoverMode;
            elitismSize.Value = settings.ElitismNumber;
            iterationsMax.Value = settings.IterationsMaxNumber;
            leftBorderInterval.Value = (decimal)settings.LeftBorderOfFirstPopulationInterval;
            rightBorderInterval.Value = (decimal)settings.RightBorderOfFirstPopulationInterval;
            parentSelectionType.SelectedIndex = settings.ParentSelectionMode;
            tournierSize.Value = settings.TournamentSize;
            elitismUse.Checked = settings.UseElitism;
            greyCodeUse.Checked = settings.UseGreyCode;
            postSelectionType.SelectedIndex = settings.PostSelectionMode;
            precision.Value = (decimal)settings.Precision;
            populationCount.Value = (decimal)settings.PopulationCount;
            penaltyType.SelectedIndex = settings.PenaltyMode;
            mutationType.SelectedIndex = settings.MutationMode;
            mutationCoeff.Value = (decimal)settings.MutationCoefficient;
            usePositiveOnly.Checked = settings.UsePositiveOnly;
            objectiveFunctionMin.Value = (decimal)settings.ObjectiveFunctionMinValue;
            useChildSelection.Checked = settings.UseChildSelection;
            childSelectionType.SelectedIndex = settings.ChildSelectionMode;
            threadsCount.Value = (decimal)settings.ThreadsCount;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            GeneticApproachMethod.Settings settings = Program.TaskCurrent.ga_Settings;
            settings.BitCount = (short)bitsCount.Value;
            settings.CrossoverMode = (short)crossoverType.SelectedIndex;
            settings.ElitismNumber = (int)elitismSize.Value;
            settings.IterationsMaxNumber = (int)iterationsMax.Value;
            settings.LeftBorderOfFirstPopulationInterval = (int)leftBorderInterval.Value;
            settings.RightBorderOfFirstPopulationInterval = (int)rightBorderInterval.Value;
            settings.ParentSelectionMode = (short)parentSelectionType.SelectedIndex;
            settings.TournamentSize = (int)tournierSize.Value;
            settings.UseElitism = elitismUse.Checked;
            settings.UseGreyCode = greyCodeUse.Checked;
            settings.PostSelectionMode = (short)postSelectionType.SelectedIndex;
            settings.Precision = (double)precision.Value;
            settings.PopulationCount = (int)populationCount.Value;
            settings.PenaltyMode = (short)penaltyType.SelectedIndex;
            settings.MutationMode = (short)mutationType.SelectedIndex;
            settings.MutationCoefficient = (double)mutationCoeff.Value;
            settings.UsePositiveOnly = usePositiveOnly.Checked;
            settings.ObjectiveFunctionMinValue = (double)objectiveFunctionMin.Value;
            settings.UseChildSelection = useChildSelection.Checked;
            settings.ChildSelectionMode = (short)childSelectionType.SelectedIndex;
            settings.ThreadsCount = (int)threadsCount.Value;
            Program.TaskCurrent.ga_Settings = settings;
        }

        private void leftBorderInterval_ValueChanged(object sender, EventArgs e)
        {
            if (!auto) rightBorderInterval.Minimum = leftBorderInterval.Value;
        }

        private void rightBorderInterval_ValueChanged(object sender, EventArgs e)
        {
            if (!auto) leftBorderInterval.Maximum = rightBorderInterval.Value;
        }

        private void usePositiveOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (usePositiveOnly.Checked) leftBorderInterval.Minimum = 0;
            else leftBorderInterval.Minimum = decimal.MinValue;
        }

        private void crossoverType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void useChildSelection_CheckedChanged(object sender, EventArgs e)
        {
            childSelectionType.Enabled = useChildSelection.Checked;
        }

        private void penaltyType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
