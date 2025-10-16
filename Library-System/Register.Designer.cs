namespace Library_System
{
    partial class Register
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
            this.chkSeePassword = new System.Windows.Forms.CheckBox();
            this.CreateAccBtn = new System.Windows.Forms.Button();
            this.RPasswordBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.REmailBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RNamesBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StudentId = new System.Windows.Forms.Label();
            this.studentIdBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rbStudent = new System.Windows.Forms.RadioButton();
            this.rbLibrarian = new System.Windows.Forms.RadioButton();
            this.rbAdmin = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSeePassword
            // 
            this.chkSeePassword.AutoSize = true;
            this.chkSeePassword.Location = new System.Drawing.Point(447, 468);
            this.chkSeePassword.Name = "chkSeePassword";
            this.chkSeePassword.Size = new System.Drawing.Size(136, 24);
            this.chkSeePassword.TabIndex = 24;
            this.chkSeePassword.Text = "See password";
            this.chkSeePassword.UseVisualStyleBackColor = true;
            this.chkSeePassword.CheckedChanged += new System.EventHandler(this.chkSeePassword_CheckedChanged);
            // 
            // CreateAccBtn
            // 
            this.CreateAccBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.CreateAccBtn.Font = new System.Drawing.Font("Modern No. 20", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateAccBtn.ForeColor = System.Drawing.Color.Lavender;
            this.CreateAccBtn.Location = new System.Drawing.Point(549, 570);
            this.CreateAccBtn.Name = "CreateAccBtn";
            this.CreateAccBtn.Size = new System.Drawing.Size(238, 56);
            this.CreateAccBtn.TabIndex = 22;
            this.CreateAccBtn.Text = "Create Account";
            this.CreateAccBtn.UseVisualStyleBackColor = false;
            this.CreateAccBtn.Click += new System.EventHandler(this.CreateAccBtn_Click);
            // 
            // RPasswordBox
            // 
            this.RPasswordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(230)))));
            this.RPasswordBox.Location = new System.Drawing.Point(447, 436);
            this.RPasswordBox.Name = "RPasswordBox";
            this.RPasswordBox.Size = new System.Drawing.Size(492, 26);
            this.RPasswordBox.TabIndex = 21;
            this.RPasswordBox.UseSystemPasswordChar = true;
            this.RPasswordBox.TextChanged += new System.EventHandler(this.RPasswordBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(442, 408);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 25);
            this.label6.TabIndex = 20;
            this.label6.Text = "Password";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // REmailBox
            // 
            this.REmailBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(230)))));
            this.REmailBox.Location = new System.Drawing.Point(447, 220);
            this.REmailBox.Name = "REmailBox";
            this.REmailBox.Size = new System.Drawing.Size(492, 26);
            this.REmailBox.TabIndex = 19;
            this.REmailBox.TextChanged += new System.EventHandler(this.LEmailBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(442, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "Email";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // RNamesBox
            // 
            this.RNamesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(230)))));
            this.RNamesBox.Location = new System.Drawing.Point(447, 153);
            this.RNamesBox.Name = "RNamesBox";
            this.RNamesBox.Size = new System.Drawing.Size(492, 26);
            this.RNamesBox.TabIndex = 17;
            this.RNamesBox.TextChanged += new System.EventHandler(this.LNamesBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(442, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Full Name";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(533, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(296, 37);
            this.label3.TabIndex = 15;
            this.label3.Text = "Create an Account";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(399, 625);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // StudentId
            // 
            this.StudentId.AutoSize = true;
            this.StudentId.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentId.Location = new System.Drawing.Point(442, 258);
            this.StudentId.Name = "StudentId";
            this.StudentId.Size = new System.Drawing.Size(131, 25);
            this.StudentId.TabIndex = 25;
            this.StudentId.Text = "Student ID";
            this.StudentId.Click += new System.EventHandler(this.StudentId_Click);
            // 
            // studentIdBox
            // 
            this.studentIdBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(230)))));
            this.studentIdBox.Location = new System.Drawing.Point(447, 286);
            this.studentIdBox.Name = "studentIdBox";
            this.studentIdBox.Size = new System.Drawing.Size(492, 26);
            this.studentIdBox.TabIndex = 26;
            this.studentIdBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(442, 505);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 25);
            this.label7.TabIndex = 27;
            this.label7.Text = "Role";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // rbStudent
            // 
            this.rbStudent.AutoSize = true;
            this.rbStudent.Location = new System.Drawing.Point(447, 533);
            this.rbStudent.Name = "rbStudent";
            this.rbStudent.Size = new System.Drawing.Size(91, 24);
            this.rbStudent.TabIndex = 28;
            this.rbStudent.TabStop = true;
            this.rbStudent.Text = "Student";
            this.rbStudent.UseVisualStyleBackColor = true;
            this.rbStudent.CheckedChanged += new System.EventHandler(this.rbStudent_CheckedChanged_1);
            // 
            // rbLibrarian
            // 
            this.rbLibrarian.AutoSize = true;
            this.rbLibrarian.Location = new System.Drawing.Point(622, 533);
            this.rbLibrarian.Name = "rbLibrarian";
            this.rbLibrarian.Size = new System.Drawing.Size(95, 24);
            this.rbLibrarian.TabIndex = 29;
            this.rbLibrarian.TabStop = true;
            this.rbLibrarian.Text = "Librarian";
            this.rbLibrarian.UseVisualStyleBackColor = true;
            this.rbLibrarian.CheckedChanged += new System.EventHandler(this.rbLibrarian_CheckedChanged_1);
            // 
            // rbAdmin
            // 
            this.rbAdmin.AutoSize = true;
            this.rbAdmin.Location = new System.Drawing.Point(806, 533);
            this.rbAdmin.Name = "rbAdmin";
            this.rbAdmin.Size = new System.Drawing.Size(79, 24);
            this.rbAdmin.TabIndex = 30;
            this.rbAdmin.TabStop = true;
            this.rbAdmin.Text = "Admin";
            this.rbAdmin.UseVisualStyleBackColor = true;
            this.rbAdmin.CheckedChanged += new System.EventHandler(this.rbAdmin_CheckedChanged_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(442, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 25);
            this.label8.TabIndex = 31;
            this.label8.Text = "Phone Number";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(230)))));
            this.textBox1.Location = new System.Drawing.Point(447, 365);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(491, 26);
            this.textBox1.TabIndex = 32;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MidnightBlue;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lavender;
            this.label1.Location = new System.Drawing.Point(12, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 111);
            this.label1.TabIndex = 33;
            this.label1.Text = "     Welcome \r\nto  Our\r\n       Library  System";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(907, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 25);
            this.label2.TabIndex = 34;
            this.label2.Text = "X";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(955, 628);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rbAdmin);
            this.Controls.Add(this.rbLibrarian);
            this.Controls.Add(this.rbStudent);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.studentIdBox);
            this.Controls.Add(this.StudentId);
            this.Controls.Add(this.chkSeePassword);
            this.Controls.Add(this.CreateAccBtn);
            this.Controls.Add(this.RPasswordBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.REmailBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RNamesBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Register";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSeePassword;
        private System.Windows.Forms.Button CreateAccBtn;
        private System.Windows.Forms.TextBox RPasswordBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox REmailBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox RNamesBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label StudentId;
        private System.Windows.Forms.TextBox studentIdBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbStudent;
        private System.Windows.Forms.RadioButton rbLibrarian;
        private System.Windows.Forms.RadioButton rbAdmin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}