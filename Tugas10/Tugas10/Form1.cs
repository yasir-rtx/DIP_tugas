using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas10
{
    public partial class Form1 : Form
    {
        Bitmap obj, objbitmap;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = hScrollBar1.Value;
            button2.Text = a.ToString();
            obj = new Bitmap(objbitmap);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);
                    int r = c.R + a;
                    int g = c.G + a;
                    int b = c.B + a;

                    if (r < 0) r = 0;
                    if (r > 255) r = 255;
                    if (g < 0) g = 0;
                    if (g > 255) g = 255;
                    if (b < 0) b = 0;
                    if (b > 255) b = 255;

                    Color cn = Color.FromArgb(r, g, b);
                    obj.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = obj;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float cont = (float)(hScrollBar2.Value / 100.0);
            button3.Text = cont.ToString();
            obj = new Bitmap(objbitmap);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);
                    int r = (int)(cont * (float)c.R);
                    int g = (int)(cont * (float)c.G);
                    int b = (int)(cont * (float)c.B);

                    if (r < 0) r = 0;
                    if (r > 255) r = 255;
                    if (g < 0) g = 0;
                    if (g > 255) g = 255;
                    if (b < 0) b = 0;
                    if (b > 255) b = 255;

                    Color cn = Color.FromArgb(r, g, b);
                    obj.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = obj;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            obj = new Bitmap(objbitmap);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);

                    int r = 255 - c.R;
                    int g = 255 - c.G;
                    int b = 255 - c.B;

                    Color cn = Color.FromArgb(r, g, b);
                    obj.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = obj;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int rmin = 255, gmin = 255, bmin = 255;
            int rmax = 0, gmax = 0, bmax = 0;
            obj = new Bitmap(objbitmap);

            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);

                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    if (r < rmin) rmin = r;
                    if (r > rmax) rmax = r;
                    if (g < gmin) gmin = g;
                    if (g > gmax) gmax = g;
                    if (b < bmin) bmin = b;
                    if (b > bmax) bmax = b;
                }
            }

            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);

                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    int rn = (int)(255 * (r - rmin) / (rmax - rmin));
                    int gn = (int)(255 * (g - gmin) / (gmax - gmin));
                    int bn = (int)(255 * (b - bmin) / (bmax - bmin));

                    Color cn = Color.FromArgb(rn, gn, bn);
                    obj.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = obj;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int k = 4;
            obj = new Bitmap(objbitmap);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);

                    int r = (int)(k * (c.R / k));
                    int g = (int)(k * (c.G / k));
                    int b = (int)(k * (c.B / k));

                    Color cn = Color.FromArgb(r, g, b);
                    obj.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = obj;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            obj = new Bitmap(objbitmap);
            float[] HistR = new float[256];
            float[] HistG = new float[256];
            float[] HistB = new float[256];
            float[] CDFR = new float[256];
            float[] CDFG = new float[256];
            float[] CDFB = new float[256];

            for (int i = 0; i < 256; i++) HistR[i] = 0;
            for (int i = 0; i < 256; i++) HistG[i] = 0;
            for (int i = 0; i < 256; i++) HistB[i] = 0;
            
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);
                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    HistR[r] = HistR[r] + 1;
                    HistG[g] = HistG[g] + 1;
                    HistB[b] = HistB[b] + 1;
                }
            }

            CDFR[0] = HistR[0];
            for (int i = 1; i < 256; i++) CDFR[i] = CDFR[i - 1] + HistR[i];
            CDFG[0] = HistG[0];
            for (int i = 1; i < 256; i++) CDFG[i] = CDFG[i - 1] + HistG[i];
            CDFB[0] = HistB[0];
            for (int i = 1; i < 256; i++) CDFB[i] = CDFB[i - 1] + HistB[i];

            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);
                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    int red = (int)((255 * CDFR[r]) / (obj.Width * obj.Height));
                    int green = (int)((255 * CDFG[g]) / (obj.Width * obj.Height));
                    int blue = (int)((255 * CDFB[b]) / (obj.Width * obj.Height));

                    Color newColor = Color.FromArgb(red, green, blue);
                    obj.SetPixel(x, y, newColor);
                }
            }

            pictureBox2.Image = obj;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objbitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = objbitmap;
            }
        }
    }
}
