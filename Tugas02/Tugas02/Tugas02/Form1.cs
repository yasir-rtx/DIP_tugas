using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas02
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
            DialogResult dialog = openFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                obj = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = obj;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color color = obj.GetPixel(x, y);
                    int xgray = (int)(color.R + color.G + color.B) / 3;
                    Color gray = Color.FromArgb(xgray, xgray, xgray);
                    objek.SetPixel(x, y, gray);
                }
            }
            pictureBox2.Image = objek;
        }

        // Black and White
        private void button3_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(obj); 
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color color = obj.GetPixel(x, y); // Membaca value RGB dari gambar pada posisi x,y
                    int xgray = (int)(color.R + color.G + color.B) / 3; // Mendapatkan nilai greyscale
                    int threshold = 128; // Mendeklarasikan nilai threshold
                    int xbw = 0; // Memberi value hitam
                    if (xgray >= threshold) xbw = 255; // Jika nilai grayscale melewati threshold maka akan diberi value putih
                    Color bnw = Color.FromArgb(xbw, xbw, xbw); // Memberi nilai RGB baru
                    objek.SetPixel(x, y, bnw); // Menset value RGB pada posisi x,y
                }
            }
            pictureBox2.Image = objek; // Menampilkan objek hasil manipulasi
        }

        // kuantisasi
        private void button4_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color color = obj.GetPixel(x, y);
                    int xg = (int)(color.R + color.G + color.B) / 3;
                    int k = 16; // Nilai kuantisasi
                    int xk = k * (int)(xg / k);
                    Color kuantisasi = Color.FromArgb(xk, xk, xk);
                    objek.SetPixel(x, y, kuantisasi);
                }
            }
            pictureBox2.Image = objek;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are U sure ?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
