using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace OracleDbConnection
{
    public partial class Form1 : Form
    {
        String strcon = "Data Source= (DESCRIPTION =" +
            "(ADDRESS = (PROTOCOL = TCP)(HOST = 10.12.38.64)(PORT = 1521))" +
            "(CONNECT_DATA =" +
            "(SERVER = DEDICATED)" +
            "(SERVICE_NAME = orcl)" +
            ")" +
            "); User ID=ilqar; Password=abbasov;";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(strcon);
            con.Open();
            OracleCommand cmd = new OracleCommand("Select * from employee", con);
            OracleDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(strcon);
            con.Open();
            OracleCommand cmd = new OracleCommand("Insert into employee values(:id, :name, :surname, :salary)", con);
            cmd.Parameters.Add(new OracleParameter(":id", int.Parse(textBox1.Text)));
            cmd.Parameters.Add(new OracleParameter(":name", (textBox2.Text)));
            cmd.Parameters.Add(new OracleParameter(":surname", (textBox3.Text)));
            cmd.Parameters.Add(new OracleParameter(":salary", int.Parse(textBox4.Text)));
            cmd.ExecuteNonQuery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(strcon);
            con.Open();
            OracleCommand cmd = new OracleCommand("delete from employee where empno=:id", con);
            cmd.Parameters.Add(new OracleParameter(":id", int.Parse(textBox1.Text)));

            cmd.ExecuteNonQuery();
            con.Close();
            button1.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(strcon);
            con.Open();
            OracleCommand cmd = new OracleCommand("Update employee set empname=:name where empno=:id", con);
            cmd.Parameters.Add(new OracleParameter(":name", (textBox2.Text)));
            cmd.Parameters.Add(new OracleParameter(":id", int.Parse(textBox1.Text)));

            cmd.ExecuteNonQuery();
            con.Close();
            button1.PerformClick();
        }
    }
}
