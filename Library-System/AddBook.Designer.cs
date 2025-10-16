namespace Library_System
{
    partial class AddBook
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bookNameBox = new System.Windows.Forms.TextBox();
            this.Author = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.authorCombo = new System.Windows.Forms.ComboBox();
            this.publisherCombo = new System.Windows.Forms.ComboBox();
            this.categoryCombo = new System.Windows.Forms.ComboBox();
            this.languageCombo = new System.Windows.Forms.ComboBox();
            this.pubYearBox = new System.Windows.Forms.TextBox();
            this.pagesBox = new System.Windows.Forms.TextBox();
            this.copiesNumberBox = new System.Windows.Forms.TextBox();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.addBookBtn = new System.Windows.Forms.Button();
            this.viewBooksBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Teal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(351, 723);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MintCream;
            this.label1.Location = new System.Drawing.Point(12, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 222);
            this.label1.TabIndex = 1;
            this.label1.Text = "Register \r\n           a new \r\n                   Book\r\n \r\n         HERE!\r\n ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(372, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Book Name";
            // 
            // bookNameBox
            // 
            this.bookNameBox.Location = new System.Drawing.Point(377, 108);
            this.bookNameBox.Name = "bookNameBox";
            this.bookNameBox.Size = new System.Drawing.Size(554, 26);
            this.bookNameBox.TabIndex = 3;
            this.bookNameBox.TextChanged += new System.EventHandler(this.bookNameBox_TextChanged);
            // 
            // Author
            // 
            this.Author.AutoSize = true;
            this.Author.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Author.Location = new System.Drawing.Point(372, 148);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(141, 25);
            this.Author.TabIndex = 4;
            this.Author.Text = "Book Author";
            this.Author.Click += new System.EventHandler(this.Author_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(372, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Book Category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(372, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Book Publisher";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(690, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Book Publication Year";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(372, 358);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Book Language";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(372, 427);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 25);
            this.label7.TabIndex = 9;
            this.label7.Text = "Number of Pages";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(690, 427);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "Number of Copies";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(372, 500);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 25);
            this.label9.TabIndex = 11;
            this.label9.Text = "Book Description:";
            // 
            // authorCombo
            // 
            this.authorCombo.FormattingEnabled = true;
            this.authorCombo.Location = new System.Drawing.Point(377, 176);
            this.authorCombo.Name = "authorCombo";
            this.authorCombo.Size = new System.Drawing.Size(357, 28);
            this.authorCombo.TabIndex = 12;
            this.authorCombo.SelectedIndexChanged += new System.EventHandler(this.authorCombo_SelectedIndexChanged);
            // 
            // publisherCombo
            // 
            this.publisherCombo.FormattingEnabled = true;
            this.publisherCombo.Location = new System.Drawing.Point(377, 245);
            this.publisherCombo.Name = "publisherCombo";
            this.publisherCombo.Size = new System.Drawing.Size(357, 28);
            this.publisherCombo.TabIndex = 13;
            // 
            // categoryCombo
            // 
            this.categoryCombo.FormattingEnabled = true;
            this.categoryCombo.Location = new System.Drawing.Point(377, 314);
            this.categoryCombo.Name = "categoryCombo";
            this.categoryCombo.Size = new System.Drawing.Size(357, 28);
            this.categoryCombo.TabIndex = 14;
            this.categoryCombo.SelectedIndexChanged += new System.EventHandler(this.categoryCombo_SelectedIndexChanged);
            // 
            // languageCombo
            // 
            this.languageCombo.FormattingEnabled = true;
            this.languageCombo.Location = new System.Drawing.Point(377, 384);
            this.languageCombo.Name = "languageCombo";
            this.languageCombo.Size = new System.Drawing.Size(257, 28);
            this.languageCombo.TabIndex = 15;
            this.languageCombo.SelectedIndexChanged += new System.EventHandler(this.languageCombo_SelectedIndexChanged);
            // 
            // pubYearBox
            // 
            this.pubYearBox.Location = new System.Drawing.Point(695, 386);
            this.pubYearBox.Name = "pubYearBox";
            this.pubYearBox.Size = new System.Drawing.Size(266, 26);
            this.pubYearBox.TabIndex = 16;
            // 
            // pagesBox
            // 
            this.pagesBox.Location = new System.Drawing.Point(377, 460);
            this.pagesBox.Name = "pagesBox";
            this.pagesBox.Size = new System.Drawing.Size(255, 26);
            this.pagesBox.TabIndex = 17;
            // 
            // copiesNumberBox
            // 
            this.copiesNumberBox.Location = new System.Drawing.Point(695, 460);
            this.copiesNumberBox.Name = "copiesNumberBox";
            this.copiesNumberBox.Size = new System.Drawing.Size(266, 26);
            this.copiesNumberBox.TabIndex = 18;
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(562, 500);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(399, 153);
            this.descriptionBox.TabIndex = 19;
            // 
            // addBookBtn
            // 
            this.addBookBtn.BackColor = System.Drawing.Color.Teal;
            this.addBookBtn.Font = new System.Drawing.Font("Modern No. 20", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBookBtn.ForeColor = System.Drawing.Color.Honeydew;
            this.addBookBtn.Location = new System.Drawing.Point(776, 676);
            this.addBookBtn.Name = "addBookBtn";
            this.addBookBtn.Size = new System.Drawing.Size(185, 49);
            this.addBookBtn.TabIndex = 20;
            this.addBookBtn.Text = "Add Book";
            this.addBookBtn.UseVisualStyleBackColor = false;
            this.addBookBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // viewBooksBtn
            // 
            this.viewBooksBtn.BackColor = System.Drawing.Color.Teal;
            this.viewBooksBtn.Font = new System.Drawing.Font("Modern No. 20", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewBooksBtn.ForeColor = System.Drawing.Color.Honeydew;
            this.viewBooksBtn.Location = new System.Drawing.Point(359, 676);
            this.viewBooksBtn.Name = "viewBooksBtn";
            this.viewBooksBtn.Size = new System.Drawing.Size(185, 49);
            this.viewBooksBtn.TabIndex = 21;
            this.viewBooksBtn.Text = "View All Books";
            this.viewBooksBtn.UseVisualStyleBackColor = false;
            this.viewBooksBtn.Click += new System.EventHandler(this.viewBooksBtn_Click);
            // 
            // AddBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(992, 730);
            this.Controls.Add(this.viewBooksBtn);
            this.Controls.Add(this.addBookBtn);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.copiesNumberBox);
            this.Controls.Add(this.pagesBox);
            this.Controls.Add(this.pubYearBox);
            this.Controls.Add(this.languageCombo);
            this.Controls.Add(this.categoryCombo);
            this.Controls.Add(this.publisherCombo);
            this.Controls.Add(this.authorCombo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.bookNameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AddBook";
            this.Text = "AddBook";
            this.Load += new System.EventHandler(this.AddBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bookNameBox;
        private System.Windows.Forms.Label Author;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox authorCombo;
        private System.Windows.Forms.ComboBox publisherCombo;
        private System.Windows.Forms.ComboBox categoryCombo;
        private System.Windows.Forms.ComboBox languageCombo;
        private System.Windows.Forms.TextBox pubYearBox;
        private System.Windows.Forms.TextBox pagesBox;
        private System.Windows.Forms.TextBox copiesNumberBox;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Button addBookBtn;
        private System.Windows.Forms.Button viewBooksBtn;
    }
}