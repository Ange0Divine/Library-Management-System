namespace Library_System
{
    partial class WelcomeFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.StudentBtn = new System.Windows.Forms.Button();
            this.LibrarianBtn = new System.Windows.Forms.Button();
            this.AdminBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome To Our Library System";
            // 
            // StudentBtn
            // 
            this.StudentBtn.Location = new System.Drawing.Point(104, 187);
            this.StudentBtn.Name = "StudentBtn";
            this.StudentBtn.Size = new System.Drawing.Size(114, 53);
            this.StudentBtn.TabIndex = 1;
            this.StudentBtn.Text = "Student";
            this.StudentBtn.UseVisualStyleBackColor = true;
            this.StudentBtn.Click += new System.EventHandler(this.StudentBtn_Click);
            // 
            // LibrarianBtn
            // 
            this.LibrarianBtn.Location = new System.Drawing.Point(338, 187);
            this.LibrarianBtn.Name = "LibrarianBtn";
            this.LibrarianBtn.Size = new System.Drawing.Size(101, 53);
            this.LibrarianBtn.TabIndex = 2;
            this.LibrarianBtn.Text = "Librarian";
            this.LibrarianBtn.UseVisualStyleBackColor = true;
            this.LibrarianBtn.Click += new System.EventHandler(this.LibrarianBtn_Click);
            // 
            // AdminBtn
            // 
            this.AdminBtn.Location = new System.Drawing.Point(550, 187);
            this.AdminBtn.Name = "AdminBtn";
            this.AdminBtn.Size = new System.Drawing.Size(110, 53);
            this.AdminBtn.TabIndex = 3;
            this.AdminBtn.Text = "Admin";
            this.AdminBtn.UseVisualStyleBackColor = true;
            this.AdminBtn.Click += new System.EventHandler(this.AdminBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "You Want to Login as?";
            // 
            // WelcomeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AdminBtn);
            this.Controls.Add(this.LibrarianBtn);
            this.Controls.Add(this.StudentBtn);
            this.Controls.Add(this.label1);
            this.Name = "WelcomeFrm";
            this.Text = "WelcomeFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StudentBtn;
        private System.Windows.Forms.Button LibrarianBtn;
        private System.Windows.Forms.Button AdminBtn;
        private System.Windows.Forms.Label label2;
    }
}