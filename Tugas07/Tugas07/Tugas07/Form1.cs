using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas07
{
    public partial class Form1 : Form
    {
        Bitmap objek;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
            Bitmap objekgray;
            objekgray = new Bitmap(objek);

            for (int x = 0; x < objekgray.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color color = objekgray.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);
                    Color newColor = Color.FromArgb(xg, xg, xg);
                    objekgray.SetPixel(x, y, newColor);
                }
            }
            pictureBox1.Image = objekgray;
            pictureBox2.Image = objekgray;
            pictureBox3.Image = objekgray;
            pictureBox4.Image = objekgray;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap objekgauss;
            objekgauss = new Bitmap(objek);

            Random random = new Random();
            int n = Convert.ToInt16(textBox1.Text);

            for (int x = 0; x < objekgauss.Width; x++)
            {
                for (int y = 0; y < objekgauss.Height; y++)
                {
                    Color color = objekgauss.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);

                    int xnew = xg;
                    int newRandom = random.Next(0, 100);
                    if (newRandom < n)
                    {
                        int noise = random.Next(0, 256) - 128;
                        xnew += noise;
                        if (xnew < 0) xnew = -xnew;
                        if (xnew > 255) xnew = 255;
                    }

                    Color newColor = Color.FromArgb(xnew, xnew, xnew);
                    objekgauss.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = objekgauss;
            pictureBox3.Image = objekgauss;
            pictureBox4.Image = objekgauss;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap objekspackle;
            objekspackle = new Bitmap(objek);

            Random random = new Random();
            int n = Convert.ToInt16(textBox1.Text);

            for (int x = 0; x < objekspackle.Width; x++)
            {
                for (int y = 0; y < objekspackle.Height; y++)
                {
                    Color color = objekspackle.GetPixel(x, y);
                    int xg = (int)((color.G + color.B + color.R) / 3);

                    int xnew = xg;
                    int newRandom = random.Next(0, 100);
                    if (newRandom < n) xnew = 0;
                    Color newColor = Color.FromArgb(xnew, xnew, xnew);
                    objekspackle.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = objekspackle;
            pictureBox3.Image = objekspackle;
            pictureBox4.Image = objekspackle;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap objeksnp;
            objeksnp = new Bitmap(objek);

            Random random = new Random();
            int n = Convert.ToInt16(textBox1.Text);

            for (int x = 0; x < objeksnp.Width; x++)
            {
                for (int y = 0; y < objeksnp.Height; y++)
                {
                    Color color = objeksnp.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);

                    int xnew = xg;
                    int newRandom = random.Next(0, 100);
                    if (newRandom < n) xnew = 255;

                    Color newColor = Color.FromArgb(xnew, xnew, xnew);
                    objeksnp.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = objeksnp;
            pictureBox3.Image = objeksnp;
            pictureBox4.Image = objeksnp;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap objNoise;
            objNoise = new Bitmap(pictureBox2.Image);
            for (int x = 1; x < objNoise.Width - 1; x++)
            {
                for (int y = 1; y < objNoise.Height - 1; y++)
                {
                    // Read RGB from objek in picturebox2
                    Color c0 = objNoise.GetPixel(x - 1, y - 1);
                    Color c1 = objNoise.GetPixel(x, y - 1);
                    Color c2 = objNoise.GetPixel(x + 1, y - 1);
                    Color c3 = objNoise.GetPixel(x - 1, y);
                    Color c4 = objNoise.GetPixel(x, y);
                    Color c5 = objNoise.GetPixel(x + 1, y);
                    Color c6 = objNoise.GetPixel(x - 1, y + 1);
                    Color c7 = objNoise.GetPixel(x, y + 1);
                    Color c8 = objNoise.GetPixel(x + 1, y + 1);

                    // Grayscale xg0...xg8
                    int xg0 = (int)((c0.R + c0.G + c0.B) / 3);
                    int xg1 = (int)((c1.R + c1.G + c1.B) / 3);
                    int xg2 = (int)((c2.R + c2.G + c2.B) / 3);
                    int xg3 = (int)((c3.R + c3.G + c3.B) / 3);
                    int xg4 = (int)((c4.R + c4.G + c4.B) / 3);
                    int xg5 = (int)((c5.R + c5.G + c5.B) / 3);
                    int xg6 = (int)((c6.R + c6.G + c6.B) / 3);
                    int xg7 = (int)((c7.R + c7.G + c7.B) / 3);
                    int xg8 = (int)((c8.R + c8.G + c8.B) / 3);

                    // average filter
                    int xnew = (int)((xg0 + xg1 + xg2 + xg3 + xg4 + xg5 + xg6 + xg7 + xg8) / 9);
                    if (xnew < 0) xnew = 0;
                    if (xnew > 255) xnew = 255;

                    Color newColor = Color.FromArgb(xnew, xnew, xnew);
                    objNoise.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = objNoise;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap objNoise;
            objNoise = new Bitmap(objek);

            for (int x = 1; x < objNoise.Width - 1; x++)
            {
                for (int y = 1; y < objNoise.Height - 1; y++)
                {
                    // Read RGB value from picturebox3
                    Color c0 = objNoise.GetPixel(x - 1, y - 1);
                    Color c1 = objNoise.GetPixel(x, y - 1);
                    Color c2 = objNoise.GetPixel(x + 1, y - 1);
                    Color c3 = objNoise.GetPixel(x - 1, y);
                    Color c4 = objNoise.GetPixel(x, y);
                    Color c5 = objNoise.GetPixel(x + 1, y);
                    Color c6 = objNoise.GetPixel(x - 1, y + 1);
                    Color c7 = objNoise.GetPixel(x, y + 1);
                    Color c8 = objNoise.GetPixel(x + 1, y + 1);

                    // Grayscale xg0...xg8
                    int xg0 = (int)((c0.R + c0.G + c0.B) / 3);
                    int xg1 = (int)((c1.R + c1.G + c1.B) / 3);
                    int xg2 = (int)((c2.R + c2.G + c2.B) / 3);
                    int xg3 = (int)((c3.R + c3.G + c3.B) / 3);
                    int xg4 = (int)((c4.R + c4.G + c4.B) / 3);
                    int xg5 = (int)((c5.R + c5.G + c5.B) / 3);
                    int xg6 = (int)((c6.R + c6.G + c6.B) / 3);
                    int xg7 = (int)((c7.R + c7.G + c7.B) / 3);
                    int xg8 = (int)((c8.R + c8.G + c8.B) / 3);

                    // gaussian filter
                    int xnew = (int)((xg0 + xg1 + xg2 + xg3 + (xg4 * 4) + xg5 + xg6 + xg7 + xg8) / 15);
                    if (xnew < 0) xnew = 0;
                    if (xnew > 255) xnew = 255;

                    Color newColor = Color.FromArgb(xnew, xnew, xnew);
                    objNoise.SetPixel(x, y, newColor);
                }
            }
            pictureBox3.Image = objNoise;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap objNoise;
            objNoise = new Bitmap(objek);
            int[] xg = new int[10];

            for (int x = 1; x < objNoise.Width - 1; x++)
            {
                for (int y = 1; y < objNoise.Height - 1; y++)
                {
                    // Read RGB value from picturebox3
                    Color c0 = objNoise.GetPixel(x - 1, y - 1);
                    Color c1 = objNoise.GetPixel(x, y - 1);
                    Color c2 = objNoise.GetPixel(x + 1, y - 1);
                    Color c3 = objNoise.GetPixel(x - 1, y);
                    Color c4 = objNoise.GetPixel(x, y);
                    Color c5 = objNoise.GetPixel(x + 1, y);
                    Color c6 = objNoise.GetPixel(x - 1, y + 1);
                    Color c7 = objNoise.GetPixel(x, y + 1);
                    Color c8 = objNoise.GetPixel(x + 1, y + 1);

                    // Grayscale xg0...xg8
                    xg[0] = (int)((c0.R + c0.G + c0.B) / 3);
                    xg[1] = (int)((c1.R + c1.G + c1.B) / 3);
                    xg[2] = (int)((c2.R + c2.G + c2.B) / 3);
                    xg[3] = (int)((c3.R + c3.G + c3.B) / 3);
                    xg[4] = (int)((c4.R + c4.G + c4.B) / 3);
                    xg[5] = (int)((c5.R + c5.G + c5.B) / 3);
                    xg[6] = (int)((c6.R + c6.G + c6.B) / 3);
                    xg[7] = (int)((c7.R + c7.G + c7.B) / 3);
                    xg[8] = (int)((c8.R + c8.G + c8.B) / 3);

                    // Sorting to find xgmax
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++) {
                            if (xg[j] > xg[j + 1])
                            {
                                int a = xg[j];
                                xg[j] = xg[j + 1];
                                xg[j + 1] = a;
                            }
                        }
                    }

                    int xnew = xg[4];
                    Color newColor = Color.FromArgb(xnew, xnew, xnew);
                    objNoise.SetPixel(x, y, newColor);
                }
            }
            pictureBox4.Image = objNoise;
        }
    }
}
