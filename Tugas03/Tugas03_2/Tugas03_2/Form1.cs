using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas03_2
{
    public partial class Form1 : Form
    {
        Bitmap obj, objek;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color c = obj.GetPixel(x, y);
                    Color color = Color.FromArgb(c.R, 0, 0);
                    objek.SetPixel(x, y, color);
                }
            }
            pictureBox2.Image = objek;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color c = obj.GetPixel(x, y);
                    Color color = Color.FromArgb(0, 0, c.B);
                    objek.SetPixel(x, y, color);
                }
            }
            pictureBox2.Image = objek;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Copy_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color c = obj.GetPixel(x, y);
                    objek.SetPixel(x, y, c);
                }
            }
            pictureBox2.Image = objek;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color c = obj.GetPixel(x, y);
                    Color color = Color.FromArgb(0, c.G, 0);
                    objek.SetPixel(x, y, color);
                }
            }
            pictureBox2.Image = objek;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are U Sure ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                obj = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = obj;
            }
        }
    }
}
