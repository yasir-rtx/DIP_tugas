using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas05_2
{
    public partial class Form1 : Form
    {
        Bitmap objek;
        Bitmap source;

        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin keluar ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
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
            objek = new Bitmap(source);
            float[] h = new float[256];
            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color color = objek.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);
                    h[xg] = h[xg] + 1;
                    Color newColor = Color.FromArgb(xg, xg, xg);
                    objek.SetPixel(x, y, newColor);
                }
            }

            // Displaying
            pictureBox1.Image = objek;

            // Displayinh histogram
            for (int i = 0; i < 256; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i, h[i]);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(source);
            float[] H = new float[256];
            float[] CDF = new float[256];

            // Inisiasi array Hist[0...255] dengan 0
            for (int i = 0; i < 256; i++) H[i] = 0;

            // Membaca histogram derajat keabuan Hist[xg]
            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color color = objek.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);
                    H[xg] = H[xg] + 1;
                }
            }

            // CDF
            CDF[0] = H[0];
            for (int i = 1; i < 256; i++) CDF[i] = CDF[i - 1] + H[i];

            // Histogram Equalization
            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color color = objek.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);

                    // Equalization formula
                    int xEqual = (int)((255 * CDF[xg]) / (objek.Height * objek.Width));

                    H[xEqual] = H[xEqual] + 1;

                    Color newColor = Color.FromArgb(xEqual, xEqual, xEqual);
                    objek.SetPixel(x, y, newColor);
                }
            }

            // Displaying
            pictureBox2.Image = objek;

            // Displayinh histogram
            for (int i = 0; i < 256; i++)
            {
                chart2.Series["Series1"].Points.AddXY(i, H[i]);
            }
        }
    }
}
