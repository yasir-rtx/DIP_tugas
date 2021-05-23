using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas06_2
{
    public partial class Form1 : Form
    {
        Bitmap obj;
        Bitmap objek;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if ( d == DialogResult.OK)
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
                    int xg = (int)((color.R + color.G + color.B) / 3);
                    Color newColor = Color.FromArgb(xg, xg, xg);
                    objek.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = objek;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap gaussian;
            gaussian = new Bitmap(objek);
            Random random = new Random();
            int n = Convert.ToInt16(textBox1.Text);

            for (int x = 0; x < gaussian.Width; x++)
            {
                for (int y = 0; y < gaussian.Height; y++)
                {
                    Color color = gaussian.GetPixel(x, y);
                    int xg = (int)((color.G + color.G + color.B) / 3);

                    int xb = xg;
                    int newRandom = random.Next(0, 100);
                    if (newRandom < n) // Noise 20%
                    {
                        int noise = random.Next(0, 256) - 128;
                        xb = (int)(xb + noise);
                        if (xb < 0) xb = -xb;
                        if (xb > 255) xb = 255;
                    }

                    Color newColor = Color.FromArgb(xb, xb, xb);
                    gaussian.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = gaussian;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap spackle;
            spackle = new Bitmap(objek);
            Random random = new Random();
            int n = Convert.ToInt16(textBox1.Text);

            for (int x = 0; x < spackle.Width; x++)
            {
                for (int y = 0; y < spackle.Height; y++)
                {
                    Color color = spackle.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);

                    int xnoise = xg;
                    int newRandom = random.Next(0, 100);
                    if (newRandom < n) xnoise = 0; // Spackle Noising

                    Color newColor = Color.FromArgb(xnoise, xnoise, xnoise);
                    spackle.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = spackle;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap snp;
            snp = new Bitmap(objek);
            Random random = new Random();
            int n = Convert.ToInt16(textBox1.Text);

            for (int x = 0; x < snp.Width; x++)
            {
                for (int y = 0; y < snp.Height; y++)
                {
                    Color color = snp.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);

                    int xn = xg;
                    int newRandom = random.Next(0, 100);
                    if (newRandom < n) xn = 255; // Salt & Papper Noising

                    Color newColor = Color.FromArgb(xn, xn, xn);
                    snp.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = snp;
        }
    }
}
