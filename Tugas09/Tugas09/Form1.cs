using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas09
{
    public partial class Form1 : Form
    {
        Bitmap objek;
        Bitmap objbitmap;
        public Form1()
        {
            InitializeComponent();
        }

        private void load_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objek = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = objek;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(objek);
            for (int x = 0; x < objbitmap.Width; x++)
            {
                for (int y = 0; y < objbitmap.Height; y++)
                {
                    Color c = objek.GetPixel(x, y);
                    int xg = (int)((c.R + c.G + c.B) / 3);
                    Color cn = Color.FromArgb(xg, xg, xg);
                    objbitmap.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = objbitmap;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(objek);
            for (int x = 1; x < objbitmap.Width - 1; x++)
            {
                for (int y = 1; y < objbitmap.Height - 1; y++)
                {
                    Color c1 = objek.GetPixel(x - 1, y - 1);
                    Color c2 = objek.GetPixel(x, y - 1);
                    Color c3 = objek.GetPixel(x + 1, y - 1);
                    Color c4 = objek.GetPixel(x - 1, y);
                    Color c5 = objek.GetPixel(x, y);
                    Color c6 = objek.GetPixel(x + 1, y);
                    Color c7 = objek.GetPixel(x - 1, y + 1);
                    Color c8 = objek.GetPixel(x, y + 1);
                    Color c9 = objek.GetPixel(x + 1, y + 1);

                    int xg1 = (int)((c1.R + c1.G + c1.B) / 3);
                    int xg2 = (int)((c2.R + c2.G + c2.B) / 3);
                    int xg3 = (int)((c3.R + c3.G + c3.B) / 3);
                    int xg4 = (int)((c4.R + c4.G + c4.B) / 3);
                    int xg5 = (int)((c5.R + c5.G + c5.B) / 3);
                    int xg6 = (int)((c6.R + c6.G + c6.B) / 3);
                    int xg7 = (int)((c7.R + c7.G + c7.B) / 3);
                    int xg8 = (int)((c8.R + c8.G + c8.B) / 3);
                    int xg9 = (int)((c9.R + c9.G + c9.B) / 3);

                    int xt1 = (int)((xg1 + xg2 + xg3 + xg4 + xg5 + xg6 + xg7 + xg8 + xg9) / 9);
                    int xt2 = (int)(-xg1 - (2 * xg2) - xg3 + xg7 + (2 * xg8) + xg9);
                    int xt3 = (int)(-xg1 - (2 * xg4) - xg7 + xg3 + (2 * xg6) + xg9);

                    int v = xt1 + xt2 + xt3;
                    int xn = v;
                    if (xn < 0) xn = -xn;
                    if (xn > 255) xn = 255;
                    Color cn = Color.FromArgb(xn, xn, xn);
                    objbitmap.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = objbitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(objek);
            for (int x = 1; x < objbitmap.Width - 1; x++)
            {
                for (int y = 1; y < objbitmap.Height - 1; y++)
                {
                    Color c1 = objek.GetPixel(x - 1, y - 1);
                    Color c2 = objek.GetPixel(x, y - 1);
                    Color c3 = objek.GetPixel(x + 1, y - 1);
                    Color c4 = objek.GetPixel(x - 1, y);
                    Color c5 = objek.GetPixel(x, y);
                    Color c6 = objek.GetPixel(x + 1, y);
                    Color c7 = objek.GetPixel(x - 1, y + 1);
                    Color c8 = objek.GetPixel(x, y + 1);
                    Color c9 = objek.GetPixel(x + 1, y + 1);

                    int xg1 = (int)((c1.R + c1.G + c1.B) / 3);
                    int xg2 = (int)((c2.R + c2.G + c2.B) / 3);
                    int xg3 = (int)((c3.R + c3.G + c3.B) / 3);
                    int xg4 = (int)((c4.R + c4.G + c4.B) / 3);
                    int xg5 = (int)((c5.R + c5.G + c5.B) / 3);
                    int xg6 = (int)((c6.R + c6.G + c6.B) / 3);
                    int xg7 = (int)((c7.R + c7.G + c7.B) / 3);
                    int xg8 = (int)((c8.R + c8.G + c8.B) / 3);
                    int xg9 = (int)((c9.R + c9.G + c9.B) / 3);

                    int xt1 = (int)((xg1 + xg2 + xg3 + xg4 + xg5 + xg6 + xg7 + xg8 + xg9) / 9);
                    int xt2 = (int)(-xg1 - (2 * xg2) - xg3 + xg7 + (2 * xg8) + xg9);
                    int xt3 = (int)(-xg1 - (2 * xg4) - xg7 + xg3 + (2 * xg6) + xg9);

                    int v = ((2 * xt1) + xt2 + xt3) / 2;
                    int xn = v;
                    if (xn < 0) xn = -xn;
                    if (xn > 255) xn = 255;
                    Color cn = Color.FromArgb(xn, xn, xn);
                    objbitmap.SetPixel(x, y, cn);
                }
            }
            pictureBox3.Image = objbitmap;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(objek);
            for (int x = 1; x < objbitmap.Width - 1; x++)
            {
                for (int y = 1; y < objbitmap.Height - 1; y++)
                {
                    Color c1 = objek.GetPixel(x - 1, y - 1);
                    Color c2 = objek.GetPixel(x, y - 1);
                    Color c3 = objek.GetPixel(x + 1, y - 1);
                    Color c4 = objek.GetPixel(x - 1, y);
                    Color c5 = objek.GetPixel(x, y);
                    Color c6 = objek.GetPixel(x + 1, y);
                    Color c7 = objek.GetPixel(x - 1, y + 1);
                    Color c8 = objek.GetPixel(x, y + 1);
                    Color c9 = objek.GetPixel(x + 1, y + 1);

                    int xg1 = (int)((c1.R + c1.G + c1.B) / 3);
                    int xg2 = (int)((c2.R + c2.G + c2.B) / 3);
                    int xg3 = (int)((c3.R + c3.G + c3.B) / 3);
                    int xg4 = (int)((c4.R + c4.G + c4.B) / 3);
                    int xg5 = (int)((c5.R + c5.G + c5.B) / 3);
                    int xg6 = (int)((c6.R + c6.G + c6.B) / 3);
                    int xg7 = (int)((c7.R + c7.G + c7.B) / 3);
                    int xg8 = (int)((c8.R + c8.G + c8.B) / 3);
                    int xg9 = (int)((c9.R + c9.G + c9.B) / 3);

                    int xt1 = (int)((xg1 + xg2 + xg3 + xg4 + xg5 + xg6 + xg7 + xg8 + xg9) / 9);
                    int xt2 = (int)(-xg1 - (2 * xg2) - xg3 + xg7 + (2 * xg8) + xg9);
                    int xt3 = (int)(-xg1 - (2 * xg4) - xg7 + xg3 + (2 * xg6) + xg9);

                    int v = (xt1 + (2 * xt2) + (2 * xt3)) / 3;
                    int xn = v;
                    if (xn < 0) xn = -xn;
                    if (xn > 255) xn = 255;
                    Color cn = Color.FromArgb(xn, xn, xn);
                    objbitmap.SetPixel(x, y, cn);
                }
            }
            pictureBox4.Image = objbitmap;
        }
    }
}
