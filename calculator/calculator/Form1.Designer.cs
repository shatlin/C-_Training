namespace calculator
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
            this.btnResult = new System.Windows.Forms.TextBox();
            this.btnZero = new System.Windows.Forms.Button();
            this.btnOne = new System.Windows.Forms.Button();
            this.btnEqual = new System.Windows.Forms.Button();
            this.btnNine = new System.Windows.Forms.Button();
            this.btnFour = new System.Windows.Forms.Button();
            this.btnSeven = new System.Windows.Forms.Button();
            this.btnSub = new System.Windows.Forms.Button();
            this.btnDiv = new System.Windows.Forms.Button();
            this.btnThree = new System.Windows.Forms.Button();
            this.btnSix = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnMul = new System.Windows.Forms.Button();
            this.btnTwo = new System.Windows.Forms.Button();
            this.btnFive = new System.Windows.Forms.Button();
            this.btnEight = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnResult
            // 
            this.btnResult.Location = new System.Drawing.Point(13, 33);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(217, 20);
            this.btnResult.TabIndex = 0;
            this.btnResult.Text = "0";
            this.btnResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnZero
            // 
            this.btnZero.Location = new System.Drawing.Point(12, 75);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(34, 25);
            this.btnZero.TabIndex = 1;
            this.btnZero.Text = "0";
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // btnOne
            // 
            this.btnOne.Location = new System.Drawing.Point(71, 75);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(34, 23);
            this.btnOne.TabIndex = 2;
            this.btnOne.Text = "1";
            this.btnOne.Click += new System.EventHandler(this.btnOne_Click);
            // 
            // btnEqual
            // 
            this.btnEqual.Location = new System.Drawing.Point(192, 76);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(38, 162);
            this.btnEqual.TabIndex = 3;
            this.btnEqual.Text = "=";
            this.btnEqual.Click += new System.EventHandler(this.btnEqual_Click);
            // 
            // btnNine
            // 
            this.btnNine.Location = new System.Drawing.Point(134, 181);
            this.btnNine.Name = "btnNine";
            this.btnNine.Size = new System.Drawing.Size(38, 23);
            this.btnNine.TabIndex = 4;
            this.btnNine.Text = "9";
            this.btnNine.Click += new System.EventHandler(this.btnNine_Click);
            // 
            // btnFour
            // 
            this.btnFour.Location = new System.Drawing.Point(71, 110);
            this.btnFour.Name = "btnFour";
            this.btnFour.Size = new System.Drawing.Size(34, 23);
            this.btnFour.TabIndex = 5;
            this.btnFour.Text = "4";
            this.btnFour.Click += new System.EventHandler(this.btnFour_Click);
            // 
            // btnSeven
            // 
            this.btnSeven.Location = new System.Drawing.Point(71, 145);
            this.btnSeven.Name = "btnSeven";
            this.btnSeven.Size = new System.Drawing.Size(34, 23);
            this.btnSeven.TabIndex = 6;
            this.btnSeven.Text = "7";
            this.btnSeven.Click += new System.EventHandler(this.btnSeven_Click);
            // 
            // btnSub
            // 
            this.btnSub.Location = new System.Drawing.Point(71, 180);
            this.btnSub.Name = "btnSub";
            this.btnSub.Size = new System.Drawing.Size(34, 23);
            this.btnSub.TabIndex = 7;
            this.btnSub.Text = "-";
            this.btnSub.Click += new System.EventHandler(this.btnSub_Click);
            // 
            // btnDiv
            // 
            this.btnDiv.Location = new System.Drawing.Point(71, 215);
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.Size = new System.Drawing.Size(34, 23);
            this.btnDiv.TabIndex = 8;
            this.btnDiv.Text = "/";
            this.btnDiv.Click += new System.EventHandler(this.btnDiv_Click);
            // 
            // btnThree
            // 
            this.btnThree.Location = new System.Drawing.Point(13, 110);
            this.btnThree.Name = "btnThree";
            this.btnThree.Size = new System.Drawing.Size(34, 25);
            this.btnThree.TabIndex = 9;
            this.btnThree.Text = "3";
            this.btnThree.Click += new System.EventHandler(this.btnThree_Click);
            // 
            // btnSix
            // 
            this.btnSix.Location = new System.Drawing.Point(12, 145);
            this.btnSix.Name = "btnSix";
            this.btnSix.Size = new System.Drawing.Size(34, 25);
            this.btnSix.TabIndex = 10;
            this.btnSix.Text = "6";
            this.btnSix.Click += new System.EventHandler(this.btnSix_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 180);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(34, 25);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "+";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnMul
            // 
            this.btnMul.Location = new System.Drawing.Point(12, 215);
            this.btnMul.Name = "btnMul";
            this.btnMul.Size = new System.Drawing.Size(34, 25);
            this.btnMul.TabIndex = 12;
            this.btnMul.Text = "*";
            this.btnMul.Click += new System.EventHandler(this.btnMul_Click);
            // 
            // btnTwo
            // 
            this.btnTwo.Location = new System.Drawing.Point(134, 76);
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.Size = new System.Drawing.Size(38, 23);
            this.btnTwo.TabIndex = 13;
            this.btnTwo.Text = "2";
            this.btnTwo.Click += new System.EventHandler(this.btnTwo_Click);
            // 
            // btnFive
            // 
            this.btnFive.Location = new System.Drawing.Point(133, 111);
            this.btnFive.Name = "btnFive";
            this.btnFive.Size = new System.Drawing.Size(38, 23);
            this.btnFive.TabIndex = 14;
            this.btnFive.Text = "5";
            this.btnFive.Click += new System.EventHandler(this.btnFive_Click);
            // 
            // btnEight
            // 
            this.btnEight.Location = new System.Drawing.Point(134, 146);
            this.btnEight.Name = "btnEight";
            this.btnEight.Size = new System.Drawing.Size(38, 23);
            this.btnEight.TabIndex = 15;
            this.btnEight.Text = "8";
            this.btnEight.Click += new System.EventHandler(this.btnEight_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(138, 216);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(33, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "C";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 266);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEight);
            this.Controls.Add(this.btnFive);
            this.Controls.Add(this.btnTwo);
            this.Controls.Add(this.btnMul);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSix);
            this.Controls.Add(this.btnThree);
            this.Controls.Add(this.btnDiv);
            this.Controls.Add(this.btnSub);
            this.Controls.Add(this.btnSeven);
            this.Controls.Add(this.btnFour);
            this.Controls.Add(this.btnNine);
            this.Controls.Add(this.btnEqual);
            this.Controls.Add(this.btnOne);
            this.Controls.Add(this.btnZero);
            this.Controls.Add(this.btnResult);
            this.Name = "Form1";
            this.Text = "Diana\'s calc";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox btnResult;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Button btnOne;
        private System.Windows.Forms.Button btnEqual;
        private System.Windows.Forms.Button btnNine;
        private System.Windows.Forms.Button btnFour;
        private System.Windows.Forms.Button btnSeven;
        private System.Windows.Forms.Button btnSub;
        private System.Windows.Forms.Button btnDiv;
        private System.Windows.Forms.Button btnThree;
        private System.Windows.Forms.Button btnSix;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnMul;
        private System.Windows.Forms.Button btnTwo;
        private System.Windows.Forms.Button btnFive;
        private System.Windows.Forms.Button btnEight;
        private System.Windows.Forms.Button btnCancel;
    }
}

