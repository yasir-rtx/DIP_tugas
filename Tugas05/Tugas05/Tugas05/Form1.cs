using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas05
{
    public partial class Form1 : Form
    {
        Bitmap source;
        Bitmap output;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if(d == DialogResult.OK)
            {
                source = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = source;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            output = new Bitmap(source);
            for (int x = 0; x < output.Width; x++)
            {
                for (int y = 0; y < output.Height; y++)
                {
                    Color color = output.GetPixel(x, y);
                    int xgray = (int)((color.R + color.G + color.B) / 3);
                    Color newColor = Color.FromArgb(xgray, xgray, xgray);
                    output.SetPixel(x, y, newColor);
                }
            }
            pictureBox1.Image = output;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            output = new Bitmap(pictureBox1.Image);
            float[] Hist = new float[256];

            // Inisiasi array Hist[1..256] dengan 0
            for (int i = 0; i < 256; i++) Hist[i] = 0;

            // Read grayscale value
            for (int x = 0; x < output.Width; x++)
            {
                for (int y = 0; y < output.Height; y++)
                {
                    Color color = output.GetPixel(x, y);
                    int xgray = (int)((color.R + color.G + color.B) / 3);
                    Hist[xgray] = Hist[xgray] + 1;
                }
            }

            // Displaying histogram
            for (int i = 0; i < 256; i++) chart1.Series["Series1"].Points.AddXY(i, Hist[i]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            output = new Bitmap(pictureBox1.Image);
            float[] Hist = new float[256];
            float[] CDF = new float[256];

            // Inisiasi array Hist[1..256] dengan 0
            for (int i = 0; i < 256; i++) Hist[i] = 0;

            // Read grayscale value
            for (int x = 0; x < output.Width; x++)
            {
                for (int y = 0; y < output.Height; y++)
                {
                    Color color = output.GetPixel(x, y);
                    int xgray = (int)((color.R + color.G + color.B) / 3);
                    Hist[xgray] = Hist[xgray] + 1;
                }
            }

            // CDF atau Fungsi Distribusi Kumulatif
            CDF[0] = Hist[0];
            for (int i = 1; i < 256; i++) CDF[i] = CDF[i - 1] + Hist[i];

            // Displaying CDF
            for (int i = 0; i < 256; i++) chart1.Series["Series1"].Points.AddXY(i, CDF[i]);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Apakah anda yakin ingin keluar ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            output = new Bitmap(pictureBox1.Image);
            float[] Hist = new float[256];
            int nPixel = output.Width * output.Height;

            // Inisiasi array Hist[1..256] dengan 0
            for (int i = 0; i < 256; i++) Hist[i] = 0;

            // Read grayscale value
            for (int x = 0; x < output.Width; x++)
            {
                for (int y = 0; y < output.Height; y++)
                {
                    Color color = output.GetPixel(x, y);
                    int xgray = (int)((color.R + color.G + color.B) / 3);
                    Hist[xgray] = Hist[xgray] + 1;
                }
            }

            // PDF
            for (int i = 0; i < 256; i++)
            {
                Hist[i] = Hist[i] / (float)nPixel;
            }

            // Displaying histogram
            for (int i = 0; i < 256; i++) chart1.Series["Series1"].Points.AddXY(i, Hist[i]);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            output = new Bitmap(pictureBox1.Image);
            float[] Hist = new float[256];
            float[] CDF = new float[256];
            int nPixel = output.Width * output.Height;

            // Inisiasi array Hist[1..256] dengan 0
            for (int i = 0; i < 256; i++) Hist[i] = 0;

            // Read grayscale value
            for (int x = 0; x < output.Width; x++)
            {
                for (int y = 0; y < output.Height; y++)
                {
                    Color color = output.GetPixel(x, y);
                    int xgray = (int)((color.R + color.G + color.B) / 3);
                    Hist[xgray] = Hist[xgray] + 1;
                }
            }

            // PDF
            for (int i = 0; i < 256; i++)
            {
                Hist[i] = Hist[i] / (float)nPixel;
            }

            // CDF atau Fungsi Distribusi Kumulatif
            CDF[0] = Hist[0];
            for (int i = 1; i < 256; i++) CDF[i] = CDF[i - 1] + Hist[i];

            // Displaying histogram
            for (int i = 0; i < 256; i++) chart1.Series["Series1"].Points.AddXY(i, CDF[i]);
        }
    }
}
