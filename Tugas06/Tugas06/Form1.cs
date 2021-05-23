using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas06
{
    public partial class Form1 : Form
    {
        Bitmap objek;
        Bitmap obj;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                obj = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = obj;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(obj);
            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color color = objek.GetPixel(x, y);
                    int xg = (int)((color.R + color.B + color.G) / 3);
                    Color newColor = Color.FromArgb(xg, xg, xg);
                    objek.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = objek;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float[] a = new float[5];
            a[0] = (float)-0.5;
            a[1] = (float)-0.5;
            a[2] = (float)1;
            a[3] = (float)0.5;
            a[4] = (float)0.5;

            Bitmap objek4;
            objek4 = new Bitmap(objek);

            for (int x = 1; x < objek4.Width - 1; x++)
            {
                for (int y = 1; y < objek4.Height - 1; y++)
                {
                    // Read Color 4 Matrix
                    Color c0 = objek4.GetPixel(x, y - 1);
                    Color c1 = objek4.GetPixel(x - 1, y);
                    Color c2 = objek4.GetPixel(x, y);
                    Color c3 = objek4.GetPixel(x + 1, y);
                    Color c4 = objek4.GetPixel(x, y + 1);

                    // Grayscale c0...c4
                    int x0 = (int)((c0.R + c0.G + c0.B) / 3);
                    int x1 = (int)((c1.R + c1.G + c1.B) / 3);
                    int x2 = (int)((c2.R + c2.G + c2.B) / 3);
                    int x3 = (int)((c3.R + c3.G + c3.B) / 3);
                    int x4 = (int)((c4.R + c4.G + c4.B) / 3);

                    // Initiate 4 Matrix Filtering
                    int xn = (int)((a[0] * x0) + (a[1] * x1) + (a[2] * x2) + (a[3] * x3) + (a[4] * x4));
                    if (xn < 0) xn = 0;
                    if (xn > 255) xn = 255;

                    Color newColor = Color.FromArgb(xn, xn, xn);
                    objek4.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = objek4;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float[] a = new float[10];
            a[1] = (float)-1;
            a[2] = (float)-0.5;
            a[3] = (float)0;
            a[4] = (float)-0.5;
            a[5] = (float)1;
            a[6] = (float)0.5;
            a[7] = (float)0;
            a[8] = (float)0.5;
            a[9] = (float)1;

            Bitmap objek8;
            objek8 = new Bitmap(objek);

            for (int x = 1; x < objek8.Width - 1; x++)
            {
                for (int y = 1; y < objek8.Height - 1; y++)
                {
                    // Read RGB 4 Matrix
                    Color c1 = objek8.GetPixel(x - 1, y - 1);
                    Color c2 = objek8.GetPixel(x, y - 1);
                    Color c3 = objek8.GetPixel(x + 1, y - 1);
                    Color c4 = objek8.GetPixel(x - 1, y);
                    Color c5 = objek8.GetPixel(x, y);
                    Color c6 = objek8.GetPixel(x + 1, y);
                    Color c7 = objek8.GetPixel(x - 1, y + 1);
                    Color c8 = objek8.GetPixel(x, y + 1);
                    Color c9 = objek8.GetPixel(x + 1, y + 1);

                    // Grayscale 1...9
                    int x1 = (int)((c1.R + c1.G + c1.B) / 3);
                    int x2 = (int)((c2.R + c2.G + c2.B) / 3);
                    int x3 = (int)((c3.R + c3.G + c3.B) / 3);
                    int x4 = (int)((c4.R + c4.G + c4.B) / 3);
                    int x5 = (int)((c5.R + c5.G + c5.B) / 3);
                    int x6 = (int)((c6.R + c6.G + c6.B) / 3);
                    int x7 = (int)((c7.R + c7.G + c7.B) / 3);
                    int x8 = (int)((c8.R + c8.G + c8.B) / 3);
                    int x9 = (int)((c9.R + c9.G + c9.B) / 3);

                    int xb = (int)(a[1] * x1 + a[2] * x2 + a[3] * x3 + a[4] * x4 + a[5] * x5 + a[6] * x6 + a[7] * x7 + a[8] * x8 + a[9] * x9);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;

                    Color newColor = Color.FromArgb(xb, xb, xb);
                    objek8.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = objek8;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
