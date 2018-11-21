using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginRegisterCrud
{
    public partial class RegisterForm : Form
    {
        string constr = "Data Source=.;Initial Catalog=hotelDB;Integrated Security=True";
        public RegisterForm()
        {
            InitializeComponent();
            textBox4.PasswordChar = '*';
            textBox5.PasswordChar = '*';
            reset();
        }

        
        public void reset()
        {
            button2.Enabled = false;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7
.Enabled = false;
        }

        public void checkLastValidation(SqlCommand cmd, SqlConnection con)
        {
            string query = "Select * from register where username = @uname";
            SqlCommand cmdSelect = new SqlCommand(query, con);
            cmdSelect.Parameters.AddWithValue("@uname", (textBox3.Text));

            SqlDataAdapter adp = new SqlDataAdapter(cmdSelect);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            int count = ds.Tables[0].Rows.Count;
            if (count >= 1)
            {
               MessageBox.Show("This username has taken");
               reset();
            }
            else
            {
                cmd.ExecuteNonQuery();
                con.Close();
                this.Hide();
                DashboardForm df = new DashboardForm();
                df.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "insert into register values(@fname,@lname,@uname,@pass,@cpass,@bdate,@addres)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@fname", (textBox1.Text.Trim()));
            cmd.Parameters.AddWithValue("@lname", (textBox2.Text.Trim()));
            cmd.Parameters.AddWithValue("@uname", (textBox3.Text.Trim()));
            cmd.Parameters.AddWithValue("@pass", (textBox4.Text.Trim()));
            cmd.Parameters.AddWithValue("@cpass", (textBox5.Text.Trim()));
            cmd.Parameters.AddWithValue("@bdate", (textBox6.Text.Trim()));
            cmd.Parameters.AddWithValue("@addres", (textBox7.Text.Trim()));
            checkLastValidation(cmd, con);
        }

        #region Manipulation of textboxes
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox2.Enabled = true;
                this.SelectNextControl(textBox1, true, true, true, true);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox3.Enabled = true;
                this.SelectNextControl(textBox2, true, true, true, true);
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox5.Enabled = true;
                this.SelectNextControl(textBox4, true, true, true, true);
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox6.Enabled = true;
                this.SelectNextControl(textBox5, true, true, true, true);
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox7.Enabled = true;
                this.SelectNextControl(textBox6, true, true, true, true);
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button2.Enabled = true;
                this.SelectNextControl(textBox7, true, true, true, true);
            }
        }
        #endregion

        #region Validation of textboxes
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Missing field!");
                e.Cancel = true;
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Missing field!");
                e.Cancel = true;
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Missing field!");
                e.Cancel = true;
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Missing field!");
                e.Cancel = true;
            }
            else if(textBox4.Text.Length < 6)
            {
                MessageBox.Show("Minimum length should be 6");
                e.Cancel = true;
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Missing field!");
                e.Cancel = true;
            }
            else if(textBox5.Text != textBox4.Text)
            {
                MessageBox.Show("This retyped password doesn't seem same as previous password");
                e.Cancel = true;
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox6.Text))
            {
                e.Cancel = true;
            }
            else if(textBox6.Text.Length != 10)
            {
                MessageBox.Show("Format is wrong. Ex: 08.03.1997");
                e.Cancel = true;
            }
            else if (!textBox6.Text.Contains("."))
            {
                MessageBox.Show("Don't miss point");
                e.Cancel = true;
            }
        }

        #endregion

    }
}
