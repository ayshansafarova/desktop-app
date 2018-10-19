using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SlideShowApp
{
    public partial class Form1 : Form
    {
        string Dirpath;
        int imgindex;
        Graphics gr;
        Pen mypen = new Pen(Color.Red, 4);
        int x1, y1, x2, y2;
        bool k = false;
        bool isDraw = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 10; i++)
            {
                comboBox1.Items.Add(i);
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                listBox1.Items.Clear();
                Dirpath = folderBrowserDialog1.SelectedPath;
                string[] files = Directory.GetFiles(Dirpath, "*.Jpg");
                foreach (string file in files)
                {
                    int pos = file.LastIndexOf("||");
                    string FName = file.Substring(pos + 1);
                    listBox1.Items.Add(FName);
                }
                listBox1.SelectedIndex = imgindex = 0;
                btnprev.Enabled = true;
                btnnext.Enabled = btnshow.Enabled = true;
            }
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            if (btnshow.Text == "Slide Show")
            {
                btnshow.Text = "stop show";
                timer1.Interval = int.Parse(comboBox1.Text) * 1000;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                btnshow.Text = "Slide Show";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = listBox1.SelectedItem.ToString ();
           // pictureBox1.ImageLocation = Dirpath + "\\" + listBox1.SelectedItem;
        }

        private void btnprev_Click(object sender, EventArgs e)
        {
            if (imgindex > 0)
            {
                imgindex -= 1;
                if(imgindex ==0)
                {
                    btnprev .Enabled=false;
                }
                if (imgindex < listBox1.Items.Count - 1)
                    btnnext.Enabled = true;
                listBox1.SelectedIndex = imgindex;
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            if (imgindex < listBox1.Items.Count - 1)
            {
                imgindex += 1;
                if (imgindex == listBox1.Items.Count - 1)
                    btnnext.Enabled = false;
            if (imgindex > 0)
                btnprev.Enabled = true;                 
                listBox1.SelectedIndex = imgindex;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnnext.PerformClick();
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            k = true;
            x1 = e.X;
            y1 = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            k = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (k ==true && isDraw == true)
            {
                gr = pictureBox1.CreateGraphics();
                x2 = e.X;
                y2 = e.Y;
                gr.DrawLine(mypen, x1, y1, x2, y2);
            }

            x1 = x2;
            y1 = y2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isDraw = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }


    }
}
