namespace inCapsulam
{
    partial class UserControlPredefinedTarget
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
            this.variablesCountSpin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.functionsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.variablesCountSpin)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(0, 91);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // variablesCountSpin
            // 
            this.variablesCountSpin.Location = new System.Drawing.Point(0, 62);
            this.variablesCountSpin.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.variablesCountSpin.Name = "variablesCountSpin";
            this.variablesCountSpin.Size = new System.Drawing.Size(75, 23);
            this.variablesCountSpin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Количество переменных:";
            // 
            // functionsComboBox
            // 
            this.functionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functionsComboBox.FormattingEnabled = true;
            this.functionsComboBox.Items.AddRange(new object[] {
            "Парабола",
            "Функция Растригина",
            "Функция Швейфеля",
            "Функция \"Сомбреро\"",
            "Функция Гривонка",
            "Функция Розенброка",
            "Парабола с задержкой"});
            this.functionsComboBox.Location = new System.Drawing.Point(0, 18);
            this.functionsComboBox.Name = "functionsComboBox";
            this.functionsComboBox.Size = new System.Drawing.Size(283, 23);
            this.functionsComboBox.TabIndex = 1;
            this.functionsComboBox.SelectedIndexChanged += new System.EventHandler(this.functionsComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Функция:";
            // 
            // UserControlPredefinedTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.variablesCountSpin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.functionsComboBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "UserControlPredefinedTarget";
            this.Size = new System.Drawing.Size(283, 252);
            this.Resize += new System.EventHandler(this.UserControlPredefinedTarget_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.variablesCountSpin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox functionsComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown variablesCountSpin;
        private System.Windows.Forms.Button saveButton;
    }
}
