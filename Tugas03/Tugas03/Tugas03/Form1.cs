using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas03
{
    public partial class Form1 : Form
    {
        Bitmap pic;
        Bitmap picture;
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are U Sure", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                pic = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = pic;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            picture = new Bitmap(pic);
            for (int x = 0; x < pic.Width; x++)
            {
                for (int y = 0; y < pic.Height; y++)
                {
                    Color c = pic.GetPixel(x, y);
                    picture.SetPixel(x, y, c);
                }
            }
            pictureBox2.Image = picture;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            picture = new Bitmap(pic);
            for (int x = 0; x < pic.Width; x++)
            {
                for (int y = 0; y < pic.Height; y++)
                {
                    Color c = pic.GetPixel(x, y);
                    picture.SetPixel(pic.Width - 1 - x, y, c);
                }
            }
            pictureBox2.Image = picture;
        }
    }
}
