using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Listview
{
    public partial class PhaseControl : Form
    {
        public PhaseControl()
        {
            InitializeComponent();
        }

        private void PhaseControl_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cASDataSet.NotificationRules' table. You can move, or remove it, as needed.
            this.notificationRulesTableAdapter.Fill(this.cASDataSet.NotificationRules);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}