using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ListView myList = new ListView();

        
    private void button3_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(numericUpDown1.Value);
            int b = Convert.ToInt32(textBox3.Text);
            int c = a * b;

            myList = new ListView();
            myList.Text = textBox1.Text;
            myList.Items.Add(textBox1.Text);
            myList.Items.Add(textBox2.Text);
            myList.Items.Add("");
            myList.Items.Add(numericUpDown1.Value.ToString());
            myList.Items.Add(c.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        ColorDialog cd = new ColorDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            if(cd.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = cd.Color;
            }
        }
    }
}
