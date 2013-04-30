using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using inCapsulam.Optimization.Targets;

namespace inCapsulam
{
    public partial class UserControlSingleResult : UserControlEmpty
    {
        ZedGraph.LineItem best = new ZedGraph.LineItem("Лучшее");
        ZedGraph.LineItem average = new ZedGraph.LineItem("Среднее");
        ZedGraph.LineItem worst = new ZedGraph.LineItem("Худшее");
        ZedGraph.LineItem populationValues = new ZedGraph.LineItem("Значения в популяции");
        ZedGraph.LineItem[] rects;
        ToolTip richTextBoxToolTip;

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
            zedGraphControlDemo.GraphPane.Title.Text = "";
            zedGraphControlDemo.GraphPane.XAxis.Title.Text = "";
            zedGraphControlDemo.GraphPane.YAxis.Title.Text = "";
            zedGraphControlDemo.GraphPane.XAxis.MajorGrid.IsVisible = true;
            zedGraphControlDemo.GraphPane.YAxis.MajorGrid.IsVisible = true;
            zedGraphControlDemo.GraphPane.YAxis.MajorGrid.IsZeroLine = false;
            if (Program.TaskCurrent.Target.GetType() == typeof(RectanglesTarget))
            {
                rects = new ZedGraph.LineItem[((RectanglesTarget)Program.TaskCurrent.Target).Heights.Length];
                for (int i = 0; i < rects.Length; i++)
                {
                    rects[i] = new ZedGraph.LineItem("");
                    rects[i].Symbol.Type = ZedGraph.SymbolType.None;
                    rects[i].Line.Fill.Type = ZedGraph.FillType.Solid;
                    rects[i].Line.Color = Color.DimGray;
                    rects[i].Line.Fill.Color = Color.CornflowerBlue;
                    rects[i].Line.Width = 1;
                    zedGraphControlDemo.GraphPane.CurveList.Add(rects[i]);
                }
            }
            
            richTextBoxToolTip = new ToolTip();

            resultRichTextBox.Text = Program.TaskCurrent.GetInfo();

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
            zedGraphControlDemo.Width = tabControlDefault.Width - 20;
            zedGraphControlDemo.Height = tabControlDefault.Height - 65;
            valueGraph.Width = tabControlDefault.Width - 20;
            valueGraph.Height = tabControlDefault.Height - 56;
            generationNumber.Width = tabControlDefault.Width - 20;
        }

        public void SetCommonInfo()
        {
            for (int i = 0; i < fitnessGraph.GraphPane.CurveList.Count; i++)
            {
                fitnessGraph.GraphPane.CurveList[i].Clear();
            }
            for (int i = 0; i < zedGraphControlDemo.GraphPane.CurveList.Count; i++)
            {
                zedGraphControlDemo.GraphPane.CurveList[i].Clear();
            }
            int loggingCount = Program.TaskCurrent.ga_Process.Logging_BestFitness.Count;
            for (int i = 0; i < loggingCount; i++)
            {
                best.AddPoint(i, Program.TaskCurrent.ga_Process.Logging_BestFitness[i]);
                average.AddPoint(i, Program.TaskCurrent.ga_Process.Logging_AverageFitness[i]);
                worst.AddPoint(i, Program.TaskCurrent.ga_Process.Logging_WorstFitness[i]);
            }
            if (Program.TaskCurrent.Target.GetType() == typeof(RectanglesTarget))
            {
                double[] s = Program.TaskCurrent.ga_Process.Logging_BestSolution.Last();
                int index = 0;
                double[] widths = ((RectanglesTarget)Program.TaskCurrent.Target).Widths;
                double[] heights = ((RectanglesTarget)Program.TaskCurrent.Target).Heights;
                for (int i = 0; i < s.Length; i += 2)
                {
                    rects[index].AddPoint(s[i], s[i + 1]);
                    rects[index].AddPoint(s[i] + widths[index], s[i + 1]);
                    rects[index].AddPoint(s[i] + widths[index], s[i + 1] + heights[index]);
                    rects[index].AddPoint(s[i], s[i + 1] + heights[index]);
                    rects[index].AddPoint(s[i], s[i + 1]);
                    index++;
                }
                RefreshDemoGraph();
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

        void RefreshDemoGraph()
        {
            zedGraphControlDemo.GraphPane.YAxis.Scale.MaxAuto = true;
            zedGraphControlDemo.GraphPane.YAxis.Scale.MinAuto = true;
            zedGraphControlDemo.Invalidate();
            zedGraphControlDemo.AxisChange();
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

        private void resultRichTextBox_Click(object sender, EventArgs e)
        {
            resultRichTextBox.Text = Program.TaskCurrent.GetInfo();
        }

        private void resultRichTextBox_MouseHover(object sender, EventArgs e)
        {
            richTextBoxToolTip.Show(
                "Кликните, чтобы обновить информацию.",
                this.Parent,
                new Point(MousePosition.X - this.Parent.Location.X, MousePosition.Y - this.Parent.Location.Y),
                500);
        }
    }
}
