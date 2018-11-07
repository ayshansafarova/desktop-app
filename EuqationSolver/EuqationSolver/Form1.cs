using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EuqationSolver
{

    public partial class Form1 : Form
    {
        Random random = new Random();
        int rnd;
        int A;
        int B;
        int C;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            rnd = Convert.ToInt32(textBox1.Text);
            for(int i = 0; i < rnd; i++)
            {
                listBox1.Items.Add(random.Next(1, 10));
                listBox2.Items.Add(random.Next(1, 10));
                listBox3.Items.Add(random.Next(1, 10));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           int add = Convert.ToInt32(textBox2.Text);
           List<int> listA = new List<int>();
           foreach (var item in listBox1.Items)
           {
                listA.Add(Convert.ToInt32(item));
           }
            listBox1.Items.Clear();
           foreach(var item in listA)
           {
                int total = item + add;
                listBox1.Items.Add(total as object);
           }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int add = Convert.ToInt32(textBox3.Text);
            List<int> listB = new List<int>();
            foreach (var item in listBox2.Items)
            {
                listB.Add(Convert.ToInt32(item));
            }
            listBox2.Items.Clear();
            foreach (var item in listB)
            {
                int total = item + add;
                listBox2.Items.Add(total as object);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int add = Convert.ToInt32(textBox4.Text);
            List<int> listC = new List<int>();
            foreach (var item in listBox3.Items)
            {
                listC.Add(Convert.ToInt32(item));
            }
            listBox3.Items.Clear();
            foreach (var item in listC)
            {
                int total = item + add;
                listBox3.Items.Add(total as object);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 1;
            var selectedIndex =  numericUpDown1.Value;
            listBox1.SelectedIndex = (int)selectedIndex - 1;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Minimum = 1;
            var selectedIndex = numericUpDown2.Value;
            listBox2.SelectedIndex = (int)selectedIndex - 1;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown3.Minimum = 1;
            var selectedIndex = numericUpDown3.Value;
            listBox3.SelectedIndex = (int)selectedIndex - 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string aT = listBox1.GetItemText(listBox1.SelectedItem);
            string bT = listBox2.GetItemText(listBox2.SelectedItem);
            string cT = listBox3.GetItemText(listBox3.SelectedItem);
            label7.Text = aT + "X^2 + " + bT + "X + " + cT + " = 0";

            int a = Convert.ToInt32(aT);
            int b = Convert.ToInt32(bT);
            int c = Convert.ToInt32(cT);

            label4.Text = Convert.ToString(findDiscriminant(a, b, c));
            label5.Text = Convert.ToString(findFirstX(a, b, c));
            label6.Text = Convert.ToString(findSecondX(a, b, c));
        }

        public double findDiscriminant(int a, int b, int c)
        {
            var preRoot = b * b - 4 * a * c;
            return preRoot;
        }

        public double findFirstX(int a, int b, int c)
        {
            var preRoot = b * b - 4 * a * c;
            if (preRoot < 0)
            {
                return double.NaN;
            }
            else
            {
                var sgn = 1.0;
                return (sgn * Math.Sqrt(preRoot) - b) / (2.0 * a);
            }
        }

        public double findSecondX(int a, int b, int c)
        {
            var preRoot = b * b - 4 * a * c;
            if (preRoot < 0)
            {
                return double.NaN;
            }
            else
            {
                var sgn = -1.0;
                return (sgn * Math.Sqrt(preRoot) - b) / (2.0 * a);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int left = 3;
            int top = 3;
            for (int x = 0; x < rnd; x++)
            {
                for(int y = 0; y < rnd; y++)
                { 
                    for (int z = 0; z < rnd; z++)
                    {
                        Label label = new Label();
                        label.Location = new Point(left, top);
                        label.Size = new Size(800, 15);
                        string coefficients = "A = " + listBox1.GetItemText(listBox1.Items[x]) + "; B = " + listBox2.GetItemText(listBox2.Items[y]) + "; C = " + listBox3.GetItemText(listBox3.Items[z]) + "; D = ";
                        A = (int) listBox1.Items[x];
                        B = (int) listBox2.Items[y];
                        C = (int) listBox3.Items[z];
                        string D = Convert.ToString(findDiscriminant(A, B, C));
                        string X1 = Convert.ToString(findFirstX(A, B, C));
                        string X2 = Convert.ToString(findSecondX(A, B, C));
                        string results = D + "; X1 = " + X1 + "; X2 = " + X2 + ";";
                        label.Text = coefficients + results;
                        panel2.Controls.Add(label);

                        top = top + 25;
                        left = 3;
                    }
                }
            }
        }
    }
}
