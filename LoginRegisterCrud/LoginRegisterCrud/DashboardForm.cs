using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginRegisterCrud
{
    public partial class DashboardForm : Form
    {
        string constr = "Data Source=.;Initial Catalog=hotelDB;Integrated Security=True";
        const int dayPrice = 20;
        byte[] bimage = null;
        //int countNext = 0;
        //int countPrev = 0;
        int currentId = 0;
        int minId;
        int maxId;
        bool isClicked = false;

        public DashboardForm()
        {
            InitializeComponent();
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        //select
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from customer", con);
            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        //insert
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "insert into customer values(@fname,@room,@person,@day,@price,@picture)";
            SqlCommand cmd = new SqlCommand(query, con);
            int p = int.Parse(textBox4.Text.Trim());
            int d = int.Parse(textBox5.Text.Trim());
            int price = p * d * dayPrice;
            cmd.Parameters.AddWithValue("@fname", (textBox2.Text.Trim()));
            cmd.Parameters.AddWithValue("@room", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@person", p);
            cmd.Parameters.AddWithValue("@day", d);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@picture", bimage);
            cmd.ExecuteNonQuery();
            button1.PerformClick();
        }

        //imageclick
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
            }
            string image = open.FileName;
            Bitmap bmp = new Bitmap(image);
            FileStream fs = new FileStream(image, FileMode.Open, FileAccess.Read);
            bimage = new byte[fs.Length];
            fs.Read(bimage, 0, Convert.ToInt32(fs.Length));
            fs.Close();
        }

        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "delete from customer where id = @cid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@cid", int.Parse(textBox1.Text));
            //SqlCommand _cmd = new SqlCommand("DBCC CHECKIDENT('customer', RESEED, 0)", con);
            cmd.ExecuteNonQuery();
            //_cmd.ExecuteNonQuery();
            con.Close();
            button1.PerformClick();
        }

        //update
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "update customer set room_number = @room, " +
                "persons_count = @person, days_count = @day, " +
                "price = @price  where id = @cid";
            SqlCommand cmd = new SqlCommand(query, con);
            int p = int.Parse(textBox4.Text.Trim());
            int d = int.Parse(textBox5.Text.Trim());
            int price = p * d * dayPrice;
            cmd.Parameters.AddWithValue("@room", int.Parse(textBox3.Text.Trim()));
            cmd.Parameters.AddWithValue("@person", p);
            cmd.Parameters.AddWithValue("@day", d);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@cid", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            button1.PerformClick();
        }

        //first
        private void button5_Click(object sender, EventArgs e)
        {
            isClicked = true;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand _cmd = new SqlCommand("Select MIN(id) from customer", con);
            minId = Convert.ToInt32(_cmd.ExecuteScalar());
            currentId = minId;
            SqlCommand cmd = new SqlCommand("Select * from customer where id = @id", con);
            cmd.Parameters.AddWithValue("@id", minId);
            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable("first");
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            textBox1.Text = Convert.ToString(dt.Rows[0]["id"]);
            textBox2.Text = Convert.ToString(dt.Rows[0]["full_name"]);
            textBox3.Text = Convert.ToString(dt.Rows[0]["room_number"]);
            textBox4.Text = Convert.ToString(dt.Rows[0]["persons_count"]);
            textBox5.Text = Convert.ToString(dt.Rows[0]["days_count"]);

            byte[] image = new byte[0];
            image = (byte[])dt.Rows[0]["picture"];
            MemoryStream stream = new MemoryStream(image);
            pictureBox1.Image = Image.FromStream(stream);
            con.Close();
        }

        //last
        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand _cmd = new SqlCommand("Select MAX(id) from customer", con);
            maxId = Convert.ToInt32(_cmd.ExecuteScalar());
            currentId = maxId;
            SqlCommand cmd = new SqlCommand("Select * from customer where id = @id", con);
            cmd.Parameters.AddWithValue("@id", maxId);
            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable("last");
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            textBox1.Text = Convert.ToString(dt.Rows[0]["id"]);
            textBox2.Text = Convert.ToString(dt.Rows[0]["full_name"]);
            textBox3.Text = Convert.ToString(dt.Rows[0]["room_number"]);
            textBox4.Text = Convert.ToString(dt.Rows[0]["persons_count"]);
            textBox5.Text = Convert.ToString(dt.Rows[0]["days_count"]);

            byte[] image = new byte[0];
            image = (byte[])dt.Rows[0]["picture"];
            MemoryStream stream = new MemoryStream(image);
            pictureBox1.Image = Image.FromStream(stream);
            con.Close();
        }

        //next
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand _cmd = new SqlCommand("Select MIN(id) from customer", con);
            int minId = Convert.ToInt32(_cmd.ExecuteScalar());
            if(currentId >= (maxId + 1))
            {
                MessageBox.Show("It is the last");
            }
            else
            {
                currentId = currentId + 1;
            }
            
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from customer where id = @id", con);
                cmd.Parameters.AddWithValue("@id", currentId);
                SqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable("next");
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                textBox1.Text = Convert.ToString(dt.Rows[0]["id"]);
                textBox2.Text = Convert.ToString(dt.Rows[0]["full_name"]);
                textBox3.Text = Convert.ToString(dt.Rows[0]["room_number"]);
                textBox4.Text = Convert.ToString(dt.Rows[0]["persons_count"]);
                textBox5.Text = Convert.ToString(dt.Rows[0]["days_count"]);

                byte[] image = new byte[0];
                image = (byte[])dt.Rows[0]["picture"];
                MemoryStream stream = new MemoryStream(image);
                pictureBox1.Image = Image.FromStream(stream);
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("This is the last", ex.Message);
            }
        }

        //previous
        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand _cmd = new SqlCommand("Select MAX(id) from customer", con);
            int maxId = Convert.ToInt32(_cmd.ExecuteScalar());
            if(currentId <= (minId - 1) && isClicked)
            {
                MessageBox.Show("This is the first");
            }
            else
            {
                currentId = currentId - 1;
            }
            
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from customer where id = @id", con);
                cmd.Parameters.AddWithValue("@id", currentId);
                SqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable("prev");
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                textBox1.Text = Convert.ToString(dt.Rows[0]["id"]);
                textBox2.Text = Convert.ToString(dt.Rows[0]["full_name"]);
                textBox3.Text = Convert.ToString(dt.Rows[0]["room_number"]);
                textBox4.Text = Convert.ToString(dt.Rows[0]["persons_count"]);
                textBox5.Text = Convert.ToString(dt.Rows[0]["days_count"]);

                byte[] image = new byte[0];
                image = (byte[])dt.Rows[0]["picture"];
                MemoryStream stream = new MemoryStream(image);
                pictureBox1.Image = Image.FromStream(stream);
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("This is the first", ex.Message);
            }
        }

        //logout
        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lf = new LoginForm();
            lf.Show();
        }
    }
}
