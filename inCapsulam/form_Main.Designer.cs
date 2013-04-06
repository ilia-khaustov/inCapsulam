namespace inCapsulam
{
    partial class form_Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip_Main = new System.Windows.Forms.MenuStrip();
            this.задачаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выбратьФункциюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ввестиФункциюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ограниченияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.помехаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритмToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.базовыеНастройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.постоптимизацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьКонфигурациюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запусковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запусковToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.запусковToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.запусковToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКонфигурацийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьСборДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.остановитьСборДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.решитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleJobBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.multipleJobBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip_Main = new System.Windows.Forms.StatusStrip();
            this.processesStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog_XML = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_XML = new System.Windows.Forms.SaveFileDialog();
            this.userControlDefault = new inCapsulam.UserControlEmpty();
            this.кодНаJavaScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_Main.SuspendLayout();
            this.statusStrip_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_Main
            // 
            this.menuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.задачаToolStripMenuItem,
            this.алгоритмToolStripMenuItem,
            this.статистикаToolStripMenuItem,
            this.решитьToolStripMenuItem});
            this.menuStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_Main.Name = "menuStrip_Main";
            this.menuStrip_Main.Size = new System.Drawing.Size(624, 24);
            this.menuStrip_Main.TabIndex = 0;
            this.menuStrip_Main.Text = "menuStrip1";
            // 
            // задачаToolStripMenuItem
            // 
            this.задачаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem,
            this.toolStripSeparator1,
            this.выбратьФункциюToolStripMenuItem,
            this.ввестиФункциюToolStripMenuItem,
            this.кодНаJavaScriptToolStripMenuItem,
            this.toolStripSeparator2,
            this.ограниченияToolStripMenuItem,
            this.toolStripSeparator3,
            this.помехаToolStripMenuItem});
            this.задачаToolStripMenuItem.Name = "задачаToolStripMenuItem";
            this.задачаToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.задачаToolStripMenuItem.Text = "Задача";
            // 
            // новаяToolStripMenuItem
            // 
            this.новаяToolStripMenuItem.Name = "новаяToolStripMenuItem";
            this.новаяToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.новаяToolStripMenuItem.Text = "Новая";
            this.новаяToolStripMenuItem.Click += new System.EventHandler(this.новаяToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            this.toolStripSeparator1.Tag = "";
            // 
            // выбратьФункциюToolStripMenuItem
            // 
            this.выбратьФункциюToolStripMenuItem.Name = "выбратьФункциюToolStripMenuItem";
            this.выбратьФункциюToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.выбратьФункциюToolStripMenuItem.Text = "Выбрать функцию";
            this.выбратьФункциюToolStripMenuItem.Click += new System.EventHandler(this.выбратьФункциюToolStripMenuItem_Click);
            // 
            // ввестиФункциюToolStripMenuItem
            // 
            this.ввестиФункциюToolStripMenuItem.Name = "ввестиФункциюToolStripMenuItem";
            this.ввестиФункциюToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.ввестиФункциюToolStripMenuItem.Text = "Ввести функцию";
            this.ввестиФункциюToolStripMenuItem.Click += new System.EventHandler(this.ввестиФункциюToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(173, 6);
            // 
            // ограниченияToolStripMenuItem
            // 
            this.ограниченияToolStripMenuItem.Name = "ограниченияToolStripMenuItem";
            this.ограниченияToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.ограниченияToolStripMenuItem.Text = "Ограничения";
            this.ограниченияToolStripMenuItem.Click += new System.EventHandler(this.ограниченияToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(173, 6);
            // 
            // помехаToolStripMenuItem
            // 
            this.помехаToolStripMenuItem.Name = "помехаToolStripMenuItem";
            this.помехаToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.помехаToolStripMenuItem.Text = "Помеха";
            this.помехаToolStripMenuItem.Click += new System.EventHandler(this.помехаToolStripMenuItem_Click);
            // 
            // алгоритмToolStripMenuItem
            // 
            this.алгоритмToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.базовыеНастройкиToolStripMenuItem,
            this.постоптимизацияToolStripMenuItem});
            this.алгоритмToolStripMenuItem.Name = "алгоритмToolStripMenuItem";
            this.алгоритмToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.алгоритмToolStripMenuItem.Text = "Алгоритм";
            // 
            // базовыеНастройкиToolStripMenuItem
            // 
            this.базовыеНастройкиToolStripMenuItem.Name = "базовыеНастройкиToolStripMenuItem";
            this.базовыеНастройкиToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.базовыеНастройкиToolStripMenuItem.Text = "Базовые настройки";
            this.базовыеНастройкиToolStripMenuItem.Click += new System.EventHandler(this.базовыеНастройкиToolStripMenuItem_Click);
            // 
            // постоптимизацияToolStripMenuItem
            // 
            this.постоптимизацияToolStripMenuItem.Name = "постоптимизацияToolStripMenuItem";
            this.постоптимизацияToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.постоптимизацияToolStripMenuItem.Text = "Пост-оптимизация";
            this.постоптимизацияToolStripMenuItem.Click += new System.EventHandler(this.постоптимизацияToolStripMenuItem_Click);
            // 
            // статистикаToolStripMenuItem
            // 
            this.статистикаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьКонфигурациюToolStripMenuItem,
            this.списокКонфигурацийToolStripMenuItem,
            this.начатьСборДанныхToolStripMenuItem,
            this.остановитьСборДанныхToolStripMenuItem});
            this.статистикаToolStripMenuItem.Name = "статистикаToolStripMenuItem";
            this.статистикаToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.статистикаToolStripMenuItem.Text = "Статистика";
            // 
            // добавитьКонфигурациюToolStripMenuItem
            // 
            this.добавитьКонфигурациюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.запусковToolStripMenuItem,
            this.запусковToolStripMenuItem1,
            this.запусковToolStripMenuItem2,
            this.запусковToolStripMenuItem3});
            this.добавитьКонфигурациюToolStripMenuItem.Name = "добавитьКонфигурациюToolStripMenuItem";
            this.добавитьКонфигурациюToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.добавитьКонфигурациюToolStripMenuItem.Text = "Добавить конфигурацию";
            // 
            // запусковToolStripMenuItem
            // 
            this.запусковToolStripMenuItem.Name = "запусковToolStripMenuItem";
            this.запусковToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.запусковToolStripMenuItem.Text = "10 запусков";
            this.запусковToolStripMenuItem.Click += new System.EventHandler(this.запусковToolStripMenuItem_Click);
            // 
            // запусковToolStripMenuItem1
            // 
            this.запусковToolStripMenuItem1.Name = "запусковToolStripMenuItem1";
            this.запусковToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.запусковToolStripMenuItem1.Text = "100 запусков";
            this.запусковToolStripMenuItem1.Click += new System.EventHandler(this.запусковToolStripMenuItem1_Click);
            // 
            // запусковToolStripMenuItem2
            // 
            this.запусковToolStripMenuItem2.Name = "запусковToolStripMenuItem2";
            this.запусковToolStripMenuItem2.Size = new System.Drawing.Size(144, 22);
            this.запусковToolStripMenuItem2.Text = "200 запусков";
            this.запусковToolStripMenuItem2.Click += new System.EventHandler(this.запусковToolStripMenuItem2_Click);
            // 
            // запусковToolStripMenuItem3
            // 
            this.запусковToolStripMenuItem3.Name = "запусковToolStripMenuItem3";
            this.запусковToolStripMenuItem3.Size = new System.Drawing.Size(144, 22);
            this.запусковToolStripMenuItem3.Text = "500 запусков";
            this.запусковToolStripMenuItem3.Click += new System.EventHandler(this.запусковToolStripMenuItem3_Click);
            // 
            // списокКонфигурацийToolStripMenuItem
            // 
            this.списокКонфигурацийToolStripMenuItem.Name = "списокКонфигурацийToolStripMenuItem";
            this.списокКонфигурацийToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.списокКонфигурацийToolStripMenuItem.Text = "Список конфигураций";
            this.списокКонфигурацийToolStripMenuItem.Click += new System.EventHandler(this.списокКонфигурацийToolStripMenuItem_Click);
            // 
            // начатьСборДанныхToolStripMenuItem
            // 
            this.начатьСборДанныхToolStripMenuItem.Name = "начатьСборДанныхToolStripMenuItem";
            this.начатьСборДанныхToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.начатьСборДанныхToolStripMenuItem.Text = "Начать сбор данных";
            this.начатьСборДанныхToolStripMenuItem.Click += new System.EventHandler(this.начатьСборДанныхToolStripMenuItem_Click);
            // 
            // остановитьСборДанныхToolStripMenuItem
            // 
            this.остановитьСборДанныхToolStripMenuItem.Name = "остановитьСборДанныхToolStripMenuItem";
            this.остановитьСборДанныхToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.остановитьСборДанныхToolStripMenuItem.Text = "Остановить сбор данных";
            this.остановитьСборДанныхToolStripMenuItem.Click += new System.EventHandler(this.остановитьСборДанныхToolStripMenuItem_Click);
            // 
            // решитьToolStripMenuItem
            // 
            this.решитьToolStripMenuItem.Name = "решитьToolStripMenuItem";
            this.решитьToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.решитьToolStripMenuItem.Text = "Решить...";
            this.решитьToolStripMenuItem.Click += new System.EventHandler(this.решитьToolStripMenuItem_Click);
            // 
            // singleJobBackgroundWorker
            // 
            this.singleJobBackgroundWorker.WorkerSupportsCancellation = true;
            this.singleJobBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.singleJobBackgroundWorker_DoWork);
            this.singleJobBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.singleJobBackgroundWorker_RunWorkerCompleted);
            // 
            // multipleJobBackgroundWorker
            // 
            this.multipleJobBackgroundWorker.WorkerReportsProgress = true;
            this.multipleJobBackgroundWorker.WorkerSupportsCancellation = true;
            this.multipleJobBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.multipleJobBackgroundWorker_DoWork);
            this.multipleJobBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.multipleJobBackgroundWorker_ProgressChanged);
            this.multipleJobBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.multipleJobBackgroundWorker_RunWorkerCompleted);
            // 
            // statusStrip_Main
            // 
            this.statusStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processesStatusLabel});
            this.statusStrip_Main.Location = new System.Drawing.Point(0, 529);
            this.statusStrip_Main.Name = "statusStrip_Main";
            this.statusStrip_Main.Size = new System.Drawing.Size(624, 22);
            this.statusStrip_Main.TabIndex = 2;
            this.statusStrip_Main.TabStop = true;
            this.statusStrip_Main.Text = "statusStrip_Main";
            // 
            // processesStatusLabel
            // 
            this.processesStatusLabel.Name = "processesStatusLabel";
            this.processesStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // openFileDialog_XML
            // 
            this.openFileDialog_XML.DefaultExt = "xml";
            this.openFileDialog_XML.Filter = "XML-файлы (*.xml)|*.xml";
            this.openFileDialog_XML.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog_XML
            // 
            this.saveFileDialog_XML.DefaultExt = "xml";
            this.saveFileDialog_XML.Filter = "XML-файлы (*.xml)|*.xml";
            this.saveFileDialog_XML.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // userControlDefault
            // 
            this.userControlDefault.BackColor = System.Drawing.SystemColors.Control;
            this.userControlDefault.Location = new System.Drawing.Point(12, 27);
            this.userControlDefault.Name = "userControlDefault";
            this.userControlDefault.Size = new System.Drawing.Size(473, 424);
            this.userControlDefault.TabIndex = 1;
            // 
            // кодНаJavaScriptToolStripMenuItem
            // 
            this.кодНаJavaScriptToolStripMenuItem.Name = "кодНаJavaScriptToolStripMenuItem";
            this.кодНаJavaScriptToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.кодНаJavaScriptToolStripMenuItem.Text = "Код на JavaScript";
            this.кодНаJavaScriptToolStripMenuItem.Click += new System.EventHandler(this.кодНаJavaScriptToolStripMenuItem_Click);
            // 
            // form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 551);
            this.Controls.Add(this.statusStrip_Main);
            this.Controls.Add(this.userControlDefault);
            this.Controls.Add(this.menuStrip_Main);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip_Main;
            this.Name = "form_Main";
            this.Text = "inCapsulam";
            this.Resize += new System.EventHandler(this.form_Main_Resize);
            this.menuStrip_Main.ResumeLayout(false);
            this.menuStrip_Main.PerformLayout();
            this.statusStrip_Main.ResumeLayout(false);
            this.statusStrip_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem задачаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьФункциюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ввестиФункциюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритмToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem базовыеНастройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem постоптимизацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистикаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьКонфигурациюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запусковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запусковToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem запусковToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem запусковToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem списокКонфигурацийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem начатьСборДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem остановитьСборДанныхToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker singleJobBackgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem ограниченияToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker multipleJobBackgroundWorker;
        private UserControlEmpty userControlDefault;
        private System.Windows.Forms.ToolStripMenuItem решитьToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip_Main;
        private System.Windows.Forms.ToolStripStatusLabel processesStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.OpenFileDialog openFileDialog_XML;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_XML;
        private System.Windows.Forms.ToolStripMenuItem помехаToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem кодНаJavaScriptToolStripMenuItem;
    }
}

