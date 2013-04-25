namespace inCapsulam
{
    partial class UserControlRectanglesTarget
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
            this.panelRectangles = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelRectangles
            // 
            this.panelRectangles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelRectangles.Location = new System.Drawing.Point(3, 3);
            this.panelRectangles.Name = "panelRectangles";
            this.panelRectangles.Size = new System.Drawing.Size(611, 432);
            this.panelRectangles.TabIndex = 3;
            this.panelRectangles.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRectangles_Paint);
            this.panelRectangles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelRectangles_MouseDown);
            this.panelRectangles.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelRectangles_MouseUp);
            this.panelRectangles.Resize += new System.EventHandler(this.panelRectangles_Resize);
            // 
            // UserControlRectanglesTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelRectangles);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "UserControlRectanglesTarget";
            this.Size = new System.Drawing.Size(617, 438);
            this.Resize += new System.EventHandler(this.UserControlRectanglesTarget_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRectangles;
    }
}
