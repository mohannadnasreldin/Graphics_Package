using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics_Package
{
    public partial class Form2 : Form
    {
        static Point centralPoint = new Point(300, 300);
        Point point1 = new Point(centralPoint.X + 50, centralPoint.Y - 50);
        Point point2 = new Point(centralPoint.X + 75, centralPoint.Y - 50);

        public Form2()
        {
            InitializeComponent();
            label2.Text = "P1.X: " + (point1.X - centralPoint.X) + "       P1.Y: " + (centralPoint.Y - point1.Y);
            label3.Text = "P2.X: " + (point2.X - centralPoint.X) + "       P2.Y: " + (centralPoint.Y - point2.Y);
        }

        private void Transformations_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;


            Pen bluePen = new Pen(Color.Blue, 2);

            Rectangle testShape = new Rectangle(450, 150, 50, 50);

            Pen pen = new Pen(Color.Black, 1);

            // Draw the x-axis
            e.Graphics.DrawLine(pen, 0, panel1.Height / 2, panel1.Width, panel1.Height / 2);

            // Draw the y-axis
            e.Graphics.DrawLine(pen, panel1.Width / 2, 0, panel1.Width / 2, panel1.Height);
            g.DrawLine(bluePen, point1, point2);


            //g.DrawRectangle(bluePen, testShape);
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            double x = Decimal.ToDouble(xUpDown.Value);
            double y = Decimal.ToDouble(yUpDown.Value);
            double angle = Decimal.ToDouble(angleUpDown.Value);
            double[] oldPoint1 = { point1.X - centralPoint.X, -1 * (point1.Y - centralPoint.Y), 1 };
            double[] oldPoint2 = { point2.X - centralPoint.X, -1 * (point2.Y - centralPoint.Y), 1 };
            double[] newPoint1;
            double[] newPoint2;

            if (rotationRd.Checked)
            {
                double[,] angleMatrix = MatrixOperations.MatrixRotation(angle);
                newPoint1 = MatrixOperations.MultiplyMatrix(angleMatrix, oldPoint1);
                newPoint2 = MatrixOperations.MultiplyMatrix(angleMatrix, oldPoint2);

                point1 = new Point(centralPoint.X + (int)Math.Round(newPoint1[0]), centralPoint.Y - (int)Math.Round(newPoint1[1]));
                point2 = new Point(centralPoint.X + (int)Math.Round(newPoint2[0]), centralPoint.Y - (int)Math.Round(newPoint2[1]));
            }
            else if (scaleRd.Checked)
            {
                double[,] scaleMatrix = MatrixOperations.MatrixScaling(x, y);
                newPoint1 = MatrixOperations.MultiplyMatrix(scaleMatrix, oldPoint1);
                newPoint2 = MatrixOperations.MultiplyMatrix(scaleMatrix, oldPoint2);


                point1 = new Point(centralPoint.X + (int)newPoint1[0], centralPoint.Y - (int)newPoint1[1]);
                point2 = new Point(centralPoint.X + (int)newPoint2[0], centralPoint.Y - (int)newPoint2[1]);
            }
            else if (translationRd.Checked)
            {

                double[,] translationMatrix = MatrixOperations.MatrixTranslation(x, y);
                newPoint1 = MatrixOperations.MultiplyMatrix(translationMatrix, oldPoint1);
                newPoint2 = MatrixOperations.MultiplyMatrix(translationMatrix, oldPoint2);

                point1 = new Point(centralPoint.X + (int)newPoint1[0], centralPoint.Y - (int)newPoint1[1]);
                point2 = new Point(centralPoint.X + (int)newPoint2[0], centralPoint.Y - (int)newPoint2[1]);
            }
            else if (shearingRd.Checked)
            {

                double[,] shearingMatrix = MatrixOperations.MatrixShearing(x, y);
                newPoint1 = MatrixOperations.MultiplyMatrix(shearingMatrix, oldPoint1);
                newPoint2 = MatrixOperations.MultiplyMatrix(shearingMatrix, oldPoint2);
                point1 = new Point(centralPoint.X + (int)newPoint1[0], centralPoint.Y - (int)newPoint1[1]);
                point2 = new Point(centralPoint.X + (int)newPoint2[0], centralPoint.Y - (int)newPoint2[1]);
            }
            else if (reflectionRd.Checked)
            {

                double[,] reflectionMatrix = MatrixOperations.MatrixReflection(reflectX.Checked, reflectY.Checked);
                newPoint1 = MatrixOperations.MultiplyMatrix(reflectionMatrix, oldPoint1);
                newPoint2 = MatrixOperations.MultiplyMatrix(reflectionMatrix, oldPoint2);
                point1 = new Point(centralPoint.X + (int)newPoint1[0], centralPoint.Y - (int)newPoint1[1]);
                point2 = new Point(centralPoint.X + (int)newPoint2[0], centralPoint.Y - (int)newPoint2[1]);
            }

            label2.Text = "P1.X: " + (point1.X - centralPoint.X) + "       P1.Y: " + (centralPoint.Y - point1.Y);
            label3.Text = "P2.X: " + (point2.X - centralPoint.X) + "       P2.Y: " + (centralPoint.Y - point2.Y);
            panel1.Invalidate();
        }

        private void rotationRd_CheckedChanged(object sender, EventArgs e)
        {
            xUpDown.Enabled = false;
            yUpDown.Enabled = false;
            angleUpDown.Enabled = true;
        }

        private void scaleRd_CheckedChanged(object sender, EventArgs e)
        {
            xUpDown.Enabled = true;
            yUpDown.Enabled = true;
            angleUpDown.Enabled = false;
        }

        private void translationRd_CheckedChanged(object sender, EventArgs e)
        {
            xUpDown.Enabled = true;
            yUpDown.Enabled = true;
            angleUpDown.Enabled = false;
        }
        private void reflectionRd_CheckedChanged(object sender, EventArgs e)
        {
            xUpDown.Enabled = false;
            yUpDown.Enabled = false;
            angleUpDown.Enabled = false;

        }

        private void shearingRd_CheckedChanged(object sender, EventArgs e)
        {
            xUpDown.Enabled = true;
            yUpDown.Enabled = true;
            angleUpDown.Enabled = false;
        }
    }
}
