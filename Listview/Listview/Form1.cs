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
        ListViewItem list = new ListViewItem();
        ColorDialog colorDialog = new ColorDialog();

        int a;
        int b;
        int c;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(numericUpDown1.Value);
            b = Convert.ToInt32(textBox3.Text);
            c = a * b;
            list = new ListViewItem();
            list.UseItemStyleForSubItems = false;
            list.Text = textBox1.Text;
            list.SubItems.Add(textBox2.Text);
            list.SubItems.Add("").BackColor = button1.BackColor;
            list.SubItems.Add(numericUpDown1.Value.ToString());
            list.SubItems.Add(textBox3.Text);
            list.SubItems.Add(c.ToString());
            listView1.Items.Add(list);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                listView1.SelectedItems[i].Remove();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(listView1.Items.Count.ToString());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Checked != true)
                {
                    listView1.Items[i].Checked = true;
                    button8.Text = "Uncheck all";
                }
                else
                {
                    listView1.Items[i].Checked = false;
                    button8.Text = "Check all";
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < listView1.Items.Count; i++)
            {
                if(listView1.Items[i].Selected != true)
                {
                    listView1.Items[i].Selected = true;
                    button9.Text = "Unselect all";
                    listView1.SelectedItems[i].BackColor = System.Drawing.Color.AliceBlue;
                }
                else
                {
                    listView1.Items[i].Selected = false;
                    button9.Text = "Select all";
                    listView1.SelectedItems[i].BackColor = System.Drawing.Color.DarkGray;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listView1.CheckBoxes != true)
            {
                listView1.CheckBoxes = true;
                button7.Text = "Unset checkbox";
            }
            else
            {
                listView1.CheckBoxes = false;
                button7.Text = "Set checkbox";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < listView1.CheckedItems.Count; i++)
            {
                listView1.CheckedItems[i].Remove();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < listView1.Items.Count; i++)
            {
                if(textBox4.Text == listView1.Items[i].Text)
                {
                    textBox1.Text = listView1.Items[i].SubItems[0].Text;
                    textBox2.Text = listView1.Items[i].SubItems[1].Text;
                    textBox3.Text = listView1.Items[i].SubItems[4].Text;
                    button1.BackColor = listView1.Items[i].SubItems[2].BackColor;
                    numericUpDown1.Value = Convert.ToInt32(listView1.Items[i].SubItems[3].Text);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < listView1.Items.Count; i++)
            {
                //id - ile yoxlamaq
                if(listView1.Items[i].SubItems[0].Text == textBox1.Text)
                {
                    listView1.Items[i].SubItems[0].Text = textBox1.Text;
                    listView1.Items[i].SubItems[1].Text = textBox2.Text;
                    listView1.Items[i].SubItems[4].Text = textBox3.Text;
                    listView1.Items[i].SubItems[2].BackColor = button1.BackColor;
                    listView1.Items[i].SubItems[3].Text = numericUpDown1.Value.ToString();
                    int aC = Convert.ToInt32(listView1.Items[i].SubItems[3].Text);
                    int bC = Convert.ToInt32(listView1.Items[i].SubItems[4].Text);
                    int cC = aC * bC;
                    listView1.Items[i].SubItems[5].Text = cC.ToString();
                }
            }
        }
    }
}
