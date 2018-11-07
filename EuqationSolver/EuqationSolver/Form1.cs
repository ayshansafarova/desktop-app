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
            int b = Convert.ToInt32(aT);
            int c = Convert.ToInt32(aT);

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
            //Label[] labels = new Label[n];
            //int i = listBox1.Items.Count * listBox2.Items.Count * listBox3.Items.Count;
            for (int x = 1; x <= listBox1.Items.Count; x++)
            {
                Label[] labels = new Label[x];
                labels[x].Text = listBox1.GetItemText(listBox1.Items[x]);
                A = Convert.ToInt32(labels[x].Text);
                for (int y = 1; y <= listBox2.Items.Count; y++)
                {
                    Label[] labels2 = new Label[y];
                    labels2[y].Text = listBox2.GetItemText(listBox2.Items[y]);
                    B = Convert.ToInt32(labels2[y].Text);
                    for (int z = 1; z <= listBox3.Items.Count; z++)
                    {
                        Label[] labels3 = new Label[z];
                        Label[] labels4 = new Label[3];
                        labels3[z].Text = listBox3.GetItemText(listBox3.Items[z]);
                        C = Convert.ToInt32(labels3[z].Text);
                        labels4[0].Text = Convert.ToString(findDiscriminant(A, B, C));
                        labels4[1].Text = Convert.ToString(findFirstX(A, B, C));
                        labels4[2].Text = Convert.ToString(findSecondX(A, B, C));
                        panel2.Controls.Add(labels[x]);
                        panel2.Controls.Add(labels[y]);
                        panel2.Controls.Add(labels[z]);
                    }
                }
            }
        }
    }
}
