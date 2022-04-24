namespace Listview
{
    partial class PhaseControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecordingPhaseNo = new System.Windows.Forms.Label();
            this.lblRecordingNo = new System.Windows.Forms.Label();
            this.lblAStatus = new System.Windows.Forms.Label();
            this.lblMStatus = new System.Windows.Forms.Label();
            this.lblEStatus = new System.Windows.Forms.Label();
            this.lblAgreed = new System.Windows.Forms.Label();
            this.lblManager = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.btnFreshAudit = new System.Windows.Forms.Button();
            this.lblAgreedRating = new System.Windows.Forms.Label();
            this.lbManagerRating = new System.Windows.Forms.Label();
            this.lblEmployeeRating = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ruleNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phaseNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phaseTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notificationTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beforeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retriesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retryDurationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notificationRulesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cASDataSet = new Listview.CASDataSet();
            this.notificationRulesTableAdapter = new Listview.CASDataSetTableAdapters.NotificationRulesTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationRulesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cASDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(-4, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1057, 617);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.dateTimePicker4);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.dateTimePicker3);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.dateTimePicker1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dateTimePicker2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.lblRecordingPhaseNo);
            this.tabPage2.Controls.Add(this.lblRecordingNo);
            this.tabPage2.Controls.Add(this.lblAStatus);
            this.tabPage2.Controls.Add(this.lblMStatus);
            this.tabPage2.Controls.Add(this.lblEStatus);
            this.tabPage2.Controls.Add(this.lblAgreed);
            this.tabPage2.Controls.Add(this.lblManager);
            this.tabPage2.Controls.Add(this.lblEmployee);
            this.tabPage2.Controls.Add(this.btnFreshAudit);
            this.tabPage2.Controls.Add(this.lblAgreedRating);
            this.tabPage2.Controls.Add(this.lbManagerRating);
            this.tabPage2.Controls.Add(this.lblEmployeeRating);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1049, 588);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Phase Control";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(492, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 27);
            this.button1.TabIndex = 58;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(776, 405);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 17);
            this.label9.TabIndex = 57;
            this.label9.Text = "days";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(685, 401);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(80, 22);
            this.textBox4.TabIndex = 56;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(616, 406);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 17);
            this.label10.TabIndex = 55;
            this.label10.Text = "Duration";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.CustomFormat = "d-mmm-yyyy h:m:s tt";
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker4.Location = new System.Drawing.Point(409, 401);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker4.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(776, 364);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 53;
            this.label7.Text = "days";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(684, 360);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(80, 22);
            this.textBox3.TabIndex = 52;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(616, 365);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 17);
            this.label8.TabIndex = 51;
            this.label8.Text = "Duration";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CustomFormat = "d-mmm-yyyy h:m:s tt";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(409, 360);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker3.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(776, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 49;
            this.label5.Text = "days";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(685, 318);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(80, 22);
            this.textBox2.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(616, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 47;
            this.label6.Text = "Duration";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "d-mmm-yyyy h:m:s tt";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(409, 318);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(776, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 45;
            this.label4.Text = "days";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(684, 274);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 22);
            this.textBox1.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(616, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "Duration";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "d-mmm-yyyy h:m:s tt";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(409, 274);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(244, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "Start Admin Activities on";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(213, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "Admin Activities Status";
            // 
            // lblRecordingPhaseNo
            // 
            this.lblRecordingPhaseNo.AutoSize = true;
            this.lblRecordingPhaseNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordingPhaseNo.Location = new System.Drawing.Point(220, 45);
            this.lblRecordingPhaseNo.Name = "lblRecordingPhaseNo";
            this.lblRecordingPhaseNo.Size = new System.Drawing.Size(143, 17);
            this.lblRecordingPhaseNo.TabIndex = 35;
            this.lblRecordingPhaseNo.Text = "Recording Phase No.";
            // 
            // lblRecordingNo
            // 
            this.lblRecordingNo.AutoSize = true;
            this.lblRecordingNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordingNo.Location = new System.Drawing.Point(363, 48);
            this.lblRecordingNo.Name = "lblRecordingNo";
            this.lblRecordingNo.Size = new System.Drawing.Size(0, 17);
            this.lblRecordingNo.TabIndex = 34;
            // 
            // lblAStatus
            // 
            this.lblAStatus.AutoSize = true;
            this.lblAStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAStatus.Location = new System.Drawing.Point(363, 146);
            this.lblAStatus.Name = "lblAStatus";
            this.lblAStatus.Size = new System.Drawing.Size(0, 17);
            this.lblAStatus.TabIndex = 33;
            // 
            // lblMStatus
            // 
            this.lblMStatus.AutoSize = true;
            this.lblMStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMStatus.Location = new System.Drawing.Point(363, 113);
            this.lblMStatus.Name = "lblMStatus";
            this.lblMStatus.Size = new System.Drawing.Size(0, 17);
            this.lblMStatus.TabIndex = 32;
            // 
            // lblEStatus
            // 
            this.lblEStatus.AutoSize = true;
            this.lblEStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEStatus.Location = new System.Drawing.Point(363, 81);
            this.lblEStatus.Name = "lblEStatus";
            this.lblEStatus.Size = new System.Drawing.Size(0, 17);
            this.lblEStatus.TabIndex = 31;
            // 
            // lblAgreed
            // 
            this.lblAgreed.AutoSize = true;
            this.lblAgreed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgreed.Location = new System.Drawing.Point(220, 164);
            this.lblAgreed.Name = "lblAgreed";
            this.lblAgreed.Size = new System.Drawing.Size(143, 17);
            this.lblAgreed.TabIndex = 30;
            this.lblAgreed.Text = "Agreed Rating Status";
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManager.Location = new System.Drawing.Point(210, 131);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(153, 17);
            this.lblManager.TabIndex = 29;
            this.lblManager.Text = "Manager Rating Status";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.Location = new System.Drawing.Point(204, 104);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(159, 17);
            this.lblEmployee.TabIndex = 28;
            this.lblEmployee.Text = "Employee Rating Status";
            // 
            // btnFreshAudit
            // 
            this.btnFreshAudit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFreshAudit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFreshAudit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreshAudit.Location = new System.Drawing.Point(352, 200);
            this.btnFreshAudit.Name = "btnFreshAudit";
            this.btnFreshAudit.Size = new System.Drawing.Size(346, 33);
            this.btnFreshAudit.TabIndex = 23;
            this.btnFreshAudit.Text = "Start a fresh Audit skills";
            this.btnFreshAudit.UseVisualStyleBackColor = false;
            // 
            // lblAgreedRating
            // 
            this.lblAgreedRating.AutoSize = true;
            this.lblAgreedRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgreedRating.Location = new System.Drawing.Point(253, 406);
            this.lblAgreedRating.Name = "lblAgreedRating";
            this.lblAgreedRating.Size = new System.Drawing.Size(151, 17);
            this.lblAgreedRating.TabIndex = 20;
            this.lblAgreedRating.Text = "start Agreed Rating on";
            // 
            // lbManagerRating
            // 
            this.lbManagerRating.AutoSize = true;
            this.lbManagerRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbManagerRating.Location = new System.Drawing.Point(243, 365);
            this.lbManagerRating.Name = "lbManagerRating";
            this.lbManagerRating.Size = new System.Drawing.Size(161, 17);
            this.lbManagerRating.TabIndex = 19;
            this.lbManagerRating.Text = "start Manager Rating on";
            // 
            // lblEmployeeRating
            // 
            this.lblEmployeeRating.AutoSize = true;
            this.lblEmployeeRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeRating.Location = new System.Drawing.Point(237, 323);
            this.lblEmployeeRating.Name = "lblEmployeeRating";
            this.lblEmployeeRating.Size = new System.Drawing.Size(167, 17);
            this.lblEmployeeRating.TabIndex = 18;
            this.lblEmployeeRating.Text = "start Employee Rating on";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1049, 588);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Set Notification Rules";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Administrators",
            "Employees",
            "Managers",
            ""});
            this.comboBox1.Location = new System.Drawing.Point(455, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(249, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(295, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Select the Phase Type";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ruleNameDataGridViewTextBoxColumn,
            this.phaseNumberDataGridViewTextBoxColumn,
            this.phaseTypeDataGridViewTextBoxColumn,
            this.notificationTypeDataGridViewTextBoxColumn,
            this.afterDataGridViewTextBoxColumn,
            this.beforeDataGridViewTextBoxColumn,
            this.retriesDataGridViewTextBoxColumn,
            this.retryDurationDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.notificationRulesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1025, 265);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ruleNameDataGridViewTextBoxColumn
            // 
            this.ruleNameDataGridViewTextBoxColumn.DataPropertyName = "RuleName";
            this.ruleNameDataGridViewTextBoxColumn.HeaderText = "RuleName";
            this.ruleNameDataGridViewTextBoxColumn.Name = "ruleNameDataGridViewTextBoxColumn";
            this.ruleNameDataGridViewTextBoxColumn.Width = 109;
            // 
            // phaseNumberDataGridViewTextBoxColumn
            // 
            this.phaseNumberDataGridViewTextBoxColumn.DataPropertyName = "PhaseNumber";
            this.phaseNumberDataGridViewTextBoxColumn.HeaderText = "PhaseNumber";
            this.phaseNumberDataGridViewTextBoxColumn.Name = "phaseNumberDataGridViewTextBoxColumn";
            this.phaseNumberDataGridViewTextBoxColumn.Width = 135;
            // 
            // phaseTypeDataGridViewTextBoxColumn
            // 
            this.phaseTypeDataGridViewTextBoxColumn.DataPropertyName = "PhaseType";
            this.phaseTypeDataGridViewTextBoxColumn.HeaderText = "PhaseType";
            this.phaseTypeDataGridViewTextBoxColumn.Name = "phaseTypeDataGridViewTextBoxColumn";
            this.phaseTypeDataGridViewTextBoxColumn.Width = 113;
            // 
            // notificationTypeDataGridViewTextBoxColumn
            // 
            this.notificationTypeDataGridViewTextBoxColumn.DataPropertyName = "NotificationType";
            this.notificationTypeDataGridViewTextBoxColumn.HeaderText = "NotificationType";
            this.notificationTypeDataGridViewTextBoxColumn.Name = "notificationTypeDataGridViewTextBoxColumn";
            this.notificationTypeDataGridViewTextBoxColumn.Width = 147;
            // 
            // afterDataGridViewTextBoxColumn
            // 
            this.afterDataGridViewTextBoxColumn.DataPropertyName = "After";
            this.afterDataGridViewTextBoxColumn.HeaderText = "After";
            this.afterDataGridViewTextBoxColumn.Name = "afterDataGridViewTextBoxColumn";
            this.afterDataGridViewTextBoxColumn.Width = 69;
            // 
            // beforeDataGridViewTextBoxColumn
            // 
            this.beforeDataGridViewTextBoxColumn.DataPropertyName = "Before";
            this.beforeDataGridViewTextBoxColumn.HeaderText = "Before";
            this.beforeDataGridViewTextBoxColumn.Name = "beforeDataGridViewTextBoxColumn";
            this.beforeDataGridViewTextBoxColumn.Width = 82;
            // 
            // retriesDataGridViewTextBoxColumn
            // 
            this.retriesDataGridViewTextBoxColumn.DataPropertyName = "Retries";
            this.retriesDataGridViewTextBoxColumn.HeaderText = "Retries";
            this.retriesDataGridViewTextBoxColumn.Name = "retriesDataGridViewTextBoxColumn";
            this.retriesDataGridViewTextBoxColumn.Width = 85;
            // 
            // retryDurationDataGridViewTextBoxColumn
            // 
            this.retryDurationDataGridViewTextBoxColumn.DataPropertyName = "RetryDuration";
            this.retryDurationDataGridViewTextBoxColumn.HeaderText = "RetryDuration";
            this.retryDurationDataGridViewTextBoxColumn.Name = "retryDurationDataGridViewTextBoxColumn";
            this.retryDurationDataGridViewTextBoxColumn.Width = 133;
            // 
            // notificationRulesBindingSource
            // 
            this.notificationRulesBindingSource.DataMember = "NotificationRules";
            this.notificationRulesBindingSource.DataSource = this.cASDataSet;
            // 
            // cASDataSet
            // 
            this.cASDataSet.DataSetName = "CASDataSet";
            this.cASDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // notificationRulesTableAdapter
            // 
            this.notificationRulesTableAdapter.ClearBeforeFill = true;
            // 
            // PhaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 612);
            this.Controls.Add(this.tabControl1);
            this.Name = "PhaseControl";
            this.Text = "PhaseControl";
            this.Load += new System.EventHandler(this.PhaseControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationRulesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cASDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecordingPhaseNo;
        private System.Windows.Forms.Label lblRecordingNo;
        private System.Windows.Forms.Label lblAStatus;
        private System.Windows.Forms.Label lblMStatus;
        private System.Windows.Forms.Label lblEStatus;
        private System.Windows.Forms.Label lblAgreed;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Button btnFreshAudit;
        private System.Windows.Forms.Label lblAgreedRating;
        private System.Windows.Forms.Label lbManagerRating;
        private System.Windows.Forms.Label lblEmployeeRating;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CASDataSet cASDataSet;
        private System.Windows.Forms.BindingSource notificationRulesBindingSource;
        private Listview.CASDataSetTableAdapters.NotificationRulesTableAdapter notificationRulesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ruleNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phaseNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phaseTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notificationTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn afterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn beforeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn retriesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn retryDurationDataGridViewTextBoxColumn;
    }
}