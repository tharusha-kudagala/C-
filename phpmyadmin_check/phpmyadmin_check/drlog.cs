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
    public partial class drlog : Form
    {
        public drlog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { if(textBox1.Text.Length==7)
            {
                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30";
                string qry = "SELECT * FROM patient WHERE UPIN LIKE '" + textBox1.Text.Trim() + "%'";

                SqlDataAdapter Adp = new SqlDataAdapter(qry, con);
                DataSet set = new DataSet();
                Adp.Fill(set, "patient");
                dataGridView1.DataSource = set.Tables["patient"];
            }
        else
            {
                MessageBox.Show("Invalid UPIN");
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * FROM patient WHERE UPIN LIKE '" + textBox1.Text.Trim() + "%'";

            SqlDataAdapter Adp = new SqlDataAdapter(qry, con);
            DataSet set = new DataSet();
            Adp.Fill(set, "patient");
            dataGridView1.DataSource = set.Tables["patient"];

            
        }
        public void update()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30");
            string update = "UPDATE pre SET drug_1='" + comboBox1.SelectedItem +"', drug_1_Qty='" + textBox2.Text + "', drug_2='" + comboBox2.SelectedItem + "',  drug_2_Qty='" + textBox3.Text + "', drug_3='" + comboBox3.SelectedItem + "', drug_3_Qty='" + textBox4.Text + "', drug_4='" + comboBox4.SelectedItem + "', drug_4_Qty='" + textBox5.Text + "', drug_5='" + comboBox5.SelectedItem + "', drug_5_Qty='" + textBox5.Text + "' WHERE upin='" + textBox1.Text + "'";
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || comboBox1.SelectedItem == null || textBox2.Text=="")
            {
                MessageBox.Show("Fill required fields");
            }
            else if(textBox1.Text.Length != 7)
            {
                MessageBox.Show("Invalid UPIN");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30");
                string qry = "INSERT into pre values('" + textBox1.Text + "','" + comboBox1.SelectedItem + "','" + textBox2.Text + "','" + comboBox2.SelectedItem + "','" + textBox3.Text + "','" + comboBox3.SelectedItem + "','" + textBox4.Text + "','" + comboBox4.SelectedItem + "','" + textBox5.Text + "','" + comboBox5.SelectedText + "','" + textBox6.Text + "')";
               
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception)
                {
                    update();
                }
                finally
                {
                    con.Close();
                }

                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30";
                string qryy = "SELECT * FROM pre WHERE UPIN ='"+textBox1.Text.Trim()+"'";

                SqlDataAdapter Adp = new SqlDataAdapter(qryy, conn);
                DataSet set = new DataSet();
                Adp.Fill(set, "pre");
                dataGridView2.DataSource = set.Tables["pre"];

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            this.Hide();
            obj.Show();
        }
    }
}
