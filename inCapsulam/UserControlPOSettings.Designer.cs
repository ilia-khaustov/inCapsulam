namespace inCapsulam
{
    partial class UserControlPOSettings
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
            this.saveButton = new System.Windows.Forms.Button();
            this.coefficient = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.mode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.coefficient)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(97, 61);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(82, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // coefficient
            // 
            this.coefficient.DecimalPlaces = 3;
            this.coefficient.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.coefficient.Location = new System.Drawing.Point(97, 32);
            this.coefficient.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.coefficient.Name = "coefficient";
            this.coefficient.Size = new System.Drawing.Size(82, 23);
            this.coefficient.TabIndex = 3;
            this.coefficient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Коэффициент:";
            // 
            // mode
            // 
            this.mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mode.FormattingEnabled = true;
            this.mode.Items.AddRange(new object[] {
            "Одношаговый метод",
            "Многошаговый метод"});
            this.mode.Location = new System.Drawing.Point(97, 3);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(245, 23);
            this.mode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Алгоритм:";
            // 
            // UserControlPOSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.coefficient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mode);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "UserControlPOSettings";
            this.Size = new System.Drawing.Size(345, 298);
            ((System.ComponentModel.ISupportInitialize)(this.coefficient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox mode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown coefficient;
        private System.Windows.Forms.Button saveButton;
    }
}
