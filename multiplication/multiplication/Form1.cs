using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace multiplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(txtNo1.Text) + Convert.ToInt32(txtNo2.Text);
            txtNo3.Text = i.ToString();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(txtNo1.Text) - Convert.ToInt32(txtNo2.Text);
            txtNo3.Text = i.ToString();
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(txtNo1.Text) * Convert.ToInt32(txtNo2.Text);
            txtNo3.Text = i.ToString();
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            int i = 0;
            MessageBox.Show("Chappa Matter");  
            i = Convert.ToInt32(txtNo1.Text) / Convert.ToInt32(txtNo2.Text);
            txtNo3.Text = i.ToString();
        }

       
    }
}