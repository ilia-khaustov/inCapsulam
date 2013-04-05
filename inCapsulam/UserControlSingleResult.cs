using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace inCapsulam
{
    public partial class UserControlSingleResult : UserControlEmpty
    {
        ZedGraph.LineItem best = new ZedGraph.LineItem("Лучшее");
        ZedGraph.LineItem average = new ZedGraph.LineItem("Среднее");
        ZedGraph.LineItem worst = new ZedGraph.LineItem("Худшее");
        ZedGraph.LineItem populationValues = new ZedGraph.LineItem("Значения в популяции");

        public UserControlSingleResult()
        {
            InitializeComponent();
            int newId = 1;
            if (!Directory.Exists(Program.SINGLE_REPORTS_DIRECTORY)) Directory.CreateDirectory(Program.SINGLE_REPORTS_DIRECTORY);
            else
            {
                newId += Directory.GetFiles(Program.SINGLE_REPORTS_DIRECTORY).Length;
            }
            textBoxLocation.Text = Program.SINGLE_REPORTS_DIRECTORY + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + " Отчёт №" + newId + ".txt";
            fitnessGraph.GraphPane.Title.Text = "Графики пригодности";
            fitnessGraph.GraphPane.XAxis.Title.Text = "Номер поколения";
            fitnessGraph.GraphPane.YAxis.Title.Text = "Пригодность";
            valueGraph.GraphPane.Title.Text = "Значения в популяции №" + generationNumber.Value;
            valueGraph.GraphPane.XAxis.Title.Text = "Номер индивида в популяции";
            valueGraph.GraphPane.YAxis.Title.Text = "Значение ЦФ";
            best.Symbol.Type = ZedGraph.SymbolType.None;
            best.Line.Width = 2;
            average.Line.Width = 2;
            worst.Line.Width = 2;
            average.Symbol.Type = ZedGraph.SymbolType.None;
            worst.Symbol.Type = ZedGraph.SymbolType.None;
            average.Line.Color = Color.Black;
            worst.Line.Color = Color.Green;
            best.Line.IsAntiAlias = true;
            average.Line.IsAntiAlias = true;
            worst.Line.IsAntiAlias = true;
            populationValues.Line.Width = 2;
            populationValues.Line.IsAntiAlias = true;
            populationValues.Symbol.Type = ZedGraph.SymbolType.None;
            fitnessGraph.GraphPane.CurveList.Add(best);
            fitnessGraph.GraphPane.CurveList.Add(average);
            fitnessGraph.GraphPane.CurveList.Add(worst);
            valueGraph.GraphPane.CurveList.Add(populationValues);
            showBest.Checked = true;
            showWorst.Checked = true;
            showAverage.Checked = true;
            UserControlSingleResult_Resize(this, new EventArgs());
        }

        private void UserControlSingleResult_Resize(object sender, EventArgs e)
        {
            tabControlDefault.Size = new System.Drawing.Size(this.Width - 6, this.Height - 10);
            resultRichTextBox.Height = tabControlDefault.Height - 70;
            resultRichTextBox.Width = tabControlDefault.Width - 20;
            textBoxLocation.Width = tabControlDefault.Width - 104;
            textBoxLocation.Location = new Point(textBoxLocation.Location.X, tabControlDefault.Height - 58);
            buttonSaveToFile.Location = new Point(buttonSaveToFile.Location.X, tabControlDefault.Height - 58);
            fitnessGraph.Width = tabControlDefault.Width - 20;
            fitnessGraph.Height = tabControlDefault.Height - 65;
            valueGraph.Width = tabControlDefault.Width - 20;
            valueGraph.Height = tabControlDefault.Height - 56;
            generationNumber.Width = tabControlDefault.Width - 20;
        }

        public void SetCommonInfo()
        {
            resultRichTextBox.Text = Program.TaskCurrent.GetInfo();
            for (int i = 0; i < Program.TaskCurrent.ga_Process.Logging_BestFitness.Count; i++)
            {
                best.AddPoint(i, Program.TaskCurrent.ga_Process.Logging_BestFitness[i]);
                average.AddPoint(i, Program.TaskCurrent.ga_Process.Logging_AverageFitness[i]);
                worst.AddPoint(i, Program.TaskCurrent.ga_Process.Logging_WorstFitness[i]);
            }
            RefreshFitnessGraph();
            RefreshValuesGraph();
        }

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream f = File.Open(textBoxLocation.Text, FileMode.Create);
                System.IO.StreamWriter writer = new StreamWriter(f);
                string text = resultRichTextBox.Text;
                string[] lines = text.Split(new char[1] { '\n' });
                for (int i = 0; i < lines.Length; i++)
                {
                    writer.WriteLine(lines[i]);
                }
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Ошибка записи в файл", MessageBoxButtons.OK);
            }
        }

        private void showBest_CheckedChanged(object sender, EventArgs e)
        {
            best.IsVisible = showBest.Checked;
            RefreshFitnessGraph();
        }

        private void showAverage_CheckedChanged(object sender, EventArgs e)
        {
            average.IsVisible = showAverage.Checked;
            RefreshFitnessGraph();
        }

        private void showWorst_CheckedChanged(object sender, EventArgs e)
        {
            worst.IsVisible = showWorst.Checked;
            RefreshFitnessGraph();
        }

        void RefreshFitnessGraph()
        {
            fitnessGraph.GraphPane.YAxis.Scale.MaxAuto = true;
            fitnessGraph.GraphPane.YAxis.Scale.MinAuto = true;
            fitnessGraph.Invalidate();
            fitnessGraph.AxisChange();
        }

        void RefreshValuesGraph()
        {
            populationValues.Clear();
            int number = (int)(
                (double)Program.TaskCurrent.ga_Process.Logging_PopulationValues.Count 
                / 1000.0 
                * (double)generationNumber.Value);
            for (int i = 0; i < Program.TaskCurrent.ga_Process.Logging_PopulationValues[number].Length; i++)
            {
                populationValues.AddPoint(i, Program.TaskCurrent.ga_Process.Logging_PopulationValues[number][i]);
            }
            fitnessGraph.GraphPane.YAxis.Scale.MaxAuto = true;
            fitnessGraph.GraphPane.YAxis.Scale.MinAuto = true;
            valueGraph.Invalidate();
            valueGraph.AxisChange();
            valueGraph.GraphPane.Title.Text = "Значения в популяции №" + number;
        }

        private void generationNumber_Scroll(object sender, ScrollEventArgs e)
        {
            RefreshValuesGraph();
        }
    }
}
