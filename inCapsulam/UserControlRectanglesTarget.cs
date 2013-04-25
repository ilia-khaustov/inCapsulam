using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using inCapsulam.Optimization;
using inCapsulam.Optimization.Targets;

namespace inCapsulam
{
    public partial class UserControlRectanglesTarget : UserControlEmpty
    {
        RectanglesTarget.Constraint_NoIntersection nic;

        Graphics graphics;
        System.Threading.Thread drawingThread;

        bool isDrawing = true;

        public UserControlRectanglesTarget()
        {
            InitializeComponent();
            UserControlRectanglesTarget_Resize(null, null);
            if (object.Equals(Program.TaskCurrent.Target, null) || object.Equals(Program.TaskCurrent.PointOfMinimum, null))
            {
                Program.TaskCurrent.Target = new RectanglesTarget();
                nic = new RectanglesTarget.Constraint_NoIntersection();
                nic.target = (RectanglesTarget)Program.TaskCurrent.Target;
                Program.TaskCurrent.Constraints = new BlackBox[1] { nic };
                Program.TaskCurrent.IsEquality = new bool[1];
            }
            else
            {
                RectanglesTarget target = (RectanglesTarget)Program.TaskCurrent.Target;
                nic = (RectanglesTarget.Constraint_NoIntersection)Program.TaskCurrent.Constraints[0];
            }
        }

        private void panelRectangles_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle r = new Rectangle();
            r.Location = e.Location;
            RectanglesTarget target = (RectanglesTarget)(Program.TaskCurrent.Target);
            if (object.Equals(target.Widths,null)) target.Widths = new double[1];
            else
            {
                double[] tempWidths = (double[])target.Widths.Clone();
                target.Widths = new double[target.Widths.Length + 1];
                for (int i = 0; i < tempWidths.Length; i++)
                {
                    target.Widths[i] = tempWidths[i];
                }
            }
            if (object.Equals(target.Heights,null)) target.Heights = new double[1];
            else
            {
                double[] tempHeights = (double[])target.Heights.Clone();
                target.Heights = new double[target.Heights.Length + 1];
                for (int i = 0; i < tempHeights.Length; i++)
                {
                    target.Heights[i] = tempHeights[i];
                }
            }
            if (object.Equals(Program.TaskCurrent.PointOfMinimum,null)) Program.TaskCurrent.PointOfMinimum = new double[2];
            else
            {
                double[] temp = (double[])Program.TaskCurrent.PointOfMinimum.Clone();
                Program.TaskCurrent.PointOfMinimum = new double[Program.TaskCurrent.PointOfMinimum.Length + 2];
                for (int i = 0; i < temp.Length; i++)
                {
                    Program.TaskCurrent.PointOfMinimum[i] = temp[i];
                }
            }
            int parametersCount = Program.TaskCurrent.PointOfMinimum.Length;
            nic.Parameters = new double[parametersCount];
            target.Parameters = new double[parametersCount];
            drawingThread = new System.Threading.Thread(this.drawingLoopback);
            drawingThread.Priority = System.Threading.ThreadPriority.Highest;
            drawingThread.Start(r);
        }

        void drawingLoopback(object num)
        {
            Rectangle r = (Rectangle)num;
            int i = 0;
            RectanglesTarget target = (RectanglesTarget)(Program.TaskCurrent.Target);
            double precision = 0.01;
            while (isDrawing)
            {
                r.Width = MousePosition.X - r.Location.X - this.Parent.Location.X - 20;
                r.Height = MousePosition.Y - r.Location.Y - this.Parent.Location.Y - 52;
                if (i == 1500)
                {
                    refreshRectangles();
                    i = 0;
                }
                i++;
                target.Widths[target.Widths.Length-1] = r.Width * precision;
                target.Heights[target.Heights.Length-1] = r.Height * precision;
                Program.TaskCurrent.PointOfMinimum[Program.TaskCurrent.PointOfMinimum.Length - 2] =
                    r.X * precision;
                Program.TaskCurrent.PointOfMinimum[Program.TaskCurrent.PointOfMinimum.Length - 1] =
                    (r.Y - r.Height) * precision ;
                graphics.FillRectangle(System.Drawing.Brushes.CornflowerBlue, r);
            }
        }

        private void panelRectangles_MouseUp(object sender, MouseEventArgs e)
        {
            drawingThread.Abort();
        }

        void refreshRectangles()
        {
            graphics.Clear(panelRectangles.BackColor);
            double precision = 0.01;
            RectanglesTarget target = (RectanglesTarget)(Program.TaskCurrent.Target);
            for (int i = 0; i < Program.TaskCurrent.PointOfMinimum.Length; i += 2)
            {
                Rectangle r = new Rectangle();
                double x = Program.TaskCurrent.PointOfMinimum[i];
                double y = Program.TaskCurrent.PointOfMinimum[i + 1];
                r.Location = new Point(
                    (int)(x / precision),
                    (int)((y + target.Heights[i / 2]) / precision));
                r.Height = (int)(target.Heights[i / 2] / precision);
                r.Width = (int)(target.Widths[i / 2] / precision);

                graphics.FillRectangle(System.Drawing.Brushes.CornflowerBlue, r);
            }
        }

        private void UserControlRectanglesTarget_Resize(object sender, EventArgs e)
        {
            graphics = panelRectangles.CreateGraphics();
            panelRectangles.Width = this.Width - 2;
            panelRectangles.Height = this.Height - 2;
        }

        private void panelRectangles_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelRectangles_Resize(object sender, EventArgs e)
        {
            refreshRectangles();
        }
    }
}
