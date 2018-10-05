using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        string name = "";
        string surname = "";
        string city = "";
        string profession = "";
        string uni = "";
        int q = 0;
        int l = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            name = textBox1.Text.ToUpper() + textBox2.Text.ToUpper();
            foreach(char c in name)
            {
                if(c.ToString() == " ")
                {
                    label10.Text += " ";
                }else if(c.ToString() != " ")
                {
                    label10.Text += c.ToString() + " ";
                }
            }

            label11.Text = q.ToString();
            label12.Text = "'" + textBox3.Text + "'" + ", " + "'" + textBox4.Text + "'" + ", " + "'" + textBox5.Text + "'" + ", ";
            string text = textBox3.Text + textBox4.Text + textBox5.Text;
            //string[] words = text.Split(",");
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    l++;
                }
            }
            label13.Text = q.ToString();
            label15.Text = l.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            uni = textBox3.Text;
            btn.Enabled = false;
            button2.Enabled = false;
            q++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            city = textBox4.Text;
            btn.Enabled = false;
            button4.Enabled = false;
            q++;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            profession = textBox5.Text;
            btn.Enabled = false;
            button6.Enabled = false;
            q++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
            button1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
            button5.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
            button5.Enabled = false;
        }
    }
}
