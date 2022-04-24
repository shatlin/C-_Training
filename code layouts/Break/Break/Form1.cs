using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Break
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Timer timer2;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 21600;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(459, 108);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(376, 432);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 21600;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AccessibleDescription = "keypres";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1028, 552);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Enabled = false;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKey_Up);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKey_Down);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{

			pictureBox1.Left=420;
			pictureBox1.Top=150;
		}

		private void OnKey_Down(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		e.Handled=true; 
		}

		private void OnKey_Up(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		e.Handled=true; 
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			Application.Exit(); 
		}

		private void timer2_Tick(object sender, System.EventArgs e)
		{
			//this.TopMost=true;
		}
	}
}
