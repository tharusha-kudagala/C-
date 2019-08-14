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
    public partial class pharlog : Form
    {
        public pharlog()
        {
            InitializeComponent();
            if(radioButton1.Checked == true)
            {
                label1.Show();label2.Show();label3.Show();label4.Show();label5.Show();
                textBox1.Show();textBox2.Show();textBox3.Show();textBox4.Show();textBox5.Show();
                button1.Show();button2.Hide();button3.Hide();
            }
        }
        bool typeCheck = true;
        
        private void pharlog_Load(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * FROM pharmacy WHERE drug_id LIKE '" + textBox1.Text + "%'";

            SqlDataAdapter Adp = new SqlDataAdapter(qry, con);
            DataSet set = new DataSet();
            Adp.Fill(set, "pharmacy");
            dataGridView1.DataSource = set.Tables["pharmacy"];
        }

        private void textBox1_Leave(object sender, EventArgs e)
        { if(typeCheck == true)
            {
                if (textBox1.Text.Contains("C"))
                {
                    label6.Text = "Capsules";
                    label6.Show();
                }
                else if (textBox1.Text.Contains("T"))
                {
                    label6.Text = "Tablets";
                    label6.Show();
                }
                else if (textBox1.Text.Contains("S"))
                {
                    label6.Text = "Bottles";
                    label6.Show();
                }
            }
            
        }

       

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            pharlog_Load(e, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Fill required fields");
            }
            else if (textBox1.Text.Length!=5)
            {
                MessageBox.Show("Invalid Drug ID");
            }
            else
            {
                
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "INSERT INTO pharmacy VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Already Added");

                }
                finally
                {
                    pharlog_Load(e, e);
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Show(); label2.Show(); label3.Show(); label4.Show(); label5.Show();
            textBox1.Show(); textBox2.Show(); textBox3.Show(); textBox4.Show(); textBox5.Show();
            button2.Show();button1.Hide();button3.Hide();typeCheck = true;
            textBox1.Clear();textBox2.Clear();textBox3.Clear();textBox4.Clear();textBox5.Clear();
            pharlog_Load(e, e);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Show(); label2.Show(); label3.Show(); label4.Show(); label5.Show();
            textBox1.Show(); textBox2.Show(); textBox3.Show(); textBox4.Show(); textBox5.Show();
            button1.Show(); button2.Hide();button3.Hide();typeCheck = true;
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear();
            pharlog_Load(e, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Fill required fields");
            }
            else if (textBox1.Text.Length != 5)
            {
                MessageBox.Show("Invalid Drug ID");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30");
                string qry = "UPDATE pharmacy SET drug_id = '" + textBox1.Text + "', drug_name = '" + textBox2.Text + "', dosage = '" + textBox3.Text + "', price='" + textBox4.Text + "', availability='" + textBox5.Text + "' WHERE drug_id = '" + textBox1.Text + "'";
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated");
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message.ToString());
                }
                finally
                {
                    pharlog_Load(e, e);
                }
            }
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button3.Show();button1.Hide();button2.Hide();
            textBox1.Show();textBox2.Hide();textBox3.Hide();textBox4.Hide();textBox5.Hide();
            label1.Show();label2.Hide();label3.Hide();label4.Hide();label5.Hide();label6.Hide();
            typeCheck = false;
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear();
            pharlog_Load(e, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 5)
                MessageBox.Show("Invalid Drug ID");
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30");
                string qry = "DELETE FROM pharmacy WHERE drug_id = '" + textBox1.Text + "'";
                con.Open();

                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Removed");
                pharlog_Load(e, e);
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 hi = new Form1();
            string ph = Form1.phrm;
            if(ph == "admin")
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
