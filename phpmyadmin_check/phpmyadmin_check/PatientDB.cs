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
    public partial class PatientDB : Form
    {
        public PatientDB()
        {
            InitializeComponent();
            if (radioButton1.Checked == true)
            {
                label1.Show(); label2.Show(); label3.Show(); label4.Show(); label5.Show(); label6.Show(); label7.Show();
                textBox1.Show(); textBox2.Show(); textBox3.Show(); textBox4.Show(); comboBox1.Show(); comboBox2.Show();
                button1.Show(); dateTimePicker1.Show(); button2.Hide();button3.Hide();label8.Hide();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); comboBox1.SelectedIndex = -1; comboBox2.SelectedIndex = -1;

            }
        }
        int x = 0;
        private void PatientDB_Load(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * FROM patient WHERE UPIN LIKE '" + textBox1.Text.Trim() + "%'";

            SqlDataAdapter Adp = new SqlDataAdapter(qry, con);
            DataSet set = new DataSet();
            Adp.Fill(set, "patient");
            dataGridView1.DataSource = set.Tables["patient"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Fill required fields");
            }
            else if (textBox1.Text.Length != 7)
            {
                MessageBox.Show("Invalid UPIN");
            }
            else
            {

                int age = DateTime.Today.Year - dateTimePicker1.Value.Year;
                label8.Text = age.ToString() + " years";
                label8.Show();


                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "INSERT INTO patient VALUES ('" + textBox1.Text + "','" + comboBox1.SelectedItem + "','" + textBox2.Text + "','" + comboBox2.SelectedItem + "','" + age + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Already Added");

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (x % 2 == 0)
                PatientDB_Load(e, e);
            else
                PatientDB_Load(e, e);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Show(); label2.Show(); label3.Show(); label4.Show(); label5.Show(); label6.Show(); label7.Show();
            textBox1.Show(); textBox2.Show(); textBox3.Show(); textBox4.Show(); comboBox1.Show(); comboBox2.Show();
            button1.Show();button2.Hide();dateTimePicker1.Show();button3.Hide(); label8.Hide();
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); comboBox1.SelectedIndex = -1; comboBox2.SelectedIndex = -1;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Show(); label2.Show(); label3.Show(); label4.Show(); label5.Show(); label6.Show(); label7.Show();
            textBox1.Show(); textBox2.Show(); textBox3.Show(); textBox4.Show(); comboBox1.Show(); comboBox2.Show();
            button2.Show();button1.Hide(); dateTimePicker1.Show();button3.Hide(); label8.Hide();
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); comboBox1.SelectedIndex = -1; comboBox2.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Fill required fields");
            }
            else if (textBox1.Text.Length != 7)
            {
                MessageBox.Show("Invalid UPIN");
            }
            else
            {

                int age = DateTime.Today.Year - dateTimePicker1.Value.Year;
                label8.Text = age.ToString() + " years";
                label8.Show();

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30");
                string qry = "UPDATE patient SET UPIN = '" + textBox1.Text + "', name = '"+textBox2.Text+"', title='"+comboBox1.SelectedItem+"', gender = '"+comboBox2.Text+"',age = '"+age+"', address='"+textBox3.Text+"',telephone='"+textBox4.Text+"' WHERE UPIN = '"+textBox1.Text+"'";
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated");
                }
                catch(Exception)
                {
                    MessageBox.Show("Invalid UPIN ");
                }
                
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button3.Show();button1.Hide();button2.Hide();
            label1.Hide();comboBox1.Hide();label3.Hide();textBox2.Hide();
            label4.Hide();comboBox2.Hide();label5.Hide();textBox3.Hide(); label8.Hide();
            dateTimePicker1.Hide();label6.Hide();textBox4.Hide();label7.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter the UPIN");
            }
            else if(textBox1.Text.Length != 7)
            {
                MessageBox.Show("Invalid UPIN");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30");
                string qry = "DELETE FROM patient WHERE UPIN = '"+textBox1.Text+"'";
                con.Open();

                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Removed");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 hi = new Form1();
            string ph = Form1.phrm;
            if (ph == "admin")
            {
                Adminlog obj = new Adminlog();
                this.Hide();
                obj.Show();

            }
            else
            {
                this.Hide();
                hi.Show();
            }
        }
    }
}
