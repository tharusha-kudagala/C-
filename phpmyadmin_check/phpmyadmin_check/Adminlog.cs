using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phpmyadmin_check
{
    public partial class Adminlog : Form
    {
        public Adminlog()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Adminlog_Load(object sender, EventArgs e)
        { 
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void addDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            this.Hide();
            obj.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DrDB obj = new DrDB();
            this.Hide();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PatientDB obj = new PatientDB();
            this.Hide();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pharlog obj = new pharlog();
            this.Hide();
            obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Register obj = new Register();
            this.Hide();
            obj.Show();
        }
    }
}
