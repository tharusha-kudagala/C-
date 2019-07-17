using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;

namespace phpmyadmin_check
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("D") && textBox1.Text.Length == 4)
            {
                drlog obj = new drlog();
                this.Hide();
                obj.Show();
            }
            else if (textBox1.Text.Contains("P") && textBox1.Text.Length == 3)
            {
                pharlog obj = new pharlog();
                this.Hide();
                obj.Show();
            }
            else if (textBox1.Text.Contains("A") && textBox1.Text.Length == 2)
            {
                Adminlog obj = new Adminlog();
                this.Hide();
                obj.Show();
            }
            else
                MessageBox.Show("Invalid Username");

        }
    }
}
