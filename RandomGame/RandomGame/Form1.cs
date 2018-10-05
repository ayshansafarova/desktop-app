using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int dice11 = 0;
        int dice12 = 0;
        int dice21 = 0;
        int dice22 = 0;
        int total1 = 0;
        int total2 = 0;
        int count1 = 0;
        int count2 = 0;

        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Limit is 30!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dice11 = random.Next(1, 7);
            dice12 = random.Next(1, 7);
            total1 = total1 + (dice11 + dice12);
            label2.Text = Convert.ToString(dice11);
            label4.Text = Convert.ToString(dice12);
            label6.Text = Convert.ToString(total1);
            label14.Text = Convert.ToString(total1) + "%";
            progressBar1.Value = total1;
            count1++;
            setPicture(dice11, pictureBox1);
            setPicture(dice12, pictureBox2);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dice21 = random.Next(1, 7);
            dice22 = random.Next(1, 7);
            total2 = total2 + (dice21 + dice22);
            label11.Text = Convert.ToString(dice21);
            label9.Text = Convert.ToString(dice22);
            label7.Text = Convert.ToString(total2);
            label19.Text = Convert.ToString(total2) + "%";
            progressBar2.Value = total2;
            count2++;
            setPicture(dice21, pictureBox1);
            setPicture(dice22, pictureBox2);
            checkWinner();
        }

        public void setPicture(int i, PictureBox pbox)
        {
                pbox.ImageLocation = @"C:\Users\admin\source\repos\RandomGame\RandomGame\img\"
                                                    + i +".png";
                pbox.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public void checkWinner()
        {
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar2.Maximum = 100;
            if (total1 >= 30 || total2 >= 30)
            {
                    label15.Text = Convert.ToString(total1);
                    label17.Text = Convert.ToString(total2);
                    if(total1 > total2)
                    {
                        label16.ForeColor = Color.Red;
                        MessageBox.Show("Winner is Player 1 ------ " +
                                        "Click OK to restart");
                    }else if(total2 > total1)
                    {
                        label18.ForeColor = Color.Red;
                        MessageBox.Show("Winner is Player 2! ------ " +
                                        "Click OK to restart");
                    }
             
                    dice11 = 0;
                    dice12 = 0;
                    dice21 = 0;
                    dice22 = 0;
                    total1 = 0;
                    total2 = 0;
                progressBar1.Value = 0;
                progressBar2.Value = 0;
                label2.Text = "0";
                label4.Text = "0";
                label11.Text = "0";
                label9.Text = "0";
                label6.Text = "0";
                label7.Text = "0";
                label15.Text = "0";
                label17.Text = "0";
            }
        }
    }
}
