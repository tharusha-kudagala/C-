﻿using System;
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

        private void Adminlog_Load(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            string uname = Convert.ToString(obj.User());
            label1.Text = uname;
            
        }
    }
}
