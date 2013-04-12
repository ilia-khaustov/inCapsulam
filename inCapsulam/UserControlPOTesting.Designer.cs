namespace inCapsulam
{
    partial class UserControlPOTesting
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
            this.buttonTest = new System.Windows.Forms.Button();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.textBoxSamples = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(0, 297);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 3;
            this.buttonTest.Text = "Тест";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Location = new System.Drawing.Point(0, 326);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ReadOnly = true;
            this.textBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInfo.Size = new System.Drawing.Size(416, 80);
            this.textBoxInfo.TabIndex = 2;
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(208, 0);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResult.Size = new System.Drawing.Size(208, 291);
            this.textBoxResult.TabIndex = 1;
            // 
            // textBoxSamples
            // 
            this.textBoxSamples.Location = new System.Drawing.Point(0, 0);
            this.textBoxSamples.Multiline = true;
            this.textBoxSamples.Name = "textBoxSamples";
            this.textBoxSamples.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSamples.Size = new System.Drawing.Size(202, 291);
            this.textBoxSamples.TabIndex = 0;
            // 
            // UserControlPOTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.textBoxSamples);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "UserControlPOTesting";
            this.Size = new System.Drawing.Size(416, 409);
            this.Load += new System.EventHandler(this.UserControlPOTesting_Load);
            this.Resize += new System.EventHandler(this.UserControlPOTesting_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSamples;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Button buttonTest;
    }
}
