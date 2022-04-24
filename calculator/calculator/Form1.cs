using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {

        public bool  isOperator = false;
        public string operatorType = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            btnResult.Text = "0";
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            btnResult.Text = "1";
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            btnResult.Text = "2";
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            btnResult.Text = "3";
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            btnResult.Text = "4";
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            btnResult.Text = "5";
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            btnResult.Text = "6";
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            btnResult.Text = "7";
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            btnResult.Text = "8";
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            btnResult.Text = "9";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isOperator = true;
            operatorType = "+";
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            isOperator = true;
            operatorType = "-";
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            isOperator = true;
            operatorType = "*";
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            isOperator = true;
            operatorType = "/";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}