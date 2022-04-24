namespace Listview
{
    partial class MT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MT));
            this.listView1 = new System.Windows.Forms.ListView();
            this.LargeImageList = new System.Windows.Forms.ImageList(this.components);
            this.SmallImageList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(54, 56);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(254, 352);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // LargeImageList
            // 
            this.LargeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LargeImageList.ImageStream")));
            this.LargeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.LargeImageList.Images.SetKeyName(0, "icnTrend_2.gif");
            this.LargeImageList.Images.SetKeyName(1, "icnRoleReq.gif");
            this.LargeImageList.Images.SetKeyName(2, "icnServiceManager.gif");
            this.LargeImageList.Images.SetKeyName(3, "icnSubOrdinate.gif");
            this.LargeImageList.Images.SetKeyName(4, "icnTrend.gif");
            // 
            // SmallImageList
            // 
            this.SmallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallImageList.ImageStream")));
            this.SmallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallImageList.Images.SetKeyName(0, "icnTrend_2.gif");
            this.SmallImageList.Images.SetKeyName(1, "icnRoleReq.gif");
            this.SmallImageList.Images.SetKeyName(2, "icnServiceManager.gif");
            this.SmallImageList.Images.SetKeyName(3, "icnSubOrdinate.gif");
            this.SmallImageList.Images.SetKeyName(4, "icnTrend.gif");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "List of All MessageTemplate names\n from MessageTemplate Table";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(148, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(233, 415);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(397, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 403);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add/Edit Message Template";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(187, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(321, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(187, 80);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(321, 200);
            this.textBox2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Template Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "MessageText";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(309, 329);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // MT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 503);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Name = "MT";
            this.Text = "Manage Message Template";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList LargeImageList;
        private System.Windows.Forms.ImageList SmallImageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
    }
}

