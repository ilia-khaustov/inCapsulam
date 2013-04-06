using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace inCapsulam
{
    public partial class form_Main : Form
    {
        ZedGraph.ZedGraphControl zgcBackground = new ZedGraph.ZedGraphControl();

        public form_Main()
        {
            InitializeComponent();
            Program.TaskCurrent = new Task();
            form_Main_Resize(this, new EventArgs());
            MakeStatus();
        }

        private void form_Main_Resize(object sender, EventArgs e)
        {
            userControlDefault.Location = new System.Drawing.Point(12, 27);
            userControlDefault.Size = new Size(this.Width - 40, this.Height - 90);
        }

        private void ChangeUserControl(UserControlEmpty userControlNew, string caption)
        {
            this.Controls.Remove(userControlDefault);
            userControlDefault = userControlNew;
            this.Controls.Add(userControlDefault);
            MakeHeader(caption);
            form_Main_Resize(new object(), new EventArgs());
        }

        private void AddLaunches(int count)
        {
            Program.TaskCurrent.TimesToRun = count;
            if (object.Equals(Program.TaskCurrent.Target, null))
            {
                MessageBox.Show("Сначала следует задать объект исследования.", "Нельзя добавить исследование");
            }
            else
            {
                Task newTask = ObjectCopier.Clone<Task>(Program.TaskCurrent);
                Program.TasksList.Add(newTask);
            }
        }

        private void MakeHeader(string addendum = "")
        {
            if (addendum == "") this.Text = "inCapsulam";
            else this.Text = "inCapsulam / " + addendum;
        }

        private void MakeStatus(string newStatus = "")
        {
            if (newStatus == "")
            {
                Random r = new Random();
                switch (r.Next(10))
                {
                    case 0:
                        processesStatusLabel.Text = "Every cloud has a silver lining.";
                        break;
                    case 1:
                        processesStatusLabel.Text = "A stitch in time saves nine.";
                        break;
                    case 2:
                        processesStatusLabel.Text = "You can lead a horse to water, but you cannot make it drink.";
                        break;
                    case 3:
                        processesStatusLabel.Text = "The best things in life are free.";
                        break;
                    case 4:
                        processesStatusLabel.Text = "Don't cross your bridges before you come to them.";
                        break;
                    case 5:
                        processesStatusLabel.Text = "Where there's a will there's a way.";
                        break;
                    case 6:
                        processesStatusLabel.Text = "Soon learnt, soon forgotten.";
                        break;
                    case 7:
                        processesStatusLabel.Text = "Better untaught than ill taught.";
                        break;
                    case 8:
                        processesStatusLabel.Text = "The grass is always greener on the other side.";
                        break;
                    case 9:
                        processesStatusLabel.Text = "Live and let live.";
                        break;
                }
                return;
            }

            processesStatusLabel.Text = newStatus;
        }

        private void singleJobBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MakeStatus("Процесс поиска запущен...");
            try
            {
                if (Program.TaskCurrent.Solve() == null)
                    throw new Exception("Метод генетического поиска возвратил NULL.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Произошла ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void singleJobBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MakeStatus();
            if (Program.TaskCurrent.ga_Process.Logging_AverageFitness.Count > 1)
            {
                ChangeUserControl(new UserControlSingleResult(), "Результаты поиска");
                ((UserControlSingleResult)userControlDefault).SetCommonInfo();
            }
            решитьToolStripMenuItem.Enabled = true;
        }

        private void новаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.TaskCurrent = new Task();
            ChangeUserControl(new UserControlEmpty(), "");
        }

        private void выбратьФункциюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserControl(new UserControlPredefinedTarget(), "Выбор функции для исследования");
        }

        private void ввестиФункциюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserControl(new UserControlUserDefinedTarget(), "Ввод функции для исследования");
        }

        private void ограниченияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserControl(new UserControlConstraintsManager(), "Менеджер ограничений");
        }

        private void решитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (object.Equals(Program.TaskCurrent.Target, null)) return;
            решитьToolStripMenuItem.Enabled = false;
            singleJobBackgroundWorker.RunWorkerAsync();
        }

        private void базовыеНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserControl(new UserControlGASettings(), "Базовые настройки генетического алгоритма");
        }

        private void постоптимизацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserControl(new UserControlPOSettings(), "Настройки пост-оптимизации");
        }

        private void запусковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLaunches(10);
        }

        private void запусковToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddLaunches(100);
        }

        private void запусковToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddLaunches(200);
        }

        private void запусковToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AddLaunches(500);
        }

        private void списокКонфигурацийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserControl(new UserControlTasksList(), "Список конфигураций запусков");
        }

        private void multipleJobBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                zgcBackground = new ZedGraph.ZedGraphControl();
                zgcBackground.GraphPane.Title.Text = "";
                zgcBackground.GraphPane.XAxis.Title.Text = "";
                zgcBackground.GraphPane.YAxis.Title.Text = "Усреднённое значение ЦФ";

                ZedGraph.LineItem bestValue = new ZedGraph.LineItem("Лучшее значение");
                bestValue.Line.IsAntiAlias = true;
                bestValue.Line.Width = 2;
                bestValue.Symbol.Type = ZedGraph.SymbolType.Circle;
                bestValue.Symbol.Fill.Type = ZedGraph.FillType.Solid;
                bestValue.Symbol.Size = 15;
                bestValue.Symbol.Fill.Color = Color.Black;

                zgcBackground.GraphPane.CurveList.Add(bestValue);
                zgcBackground.Height = 500;
                zgcBackground.Width = 500;

                int idFirst = 1;
                int idLast = 1;

                List<string> linesOfData = new List<string>();
                linesOfData.Add(Task.GetStatisticsHeader());
                FileStream f;
                System.IO.StreamWriter writer;

                for (int i = 0; i < Program.TasksList.Count; i++)
                {
                    if (multipleJobBackgroundWorker.CancellationPending) break;
                    try
                    {
                        int newId = 1;

                        if (!Directory.Exists(Program.STATISTICS_REPORTS_DIRECTORY))
                            Directory.CreateDirectory(Program.STATISTICS_REPORTS_DIRECTORY);
                        else
                            newId += Directory.GetFiles(Program.STATISTICS_REPORTS_DIRECTORY).Length;

                        if (!System.IO.Directory.Exists(Program.STATISTICS_GRAPHS_DIRECTORY))
                            System.IO.Directory.CreateDirectory(Program.STATISTICS_GRAPHS_DIRECTORY);
                        if (!System.IO.Directory.Exists(Program.STATISTICS_DATA_DIRECTORY))
                            System.IO.Directory.CreateDirectory(Program.STATISTICS_DATA_DIRECTORY);

                        if (i == 0) idFirst = newId;
                        if (i == Program.TasksList.Count - 1) idLast = newId;

                        string location = Program.STATISTICS_REPORTS_DIRECTORY + "\\" +
                            DateTime.Now.ToString("yyyy-MM-dd") + " Отчёт №" + newId + ".txt";

                        string[] stats = Program.TasksList[i].CollectStatistics();

                        f = File.Open(location, FileMode.Create);
                        writer = new StreamWriter(f);
                        string[] lines = stats[0].Split(new char[1] { '\n' });
                        for (int j = 0; j < lines.Length; j++)
                            writer.WriteLine(lines[j]);
                        writer.Close();
                        f.Close();

                        double value = 0;
                        for (int j = 0; j < lines.Length; j++)
                            if (lines[j] == "Усредненное значение ЦФ лучшего решения:")
                                value = double.Parse(lines[j + 1].Replace("\t", ""));
                        bestValue.AddPoint(i, value);

                        linesOfData.AddRange(stats[1].Split(new char[1] { '\n' }));
                        linesOfData.RemoveAt(linesOfData.Count - 1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Ошибка!", MessageBoxButtons.OK);
                    }
                    multipleJobBackgroundWorker.ReportProgress(i);
                }

                string location_data = Program.STATISTICS_DATA_DIRECTORY + "\\" +
                    DateTime.Now.ToString("yyyy-MM-dd") + " Данные к отчётам №" + idFirst + "-" + idLast + ".txt";
                f = File.Open(location_data, FileMode.Create);
                writer = new StreamWriter(f);
                for (int j = 0; j < linesOfData.Count; j++)
                    writer.WriteLine(linesOfData[j]);
                writer.Close();
                f.Close();

                zgcBackground.Invalidate();
                zgcBackground.AxisChange();
                zgcBackground.MasterPane.GetImage().Save(Program.STATISTICS_GRAPHS_DIRECTORY + "\\" +
                    DateTime.Now.ToString("yyyy-MM-dd") +
                    " График к отчётам №" + idFirst + "-" + idLast + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Произошла ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void multipleJobBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MakeStatus();
            начатьСборДанныхToolStripMenuItem.Enabled = true;
        }

        private void multipleJobBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MakeStatus("Статистических запусков проведено: " + e.ProgressPercentage);
        }

        private void остановитьСборДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            multipleJobBackgroundWorker.CancelAsync();
        }

        private void начатьСборДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            начатьСборДанныхToolStripMenuItem.Enabled = false;
            multipleJobBackgroundWorker.RunWorkerAsync();
            MakeStatus("Статистических запусков проведено: 0");
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog_XML.ShowDialog();
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog_XML.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string xml = Program.TaskCurrent.SerializeToXml();
            File.WriteAllText(saveFileDialog_XML.FileName, xml, Encoding.UTF8);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string xml = File.ReadAllText(openFileDialog_XML.FileName, Encoding.UTF8);
            Program.TaskCurrent = Task.DeserializeToObject(xml);
        }

        private void помехаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserControl(new UserControlBlur(), "Настройки помехи");
        }

        private void кодНаJavaScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserControl(new UserControlJsTarget(), "Код объекта оптимизации на JavaScript");
        }
    }
}
