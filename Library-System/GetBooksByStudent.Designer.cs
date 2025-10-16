namespace Library_System
{
    partial class GetBooksByStudent
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
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.GetBooksBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(146, 45);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(296, 26);
            this.txtStudentID.TabIndex = 0;
            // 
            // GetBooksBtn
            // 
            this.GetBooksBtn.Location = new System.Drawing.Point(134, 301);
            this.GetBooksBtn.Name = "GetBooksBtn";
            this.GetBooksBtn.Size = new System.Drawing.Size(75, 23);
            this.GetBooksBtn.TabIndex = 1;
            this.GetBooksBtn.Text = "View";
            this.GetBooksBtn.UseVisualStyleBackColor = true;
            this.GetBooksBtn.Click += new System.EventHandler(this.GetBooksBtn_Click);
            // 
            // GetBooksByStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GetBooksBtn);
            this.Controls.Add(this.txtStudentID);
            this.Name = "GetBooksByStudent";
            this.Text = "GetBooksByStudent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Button GetBooksBtn;
    }
}