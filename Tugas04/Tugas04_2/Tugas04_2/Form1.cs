using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas04_2
{
    public partial class Form1 : Form
    {

        Bitmap source;
        Bitmap result;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                source = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = source;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = new Bitmap(source);

            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    Color color = result.GetPixel(x, y);
                    int xgray = (int)(color.R + color.G + color.B) / 3;
                    Color grayscale = Color.FromArgb(xgray, xgray, xgray);
                    result.SetPixel(x, y, grayscale);
                }
            }
            pictureBox2.Image = result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            result = new Bitmap(source);
            int b = Convert.ToInt16(textBox1.Text);

            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    Color color = result.GetPixel(x, y);
                    int xgray = (int)(color.R + color.G + color.B) / 3;

                    // Initiate Brightness
                    int xb = xgray + b;
                    if (xb < 0) xb = 0;
                    if (xb >= 255) xb = 255;

                    Color brightness = Color.FromArgb(xb, xb, xb);
                    result.SetPixel(x, y, brightness);
                }
            }
            pictureBox2.Image = result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            result = new Bitmap(source);
            float c = Convert.ToSingle(textBox2.Text);

            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    Color color = result.GetPixel(x, y);
                    int xgray = (int)(color.R + color.G + color.B) / 3;

                    // Initiate Contrast
                    float cont = c * xgray;
                    int xc = (int)cont;
                    if (xc < 0) xc = 0;
                    if (xc >= 255) xc = 255;

                    Color contrast = Color.FromArgb(xc, xc, xc);
                    result.SetPixel(x, y, contrast);
                }
            }
            pictureBox2.Image = result;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            result = new Bitmap(source);

            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    Color color = result.GetPixel(x, y);
                    int xgray = (int)(color.R + color.G + color.B) / 3;

                    // Initiate Invers
                    int xi = 128 - xgray;
                    if (xi < 0) xi = 0;

                    Color autolevel = Color.FromArgb(xi, xi, xi);
                    result.SetPixel(x, y, autolevel);
                }
            }
            pictureBox2.Image = result;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            result = new Bitmap(source);
            int xgmax = 0;
            int xgmin = 255;

            // Find xgmax and xgmin
            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    Color color = result.GetPixel(x, y);
                    int xgray = (int)(color.R + color.G + color.B) / 3;

                    // Sorting xgmax and xgmin
                    if (xgray < xgmin) xgmin = xgray;
                    if (xgray > xgmax) xgmax = xgray;
                }
            }

            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    Color color = result.GetPixel(x, y);
                    int xgray = (int)(color.R + color.G + color.B) / 3;

                    // Initiate Auto Level
                    int xal = (int)((255 * (xgray - xgmin)) / (xgmax - xgmin));

                    Color autolevel = Color.FromArgb(xal, xal, xal);
                    result.SetPixel(x, y, autolevel);
                }
            }
            pictureBox2.Image = result;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmation", "Are U Sure ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
