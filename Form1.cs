using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_Package
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Set the pen color and width
            Pen pen = new Pen(Color.Black, 1);

            // Draw the x-axis
            e.Graphics.DrawLine(pen, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);

            // Draw the y-axis
            e.Graphics.DrawLine(pen, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> xReal = new List<double>(), yReal = new List<double>();
            List<int> xToPrint = new List<int>(), yToPrint = new List<int>();
            var ddabrush = Brushes.Black;
            Graphics g = pictureBox1.CreateGraphics();
            int w = pictureBox1.ClientSize.Width;
            int h = pictureBox1.ClientSize.Height;

            int x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox2.Text);

            int x2 = int.Parse(textBox3.Text);
            int y2 = int.Parse(textBox4.Text);

            int dx = x2 - x1, dy = y2 - y1, steps, k;
            float xIncrement, yIncrement, x = x1, y = y1;

            if (Math.Abs(dx) > Math.Abs(dy))
                steps = Math.Abs(dx);
            else
                steps = Math.Abs(dy);

            xIncrement = (float)dx / (float)steps;
            yIncrement = (float)dy / (float)steps;
            xReal.Add(x);
            yReal.Add(y);
            xToPrint.Add((int)Math.Round(x));
            yToPrint.Add((int)Math.Round(y));
            for (k = 0; k < steps; k++)
            {
                g.FillRectangle(ddabrush, x + w / 2, -y + h / 2, 1, 1);

                x += xIncrement;
                y += yIncrement;
                xReal.Add(x);
                yReal.Add(y);
                xToPrint.Add((int)Math.Round(x));
                yToPrint.Add((int)Math.Round(y));
            }

            // Show the SaveFileDialog
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "HTML File|*.html";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Build the HTML string using the selected file path
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" <style>\r\n            *{\r\n                text-align: center\r\n            }\r\n            table {\r\n                font-family: arial, sans-serif;\r\n                border-collapse: collapse;\r\n                width: 100%;\r\n            }\r\n            td, th {\r\n                border: 1px solid #dddddd;\r\n                padding: 8px;\r\n            }\r\n            tr:nth-child(even) {\r\n                \r\n            }\r\n        </style>");
                sb.AppendLine("<table>");
                sb.AppendLine("<tr><th>k</th><th>X</th><th>Y</th><th>(X, Y)</th></tr>");
                for (int i = 1; i < xToPrint.Count; i++)
                {
                    sb.AppendLine(
                        $"<tr>" +
                            $"<td>{(i - 1).ToString()}</td> " +
                            $"<td>{xReal[i].ToString("#.##")}</td>" +
                            $"<td>{yReal[i].ToString("#.##")}</td>" +
                            $"<td>({xToPrint[i]}, {yToPrint[i]})</td>" +
                        "</tr>");
                }
                sb.AppendLine("</table>");

                // Save the HTML string to the selected file path
                File.WriteAllText(saveFileDialog1.FileName, sb.ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var brush = Brushes.Black;
            Graphics g = pictureBox1.CreateGraphics();
            int w = pictureBox1.ClientSize.Width;
            int h = pictureBox1.ClientSize.Height;
            List<int> xToPrint = new List<int>(), yToPrint = new List<int>();
            List<int> pk = new List<int>();
            int x0 = int.Parse(textBox1.Text);
            int y0 = int.Parse(textBox2.Text);
            int xe = int.Parse(textBox3.Text);
            int ye = int.Parse(textBox4.Text);
            int temp;
            int dx, dy;
            int p;
            int twoDy, twoDyMinusDx;
            double m = (double)(ye - y0) / (xe - x0);
            if (m >= 0 && m <= 1 && x0 < xe)
            {
                dx = xe - x0;
                dy = ye - y0;
                p = 2 * dy - dx;
                twoDy = 2 * dy;
                twoDyMinusDx = 2 * (dy - dx);
                pk.Add(p);
                xToPrint.Add(x0);
                yToPrint.Add(y0);


                while (x0 < xe)
                {
                    x0++;
                    if (p < 0)
                        p += twoDy;
                    else
                    {
                        y0++;
                        p += twoDyMinusDx;
                    }
                    pk.Add(p);
                    xToPrint.Add(x0);
                    yToPrint.Add(y0);
                    g.FillRectangle(brush, x0 + w / 2, -y0 + h / 2, 1, 1);
                }
            }
            else if (m > 1 && y0 < ye)
            {

                temp = x0;
                x0 = y0;
                y0 = temp;
                temp = xe;
                xe = ye;
                ye = temp;
                dx = xe - x0;
                dy = ye - y0;
                p = 2 * dy - dx;
                twoDy = 2 * dy;
                twoDyMinusDx = 2 * (dy - dx);
                pk.Add(p);
                xToPrint.Add(y0);
                yToPrint.Add(x0);


                while (x0 < xe)
                {
                    x0++;
                    if (p < 0)
                        p += twoDy;
                    else
                    {
                        y0++;
                        p += twoDyMinusDx;
                    }
                    pk.Add(p);
                    xToPrint.Add(y0);
                    yToPrint.Add(x0);
                    g.FillRectangle(brush, y0 + w / 2, -x0 + h / 2, 1, 1);
                }
            }
            else if (m < -1 && y0 < ye)
            {

                temp = x0;
                x0 = y0;
                y0 = temp;
                temp = xe;
                xe = ye;
                ye = temp;
                dx = xe - x0;
                dy = -(ye - y0);
                p = 2 * dy - dx;
                twoDy = 2 * dy;
                twoDyMinusDx = 2 * (dy - dx);
                pk.Add(p);
                xToPrint.Add(y0);
                yToPrint.Add(x0);


                while (x0 < xe)
                {
                    x0++;
                    if (p < 0)
                        p += twoDy;
                    else
                    {
                        y0--;
                        p += twoDyMinusDx;
                    }
                    pk.Add(p);
                    xToPrint.Add(y0);
                    yToPrint.Add(x0);
                    g.FillRectangle(brush, y0 + w / 2, -x0 + h / 2, 2, 2);
                }
            }
            else if (m <= 0 && m >= -1 && xe < x0)
            {
                dx = -(xe - x0);
                dy = ye - y0;
                p = 2 * dy - dx;
                twoDy = 2 * dy;
                twoDyMinusDx = 2 * (dy - dx);
                pk.Add(p);
                xToPrint.Add(x0);
                yToPrint.Add(y0);


                while (x0 > xe)
                {
                    x0--;
                    if (p < 0)
                        p += twoDy;
                    else
                    {
                        y0++;
                        p += twoDyMinusDx;
                    }
                    pk.Add(p);
                    xToPrint.Add(x0);
                    yToPrint.Add(y0);
                    g.FillRectangle(brush, x0 + w / 2, -y0 + h / 2, 1, 1);
                }
            }
            else if (m > 0 && m <= 1 && xe < x0)
            {
                dx = -(xe - x0);
                dy = -(ye - y0);
                p = 2 * dy - dx;
                twoDy = 2 * dy;
                twoDyMinusDx = 2 * (dy - dx);
                pk.Add(p);
                xToPrint.Add(x0);
                yToPrint.Add(y0);


                while (x0 > xe)
                {
                    x0--;
                    if (p < 0)
                        p += twoDy;
                    else
                    {
                        y0--;
                        p += twoDyMinusDx;
                    }
                    pk.Add(p);
                    xToPrint.Add(x0);
                    yToPrint.Add(y0);
                    g.FillRectangle(brush, x0 + w / 2, -y0 + h / 2, 1, 1);
                }
            }
            else if (m > 1 && ye < y0)
            {

                temp = x0;
                x0 = y0;
                y0 = temp;
                temp = xe;
                xe = ye;
                ye = temp;
                dx = -(xe - x0);
                dy = -(ye - y0);
                p = 2 * dy - dx;
                twoDy = 2 * dy;
                twoDyMinusDx = 2 * (dy - dx);
                pk.Add(p);
                xToPrint.Add(y0);
                yToPrint.Add(x0);


                while (x0 > xe)
                {
                    x0--;
                    if (p < 0)
                        p += twoDy;
                    else
                    {
                        y0--;
                        p += twoDyMinusDx;
                    }
                    pk.Add(p);
                    xToPrint.Add(y0);
                    yToPrint.Add(x0);
                    g.FillRectangle(brush, y0 + w / 2, -x0 + h / 2, 2, 2);
                }
            }
            else if (m < -1 && ye < y0)
            {

                temp = x0;
                x0 = y0;
                y0 = temp;
                temp = xe;
                xe = ye;
                ye = temp;
                dx = -(xe - x0);
                dy = ye - y0;
                p = 2 * dy - dx;
                twoDy = 2 * dy;
                twoDyMinusDx = 2 * (dy - dx);

                pk.Add(p);
                xToPrint.Add(y0);
                yToPrint.Add(x0);


                while (x0 > xe)
                {
                    x0--;
                    if (p < 0)
                        p += twoDy;
                    else
                    {
                        y0++;
                        p += twoDyMinusDx;
                    }
                    pk.Add(p);
                    xToPrint.Add(y0);
                    yToPrint.Add(x0);
                    g.FillRectangle(brush, y0 + w / 2, -x0 + h / 2, 1, 1);
                }
            }
            else if (m <= 0 && m >= -1 && x0 < xe)
            {
                dx = xe - x0;
                dy = -(ye - y0);
                p = 2 * dy - dx;
                twoDy = 2 * dy;
                twoDyMinusDx = 2 * (dy - dx);
                pk.Add(p);
                xToPrint.Add(x0);
                yToPrint.Add(y0);


                while (x0 < xe)
                {
                    x0++;
                    if (p < 0)
                        p += twoDy;
                    else
                    {
                        y0--;
                        p += twoDyMinusDx;
                    }
                    pk.Add(p);
                    xToPrint.Add(x0);
                    yToPrint.Add(y0);
                    g.FillRectangle(brush, x0 + w / 2, -y0 + h / 2, 1, 1);
                }
            }
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "HTML File|*.html";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Build the HTML string using the selected file path
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" <style>\r\n            *{\r\n                text-align: center\r\n            }\r\n            table {\r\n                font-family: arial, sans-serif;\r\n                border-collapse: collapse;\r\n                width: 100%;\r\n            }\r\n            td, th {\r\n                border: 1px solid #dddddd;\r\n                padding: 8px;\r\n            }\r\n            tr:nth-child(even) {\r\n                \r\n            }\r\n        </style>");
                sb.AppendLine("<table>");
                sb.AppendLine("<tr>" +
                    "<th>k</th>" +
                    "<th>P<sub>k</sub></th>" +
                    "<th>(X<sub>k+1</sub>, Y<sub>k+1</sub>)</th>" +
                "</tr>");
                for (int i = 1; i < xToPrint.Count; i++)
                {
                    sb.AppendLine(
                        $"<tr>" +
                        $"<td>{(i - 1).ToString()}</td> " +
                        $"<td>{pk[i - 1].ToString()}</td>" +
                        $"<td>({xToPrint[i]}, {yToPrint[i]})</td>" +
                    "</tr>");
                }
                sb.AppendLine("</table>");

                // Save the HTML string to the selected file path
                File.WriteAllText(saveFileDialog1.FileName, sb.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var brush = Brushes.Black;
            Graphics graphics = pictureBox1.CreateGraphics();

            int xc = int.Parse(textBoxCenterX.Text);
            int yc = int.Parse(textBoxCenterY.Text);
            int radius = int.Parse(textBoxRadius.Text);
            List<int> xToPrint = new List<int>(), yToPrint = new List<int>();
            List<int> xToFile = new List<int>(), yToFile = new List<int>();
            List<int> pk = new List<int>();
            int x = 0, y = radius, p = 1 - radius;
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;
            BreCircle();

            while (x < y)
            {
                x++;
                if (p < 0)
                {
                    p += 2 * x + 1;
                }
                else
                {
                    y--;
                    p += 2 * (x - y) + 1;
                }
                BreCircle();
            }
            void BreCircle()
            {

                graphics.FillRectangle(brush, (xc + x + w / 2), (-yc - y + h / 2), 1, 1);
                xToPrint.Add(x + xc);
                yToPrint.Add(y + yc);
                graphics.FillRectangle(brush, (xc + x + w / 2), (-yc - y + h / 2), 1, 1);
                graphics.FillRectangle(brush, (xc - x + w / 2), (-yc - y + h / 2), 1, 1);
                graphics.FillRectangle(brush, (xc + x + w / 2), (-yc + y + h / 2), 1, 1);
                graphics.FillRectangle(brush, (xc - x + w / 2), (-yc + y + h / 2), 1, 1);
                graphics.FillRectangle(brush, (xc + y + w / 2), (-yc - x + h / 2), 1, 1);
                graphics.FillRectangle(brush, (xc - y + w / 2), (-yc - x + h / 2), 1, 1);
                graphics.FillRectangle(brush, (xc + y + w / 2), (-yc + x + h / 2), 1, 1);
                graphics.FillRectangle(brush, (xc - y + w / 2), (-yc + x + h / 2), 1, 1);

                xToPrint.Add(x + xc);
                yToPrint.Add(-y + yc);

                xToPrint.Add(-x + xc);
                yToPrint.Add(-y + yc);

                xToPrint.Add(-x + xc);
                yToPrint.Add(y + yc);

                xToPrint.Add(y + xc);
                yToPrint.Add(x + yc);

                xToPrint.Add(y + xc);
                yToPrint.Add(-x + yc);

                xToPrint.Add(-y + xc);
                yToPrint.Add(-x + yc);

                xToPrint.Add(-y + xc);
                yToPrint.Add(x + yc);

                xToFile.Add((int)(x + xc));
                yToFile.Add((int)(y + yc));
                xToPrint.Add((int)(x + xc));
                yToPrint.Add((int)(y + yc));
                pk.Add(p);

            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "HTML File|*.html";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Build the HTML string using the selected file path
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" <style>\r\n            *{\r\n                text-align: center\r\n            }\r\n            table {\r\n                font-family: arial, sans-serif;\r\n                border-collapse: collapse;\r\n                width: 100%;\r\n            }\r\n            td, th {\r\n                border: 1px solid #dddddd;\r\n                padding: 8px;\r\n            }\r\n            tr:nth-child(even) {\r\n                \r\n            }\r\n        </style>");
                sb.AppendLine("<table>");
                sb.AppendLine("<tr>" +
                    "<th>k</th>" +
                    "<th>P<sub>k</sub></th>" +
                    "<th>(X<sub>k+1</sub>, Y<sub>k+1</sub>)</th>" +
                    "<th>2X<sub>k+1</sub></th>" +
                    "<th>2Y<sub>k+1</sub></th>" +
                "</tr>");
                for (int i = 1; i < xToFile.Count; i++)
                {
                    sb.AppendLine(
                       $"<tr>" +
                        $"<td>{(i - 1).ToString()}</td> " +
                        $"<td>{pk[i - 1].ToString()}</td>" +
                        $"<td>({xToFile[i]}, {yToFile[i]})</td>" +
                        $"<td>{2 * xToFile[i]}</td>" +
                        $"<td>{2 * yToFile[i]}</td>" +
                    "</tr>");
                }
                sb.AppendLine("</table>");

                // Save the HTML string to the selected file path
                File.WriteAllText(saveFileDialog1.FileName, sb.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ellipsePlotPoints(int xCenter, int yCenter, int x, int y)
        {
            var aBrush = Brushes.Black;
            Graphics g = pictureBox1.CreateGraphics();
            int w = pictureBox1.ClientSize.Width;
            int h = pictureBox1.ClientSize.Height;
            g.FillRectangle(aBrush, w / 2 + (xCenter + x), h / 2 - (yCenter + y), 1, 1);
            g.FillRectangle(aBrush, w / 2 + (xCenter - x), h / 2 - (yCenter + y), 1, 1);
            g.FillRectangle(aBrush, w / 2 + (xCenter + x), h / 2 - (yCenter - y), 1, 1);
            g.FillRectangle(aBrush, w / 2 + (xCenter - x), h / 2 - (yCenter - y), 1, 1);

        }
        private void ellipseMidPoint(int xCenter, int yCenter,int rx,int ry)
        {
            int rxSquared = rx * rx;
            int rySquared = ry * ry;
            int twoRxSquared = 2 * rxSquared;
            int twoRySquared = 2 * rySquared;
            int p;
            int x = 0;
            int y = ry;
            int px = 0;
            int py = twoRxSquared * y;
            dataGridView1.Rows.Clear();
            ellipsePlotPoints(xCenter, yCenter, x, y);

            /*First Region*/
            p = Convert.ToInt32(rySquared - (rxSquared * ry) + (0.25 * rxSquared));
            int pk = p;
           

            while (px < py)
            {
                x++;
                px += twoRySquared;
                if (pk < 0)
                {
                    pk += rxSquared + px;
                }
                else
                {
                    y--;
                    py -= twoRxSquared;
                    pk += rySquared + px - py;
                }
                dataGridView1.Rows.Add(p, (xCenter + x), (yCenter + y), px, py);
                p = pk;
                ellipsePlotPoints(xCenter, yCenter, x, y);
            }
            /*Second Region*/

            p = Convert.ToInt32(rySquared * (x + 0.5) * (x + 0.5) + rxSquared * (y - 1) * (y - 1) - rxSquared * rySquared) ;
            pk = p;
            while (y > 0)
            {
                y--;
                py -= twoRxSquared;
               
                if (pk > 0)
                {
                    pk += rxSquared - py;
                }
                else
                {
                    x++;
                    px += twoRxSquared;
                    pk += rxSquared - py + px;
                   
                }

                dataGridView1.Rows.Add(p, (xCenter + x), (yCenter + y), px, py);
                p = pk;
                ellipsePlotPoints(xCenter, yCenter, x, y);

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
           
            int xc = int.Parse(textBox8.Text);
            int yc = int.Parse(textBox7.Text);
            int rx = int.Parse(textBox6.Text);
            int ry = int.Parse(textBox5.Text);

            ellipseMidPoint(xc, yc, rx, ry);

        }


        private void button7_Click(object sender, EventArgs e)
        {
            Form2 secondForm = new Form2();
            secondForm.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    




                