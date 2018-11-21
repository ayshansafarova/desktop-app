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
    public partial class LoginForm : Form
    {
        string constr = "Data Source=.;Initial Catalog=hotelDB;Integrated Security=True";
        public LoginForm()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm rf = new RegisterForm();
            rf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("No missed field!!!");
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "Select * from register where username = @uname and pass = @upass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@uname", (textBox1.Text.Trim()));
                cmd.Parameters.AddWithValue("@upass", (textBox2.Text.Trim()));

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet("users");
                adp.Fill(ds);
                //con.Close();

                int count = ds.Tables[0].Rows.Count;
                if(count == 1)
                {
                    this.Hide();
                    DashboardForm df = new DashboardForm();
                    df.Show();
                }
                else
                {
                    MessageBox.Show("Login failed!!!");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


        }
    }
}
