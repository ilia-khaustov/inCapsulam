namespace inCapsulam
{
    partial class UserControlSingleResult
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControlDefault = new System.Windows.Forms.TabControl();
            this.tabPageCommon = new System.Windows.Forms.TabPage();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.buttonSaveToFile = new System.Windows.Forms.Button();
            this.resultRichTextBox = new System.Windows.Forms.RichTextBox();
            this.tabPageGraphFitness = new System.Windows.Forms.TabPage();
            this.showWorst = new System.Windows.Forms.CheckBox();
            this.showAverage = new System.Windows.Forms.CheckBox();
            this.showBest = new System.Windows.Forms.CheckBox();
            this.fitnessGraph = new ZedGraph.ZedGraphControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.generationNumber = new System.Windows.Forms.HScrollBar();
            this.valueGraph = new ZedGraph.ZedGraphControl();
            this.tabControlDefault.SuspendLayout();
            this.tabPageCommon.SuspendLayout();
            this.tabPageGraphFitness.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlDefault
            // 
            this.tabControlDefault.Controls.Add(this.tabPageCommon);
            this.tabControlDefault.Controls.Add(this.tabPageGraphFitness);
            this.tabControlDefault.Controls.Add(this.tabPage1);
            this.tabControlDefault.Location = new System.Drawing.Point(3, 3);
            this.tabControlDefault.Name = "tabControlDefault";
            this.tabControlDefault.SelectedIndex = 0;
            this.tabControlDefault.Size = new System.Drawing.Size(476, 367);
            this.tabControlDefault.TabIndex = 0;
            // 
            // tabPageCommon
            // 
            this.tabPageCommon.Controls.Add(this.textBoxLocation);
            this.tabPageCommon.Controls.Add(this.buttonSaveToFile);
            this.tabPageCommon.Controls.Add(this.resultRichTextBox);
            this.tabPageCommon.Location = new System.Drawing.Point(4, 24);
            this.tabPageCommon.Name = "tabPageCommon";
            this.tabPageCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCommon.Size = new System.Drawing.Size(468, 339);
            this.tabPageCommon.TabIndex = 0;
            this.tabPageCommon.Text = "Общий результат";
            this.tabPageCommon.UseVisualStyleBackColor = true;
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(85, 310);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(377, 23);
            this.textBoxLocation.TabIndex = 2;
            // 
            // buttonSaveToFile
            // 
            this.buttonSaveToFile.Location = new System.Drawing.Point(4, 309);
            this.buttonSaveToFile.Name = "buttonSaveToFile";
            this.buttonSaveToFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveToFile.TabIndex = 1;
            this.buttonSaveToFile.Text = "Сохранить";
            this.buttonSaveToFile.UseVisualStyleBackColor = true;
            this.buttonSaveToFile.Click += new System.EventHandler(this.buttonSaveToFile_Click);
            // 
            // resultRichTextBox
            // 
            this.resultRichTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.resultRichTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultRichTextBox.Location = new System.Drawing.Point(6, 6);
            this.resultRichTextBox.Name = "resultRichTextBox";
            this.resultRichTextBox.ReadOnly = true;
            this.resultRichTextBox.Size = new System.Drawing.Size(456, 297);
            this.resultRichTextBox.TabIndex = 0;
            this.resultRichTextBox.Text = "";
            // 
            // tabPageGraphFitness
            // 
            this.tabPageGraphFitness.Controls.Add(this.showWorst);
            this.tabPageGraphFitness.Controls.Add(this.showAverage);
            this.tabPageGraphFitness.Controls.Add(this.showBest);
            this.tabPageGraphFitness.Controls.Add(this.fitnessGraph);
            this.tabPageGraphFitness.Location = new System.Drawing.Point(4, 24);
            this.tabPageGraphFitness.Name = "tabPageGraphFitness";
            this.tabPageGraphFitness.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGraphFitness.Size = new System.Drawing.Size(468, 339);
            this.tabPageGraphFitness.TabIndex = 1;
            this.tabPageGraphFitness.Text = "Графики пригодности";
            this.tabPageGraphFitness.UseVisualStyleBackColor = true;
            // 
            // showWorst
            // 
            this.showWorst.AutoSize = true;
            this.showWorst.Location = new System.Drawing.Point(161, 6);
            this.showWorst.Name = "showWorst";
            this.showWorst.Size = new System.Drawing.Size(69, 19);
            this.showWorst.TabIndex = 3;
            this.showWorst.Text = "Худшие";
            this.showWorst.UseVisualStyleBackColor = true;
            this.showWorst.CheckedChanged += new System.EventHandler(this.showWorst_CheckedChanged);
            // 
            // showAverage
            // 
            this.showAverage.AutoSize = true;
            this.showAverage.Location = new System.Drawing.Point(82, 6);
            this.showAverage.Name = "showAverage";
            this.showAverage.Size = new System.Drawing.Size(73, 19);
            this.showAverage.TabIndex = 2;
            this.showAverage.Text = "Средние";
            this.showAverage.UseVisualStyleBackColor = true;
            this.showAverage.CheckedChanged += new System.EventHandler(this.showAverage_CheckedChanged);
            // 
            // showBest
            // 
            this.showBest.AutoSize = true;
            this.showBest.Location = new System.Drawing.Point(6, 6);
            this.showBest.Name = "showBest";
            this.showBest.Size = new System.Drawing.Size(70, 19);
            this.showBest.TabIndex = 1;
            this.showBest.Text = "Лучшее";
            this.showBest.UseVisualStyleBackColor = true;
            this.showBest.CheckedChanged += new System.EventHandler(this.showBest_CheckedChanged);
            // 
            // fitnessGraph
            // 
            this.fitnessGraph.IsAutoScrollRange = true;
            this.fitnessGraph.Location = new System.Drawing.Point(6, 31);
            this.fitnessGraph.Name = "fitnessGraph";
            this.fitnessGraph.ScrollGrace = 0D;
            this.fitnessGraph.ScrollMaxX = 0D;
            this.fitnessGraph.ScrollMaxY = 0D;
            this.fitnessGraph.ScrollMaxY2 = 0D;
            this.fitnessGraph.ScrollMinX = 0D;
            this.fitnessGraph.ScrollMinY = 0D;
            this.fitnessGraph.ScrollMinY2 = 0D;
            this.fitnessGraph.Size = new System.Drawing.Size(456, 302);
            this.fitnessGraph.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.generationNumber);
            this.tabPage1.Controls.Add(this.valueGraph);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(468, 339);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Графики значений";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // generationNumber
            // 
            this.generationNumber.Location = new System.Drawing.Point(6, 3);
            this.generationNumber.Maximum = 1000;
            this.generationNumber.Name = "generationNumber";
            this.generationNumber.Size = new System.Drawing.Size(456, 16);
            this.generationNumber.TabIndex = 1;
            this.generationNumber.Scroll += new System.Windows.Forms.ScrollEventHandler(this.generationNumber_Scroll);
            // 
            // valueGraph
            // 
            this.valueGraph.Location = new System.Drawing.Point(6, 22);
            this.valueGraph.Name = "valueGraph";
            this.valueGraph.ScrollGrace = 0D;
            this.valueGraph.ScrollMaxX = 0D;
            this.valueGraph.ScrollMaxY = 0D;
            this.valueGraph.ScrollMaxY2 = 0D;
            this.valueGraph.ScrollMinX = 0D;
            this.valueGraph.ScrollMinY = 0D;
            this.valueGraph.ScrollMinY2 = 0D;
            this.valueGraph.Size = new System.Drawing.Size(456, 311);
            this.valueGraph.TabIndex = 0;
            // 
            // UserControlSingleResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlDefault);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "UserControlSingleResult";
            this.Size = new System.Drawing.Size(482, 373);
            this.Resize += new System.EventHandler(this.UserControlSingleResult_Resize);
            this.tabControlDefault.ResumeLayout(false);
            this.tabPageCommon.ResumeLayout(false);
            this.tabPageCommon.PerformLayout();
            this.tabPageGraphFitness.ResumeLayout(false);
            this.tabPageGraphFitness.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlDefault;
        private System.Windows.Forms.TabPage tabPageCommon;
        private System.Windows.Forms.TabPage tabPageGraphFitness;
        private System.Windows.Forms.RichTextBox resultRichTextBox;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.Button buttonSaveToFile;
        private ZedGraph.ZedGraphControl fitnessGraph;
        private System.Windows.Forms.CheckBox showWorst;
        private System.Windows.Forms.CheckBox showAverage;
        private System.Windows.Forms.CheckBox showBest;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.HScrollBar generationNumber;
        private ZedGraph.ZedGraphControl valueGraph;
    }
}
