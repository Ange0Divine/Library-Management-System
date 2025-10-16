namespace Library_System
{
    partial class StudentLoginFrm
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
            this.seepasscheckBox = new System.Windows.Forms.CheckBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.LPasswordBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LEmailBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LNamesBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.LStudentIdBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // seepasscheckBox
            // 
            this.seepasscheckBox.AutoSize = true;
            this.seepasscheckBox.Location = new System.Drawing.Point(381, 456);
            this.seepasscheckBox.Name = "seepasscheckBox";
            this.seepasscheckBox.Size = new System.Drawing.Size(136, 24);
            this.seepasscheckBox.TabIndex = 23;
            this.seepasscheckBox.Text = "See password";
            this.seepasscheckBox.UseVisualStyleBackColor = true;
            this.seepasscheckBox.CheckedChanged += new System.EventHandler(this.seepasscheckBox_CheckedChanged);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Font = new System.Drawing.Font("Modern No. 20", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.Location = new System.Drawing.Point(523, 489);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(132, 44);
            this.LoginBtn.TabIndex = 22;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // LPasswordBox
            // 
            this.LPasswordBox.Location = new System.Drawing.Point(380, 424);
            this.LPasswordBox.Name = "LPasswordBox";
            this.LPasswordBox.Size = new System.Drawing.Size(431, 26);
            this.LPasswordBox.TabIndex = 21;
            this.LPasswordBox.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(376, 387);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 25);
            this.label6.TabIndex = 20;
            this.label6.Text = "Password";
            // 
            // LEmailBox
            // 
            this.LEmailBox.Location = new System.Drawing.Point(380, 339);
            this.LEmailBox.Name = "LEmailBox";
            this.LEmailBox.Size = new System.Drawing.Size(431, 26);
            this.LEmailBox.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(376, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "Email";
            // 
            // LNamesBox
            // 
            this.LNamesBox.Location = new System.Drawing.Point(381, 151);
            this.LNamesBox.Name = "LNamesBox";
            this.LNamesBox.Size = new System.Drawing.Size(431, 26);
            this.LNamesBox.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(375, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Full Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(530, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 34);
            this.label3.TabIndex = 15;
            this.label3.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(375, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(463, 34);
            this.label2.TabIndex = 14;
            this.label2.Text = "Welcome to Our Library System";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-5, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(374, 549);
            this.dataGridView1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(376, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "Student ID";
            // 
            // LStudentIdBox
            // 
            this.LStudentIdBox.Location = new System.Drawing.Point(380, 245);
            this.LStudentIdBox.Name = "LStudentIdBox";
            this.LStudentIdBox.Size = new System.Drawing.Size(431, 26);
            this.LStudentIdBox.TabIndex = 25;
            // 
            // StudentLoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 551);
            this.Controls.Add(this.LStudentIdBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seepasscheckBox);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.LPasswordBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LEmailBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LNamesBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StudentLoginFrm";
            this.Text = "StudentLoginFrm";
            this.Load += new System.EventHandler(this.StudentLoginFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox seepasscheckBox;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.TextBox LPasswordBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox LEmailBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox LNamesBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LStudentIdBox;
    }
}