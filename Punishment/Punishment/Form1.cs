using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punishment
{
    public partial class Form1 : Form
    {
        DateTime date1;
        DateTime date2;
        int punishment = 2;
        int total = 0;
        int price = 0;
        public Form1()
        {
            InitializeComponent();
            textBox5.Enabled = false;
            textBox6.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            price = Convert.ToInt32(textBox2.Text);
            date1 = Convert.ToDateTime(textBox3.Text);
            date2 = Convert.ToDateTime(textBox4.Text);
            TimeSpan timeSpan = date2.Subtract(date1);
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox5.Text = (punishment * Convert.ToInt32(timeSpan.TotalDays)).ToString();
            total = price + Convert.ToInt32(textBox5.Text);
            textBox6.Text = total.ToString();
        }
    }
}
