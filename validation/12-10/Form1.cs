using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12_10
{
    public partial class Form1 : Form
    {
        int nor=0;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.Blue;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.Blue;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.White;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.BackColor = Color.Blue;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            textBox4.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nor++;
            resetall();

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Bos buraxilmamalidir!");
                e.Cancel = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                textBox2.Enabled = true;
                this.SelectNextControl(textBox1, true, true, true, true);
            }
        }
        private void resetall()
        {
            button1.Enabled = false;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            label6.Text = nor.ToString();
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            resetall();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if(textBox2.Text.ToLower().Contains('@') && textBox2.Text.ToLower().Contains('.'))
            {
                e.Cancel = false;
            }
            else
            {
                MessageBox.Show("Email sehvdir!");
                e.Cancel = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                textBox3.Enabled = true;
                this.SelectNextControl(textBox2, true, true, true, true);
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            int n;
            bool i = int.TryParse(textBox3.Text, out n);
            if(textBox3.TextLength == 9 && i)
            {
                e.Cancel = false;
            }
            else
            {
                MessageBox.Show("Nomre Sehvdir!");
                e.Cancel = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox4.Enabled = true;
                this.SelectNextControl(textBox3, true, true, true, true);
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            int a;
            Int32.TryParse(textBox4.Text, out a);
            int k;
            bool j = int.TryParse(textBox4.Text, out k);
            if(a<=100 && a >= 0 && j)
            {
                e.Cancel = false;
            }
            else
            {
                MessageBox.Show("Xeta var!");
                e.Cancel = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.Enabled = true;
                this.SelectNextControl(textBox4, true, true, true, true);
            }
        }

    }
}
