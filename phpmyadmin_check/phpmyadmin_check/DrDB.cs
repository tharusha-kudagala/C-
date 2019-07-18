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

namespace phpmyadmin_check
{
    public partial class DrDB : Form
    {
        public DrDB()
        {
            InitializeComponent();
            textBox4.PasswordChar = '•';
        }
        int x = 0;
        private void DrDB_Load(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * From login WHERE username LIKE 'D%'";

            SqlDataAdapter adp = new SqlDataAdapter(qry, con);
            DataSet set = new DataSet();
            adp.Fill(set, "login");
            dataGridView1.DataSource = set.Tables["login"];
            if(radioButton1.Checked == true)
            {
                label1.Show(); label2.Show(); label3.Show(); label4.Show();
                textBox1.Show(); textBox2.Show(); textBox3.Show(); textBox4.Show();
                button1.Show(); button2.Hide(); button3.Hide();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || textBox2.Text=="" || textBox3.Text=="" || textBox4.Text=="")
            {
                MessageBox.Show("Fill all the fields");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                try
                {
                    string insert = "INSERT INTO login VALUES ('" + textBox3.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "')";
                    SqlCommand cmd = new SqlCommand(insert, con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Entry already added !");
                }
                finally
                {
                    con.Close();
                }
            }
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Show();label2.Show();label3.Show();label4.Show();
            textBox1.Show();textBox2.Show();textBox3.Show();textBox4.Show();
            button1.Show();button2.Hide();button3.Hide();
            textBox1.Clear();textBox2.Clear(); textBox3.Clear();textBox4.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Show();label2.Show();label3.Show();label4.Show();
            textBox1.Show(); textBox2.Show();textBox3.Show(); textBox4.Show();
            button1.Hide(); button2.Show();button3.Hide();
            textBox1.Clear(); textBox2.Clear();textBox3.Clear();textBox4.Clear();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Hide();label2.Show();label3.Hide();label4.Hide();
            textBox1.Hide();textBox2.Hide();textBox3.Show();textBox4.Hide();
            button1.Hide(); button2.Hide(); button3.Show();
            textBox3.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   if(x%2 == 0)
            {
                DrDB_Load(e, e);
            }
        else
            DrDB_Load(e,e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Fill all the fields");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string update = "UPDATE login SET username = '" + textBox3.Text + "',name='" + textBox1.Text + "',designation='" + textBox2.Text + "',password='" + textBox4.Text + "' WHERE username='" + textBox3.Text + "'";
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Succesfully Updated");
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {   if (textBox3.Text == "")
                MessageBox.Show("Enter the Username");

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string delete = "DELETE FROM login WHERE username='"+textBox3.Text+"'";
            SqlCommand cmd = new SqlCommand(delete, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Succesfully Deleted");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Adminlog obj = new Adminlog();
            this.Hide();
            obj.Show();
        }
    }
}
