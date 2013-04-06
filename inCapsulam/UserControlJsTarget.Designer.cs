namespace inCapsulam
{
    partial class UserControlJsTarget
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
            this.labelPrompt = new System.Windows.Forms.Label();
            this.textBoxJsCode = new System.Windows.Forms.TextBox();
            this.numericUpDownParamsCount = new System.Windows.Forms.NumericUpDown();
            this.labelParamsCount = new System.Windows.Forms.Label();
            this.maskedTextBoxParams = new System.Windows.Forms.MaskedTextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownParamsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPrompt
            // 
            this.labelPrompt.Location = new System.Drawing.Point(3, 0);
            this.labelPrompt.Name = "labelPrompt";
            this.labelPrompt.Size = new System.Drawing.Size(391, 31);
            this.labelPrompt.TabIndex = 0;
            this.labelPrompt.Text = "Код на JavaScript. Массив params содержит вещественные параметры, в result следуе" +
    "т заключить конечное значение.";
            // 
            // textBoxJsCode
            // 
            this.textBoxJsCode.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxJsCode.Location = new System.Drawing.Point(0, 34);
            this.textBoxJsCode.Multiline = true;
            this.textBoxJsCode.Name = "textBoxJsCode";
            this.textBoxJsCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxJsCode.Size = new System.Drawing.Size(394, 198);
            this.textBoxJsCode.TabIndex = 1;
            this.textBoxJsCode.Text = "result = 0; \r\nvar i;\r\nfor (i=0;i<params.length;i++) { \r\n   result = result + para" +
    "ms[i]*params[i];\r\n}";
            this.textBoxJsCode.TextChanged += new System.EventHandler(this.textBoxJsCode_TextChanged);
            // 
            // numericUpDownParamsCount
            // 
            this.numericUpDownParamsCount.Location = new System.Drawing.Point(152, 233);
            this.numericUpDownParamsCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownParamsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownParamsCount.Name = "numericUpDownParamsCount";
            this.numericUpDownParamsCount.Size = new System.Drawing.Size(52, 23);
            this.numericUpDownParamsCount.TabIndex = 2;
            this.numericUpDownParamsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownParamsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownParamsCount.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // labelParamsCount
            // 
            this.labelParamsCount.AutoSize = true;
            this.labelParamsCount.Location = new System.Drawing.Point(3, 235);
            this.labelParamsCount.Name = "labelParamsCount";
            this.labelParamsCount.Size = new System.Drawing.Size(144, 15);
            this.labelParamsCount.TabIndex = 3;
            this.labelParamsCount.Text = "Количество параметров:";
            // 
            // maskedTextBoxParams
            // 
            this.maskedTextBoxParams.Location = new System.Drawing.Point(210, 233);
            this.maskedTextBoxParams.Name = "maskedTextBoxParams";
            this.maskedTextBoxParams.Size = new System.Drawing.Size(184, 23);
            this.maskedTextBoxParams.TabIndex = 4;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(31, 262);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(129, 262);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 6;
            this.buttonTest.Text = "Проверить";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(210, 262);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.Size = new System.Drawing.Size(184, 23);
            this.textBoxResult.TabIndex = 7;
            // 
            // UserControlJsTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.maskedTextBoxParams);
            this.Controls.Add(this.labelParamsCount);
            this.Controls.Add(this.numericUpDownParamsCount);
            this.Controls.Add(this.textBoxJsCode);
            this.Controls.Add(this.labelPrompt);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "UserControlJsTarget";
            this.Size = new System.Drawing.Size(394, 292);
            this.Load += new System.EventHandler(this.UserControlJsTarget_Load);
            this.Resize += new System.EventHandler(this.UserControlJsTarget_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownParamsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPrompt;
        private System.Windows.Forms.TextBox textBoxJsCode;
        private System.Windows.Forms.NumericUpDown numericUpDownParamsCount;
        private System.Windows.Forms.Label labelParamsCount;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxParams;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.TextBox textBoxResult;
    }
}
