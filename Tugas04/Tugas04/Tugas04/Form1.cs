using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tugas04
{
    public partial class Form1 : Form
    {

        Bitmap source;
        Bitmap result;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

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
            //int[] sum = new int[result.Width*result.Height];
            int sum = 0;
            // Mencari nilai rata2 derajat keabuan semua titik
            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    Color color = result.GetPixel(x, y);
                    int xgray = (int)(color.R + color.G + color.B) / 3;

                    //sum[x*y] = sum[x*y] + xgray;
                    sum = sum + xgray;
                }
            }

            int rata = (int)(sum / (result.Width * result.Height));

            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    Color color = result.GetPixel(x, y);
                    int xgray = (int)(color.R + color.G + color.B) / 3;

                    //int thresholding;
                    int newX = 0;
                    if (xgray >= rata) newX = 255;

                    Color bnw = Color.FromArgb(newX, newX, newX);
                    result.SetPixel(x, y, bnw);
                }
            }
            pictureBox2.Image = result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            result = new Bitmap(source);

            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    Color color = result.GetPixel(x, y);
                    int xgray = (int)(color.R + color.G + color.B) / 3;

                    int newX = 8 * (int)(xgray / 8); // Kuantisasai dengam nilai 16

                    Color kuantisasi = Color.FromArgb(newX, newX, newX);
                    result.SetPixel(x, y, kuantisasi);
                }
            }
            pictureBox2.Image = result;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmation", "Are U Sure ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
