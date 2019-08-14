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
    public partial class Form1 : Form
    {
        public static string phrm ="";
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '•';
                
        }
       // public bool back;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Contains("A"))
            {
                phrm = "admin";
                
            }
            else 
            {
                phrm = "login";
                
            }


            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\HMS.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * From login WHERE username = '"+textBox1.Text.Trim()+"' and password = '"+textBox2.Text.Trim()+"'";
            SqlDataAdapter adp = new SqlDataAdapter(qry, con);
            DataTable tb = new DataTable();
            adp.Fill(tb);
            
            if (tb.Rows.Count == 1 && textBox1.Text.Contains("D") && textBox1.Text.Length == 4)
            {
                drlog obj = new drlog();
                this.Hide();
                obj.Show();
            }

            else if (tb.Rows.Count == 1 && textBox1.Text.Contains("P") && textBox1.Text.Length == 3)
            {
                phrm = "p";
                pharlog obj = new pharlog();
                this.Hide();
                obj.Show();
            }


            else if (tb.Rows.Count == 1 && textBox1.Text.Contains("A") && textBox1.Text.Length == 2)
            {
                Adminlog obj = new Adminlog();
                this.Hide();
                obj.Show();
            }

            else if (tb.Rows.Count == 1 && textBox1.Text.Contains("R") && textBox1.Text.Length == 3)
            {
                PatientDB obj = new PatientDB();
                this.Hide();
                obj.Show();
            }
            else
                MessageBox.Show("Invalid Username or Password");
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(e,e);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
