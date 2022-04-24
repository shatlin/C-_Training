namespace multiplication
{
    partial class Form1
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtNo1 = new System.Windows.Forms.TextBox();
            this.txtNo2 = new System.Windows.Forms.TextBox();
            this.btnDiv = new System.Windows.Forms.Button();
            this.btnMul = new System.Windows.Forms.Button();
            this.btnSub = new System.Windows.Forms.Button();
            this.txtNo3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(66, 101);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "+";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtNo1
            // 
            this.txtNo1.Location = new System.Drawing.Point(69, 25);
            this.txtNo1.Name = "txtNo1";
            this.txtNo1.Size = new System.Drawing.Size(162, 20);
            this.txtNo1.TabIndex = 1;
            // 
            // txtNo2
            // 
            this.txtNo2.Location = new System.Drawing.Point(69, 63);
            this.txtNo2.Name = "txtNo2";
            this.txtNo2.Size = new System.Drawing.Size(162, 20);
            this.txtNo2.TabIndex = 2;
            // 
            // btnDiv
            // 
            this.btnDiv.Location = new System.Drawing.Point(207, 101);
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.Size = new System.Drawing.Size(24, 23);
            this.btnDiv.TabIndex = 5;
            this.btnDiv.Text = "/";
            this.btnDiv.Click += new System.EventHandler(this.btnDiv_Click);
            // 
            // btnMul
            // 
            this.btnMul.Location = new System.Drawing.Point(159, 101);
            this.btnMul.Name = "btnMul";
            this.btnMul.Size = new System.Drawing.Size(24, 23);
            this.btnMul.TabIndex = 6;
            this.btnMul.Text = "*";
            this.btnMul.Click += new System.EventHandler(this.btnMul_Click);
            // 
            // btnSub
            // 
            this.btnSub.Location = new System.Drawing.Point(110, 101);
            this.btnSub.Name = "btnSub";
            this.btnSub.Size = new System.Drawing.Size(24, 23);
            this.btnSub.TabIndex = 7;
            this.btnSub.Text = "-";
            this.btnSub.Click += new System.EventHandler(this.btnSub_Click);
            // 
            // txtNo3
            // 
            this.txtNo3.Location = new System.Drawing.Point(69, 142);
            this.txtNo3.Name = "txtNo3";
            this.txtNo3.Size = new System.Drawing.Size(162, 20);
            this.txtNo3.TabIndex = 8;
            this.txtNo3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "no1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "no2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "result";
            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 210);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNo3);
            this.Controls.Add(this.btnSub);
            this.Controls.Add(this.btnMul);
            this.Controls.Add(this.btnDiv);
            this.Controls.Add(this.txtNo2);
            this.Controls.Add(this.txtNo1);
            this.Controls.Add(this.btnAdd);
            this.Name = "Form1";
            this.Text = "dian calc2";
            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtNo1;
        private System.Windows.Forms.TextBox txtNo2;
        private System.Windows.Forms.Button btnDiv;
        private System.Windows.Forms.Button btnMul;
        private System.Windows.Forms.Button btnSub;
        private System.Windows.Forms.TextBox txtNo3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

