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
    public partial class UserControlPOTesting : UserControlEmpty
    {
        public UserControlPOTesting()
        {
            InitializeComponent();
        }

        private void UserControlPOTesting_Resize(object sender, EventArgs e)
        {
            double h1 = 0.711;
            double h2 = 0.1956;

            textBoxSamples.Height = (int)(h1 * this.Height);
            textBoxSamples.Width = (int)(0.5 * this.Width);
            textBoxResult.Width = (int)(0.5 * this.Width);
            textBoxResult.Height = (int)(h1 * this.Height);
            textBoxInfo.Height = (int)(h2 * this.Height);
            textBoxInfo.Width = this.Width;

            int level1 = 0;
            int level2 = level1 + textBoxSamples.Height + 5;
            int level3 = level2 + buttonTest.Height + 8;

            textBoxResult.Location = new Point(textBoxSamples.Width + 5, 0);
            buttonTest.Location = new Point(buttonTest.Location.X, level2);
            textBoxInfo.Location = new Point(textBoxInfo.Location.X, level3);
        }

        private void UserControlPOTesting_Load(object sender, EventArgs e)
        {
            UserControlPOTesting_Resize(null, null);
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxInfo.Text = "";
                string samplesString = textBoxSamples.Text;
                string[] samplesStrings = samplesString.Split(new string[1] { "\r\n" }, StringSplitOptions.None);
                List<Solution> samples = new List<Solution>();
                Optimization.Correction.OneStepCorrectionMethod method =
                    new Optimization.Correction.OneStepCorrectionMethod(Program.TaskCurrent);

                double qualitySamples = 0;

                for (int i = 0; i < samplesStrings.Length; i++)
                {
                    string[] newSampleString = samplesStrings[i].Split(new string[1] { " " }, StringSplitOptions.None);
                    GeneticApproachMethod.SolutionGA newSample = new GeneticApproachMethod.SolutionGA(
                        new GeneticApproachMethod.Process(Program.TaskCurrent, Program.TaskCurrent.ga_Settings));
                    for (int j = 0; j < newSampleString.Length; j++)
                    {
                        newSample[j] = double.Parse(newSampleString[j]);
                    }
                    qualitySamples += Program.TaskCurrent.EstimatePoint(newSample.ParametersDouble);
                    samples.Add(newSample);
                }

                qualitySamples /= samplesString.Length;
                textBoxInfo.Text += "Качество выборки:\r\n\t" + qualitySamples + "\r\n";

                List<Solution> corrected = method.correctSolutions(samples);

                textBoxResult.Text = "";
                double qualityResult = 0;

                for (int i = 0; i < corrected.Count; i++)
                {
                    for (int j = 0; j < corrected[i].Parameters.Length; j++)
                    {
                        textBoxResult.Text += corrected[i].Parameters[j] + " ";
                    }
                    qualityResult += Program.TaskCurrent.EstimatePoint(corrected[i].Parameters);
                    textBoxResult.Text += "\r\n";
                }
                qualityResult /= corrected.Count;
                textBoxInfo.Text += "Качество исправленной выборки:\r\n\t" + qualityResult + "\r\n";
                textBoxInfo.Text += "Количество вычислений:\r\n\t" + method.calculations + "\r\n";
            }
            catch (Exception ex)
            {
                textBoxInfo.Text = ex.Message + '\n' + ex.StackTrace;
            }
        }
    }
}
