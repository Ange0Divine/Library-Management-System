using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Library_System
{
    public partial class AllBooksFrm : Form
    {
        // 1. New UI Control Names (Assuming you renamed your controls)
        // You would declare these controls in your Form's designer, but we'll use them here:
        // private System.Windows.Forms.TextBox txtTitle; 
        // private System.Windows.Forms.ComboBox cmbAuthor; 
        // private System.Windows.Forms.ComboBox cmbCategory; 
        // private System.Windows.Forms.TextBox txtCopies; 
        // private System.Windows.Forms.DataGridView dgvBooks; 

        private int selectedBook = 0; // Class-level variable to hold the selected Book ID

        public AllBooksFrm()
        {
            InitializeComponent();
            // Assuming your combo boxes are named cmbAuthor and cmbCategory, 
            // and your title/copies boxes are txtTitle and txtCopies.
        }

        private void AllBooksFrm_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadAuthorAndCategories(); // <--- NEW: Load data for ComboBoxes on form load
        }

        // --- NEW METHOD ---
        private void LoadAuthorAndCategories()
        {
            string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    DataSet ds = new DataSet();

                    // Load Categories
                    SqlDataAdapter sdaCategory = new SqlDataAdapter("SELECT CategoryId, CategoryName FROM Category", con);
                    sdaCategory.Fill(ds, "Category");

                    // Load Authors
                    SqlDataAdapter sdaAuthor = new SqlDataAdapter("SELECT AuthorId, AuthorName FROM Author", con);
                    sdaAuthor.Fill(ds, "Author");

                    // Bind Category ComboBox
                    cmbCategory.DataSource = ds.Tables["Category"];
                    cmbCategory.DisplayMember = "CategoryName";
                    cmbCategory.ValueMember = "CategoryId";
                    cmbCategory.SelectedIndex = -1;

                    // Bind Author ComboBox
                    cmbAuthor.DataSource = ds.Tables["Author"];
                    cmbAuthor.DisplayMember = "AuthorName";
                    cmbAuthor.ValueMember = "AuthorId";
                    cmbAuthor.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading lookup data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // --- END NEW METHOD ---

        private void LoadBooks()
        {
            // (Your existing LoadBooks code remains the same)
            try
            {
                string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();

                    // Query is correct as it fetches both IDs and Names
                    string query = @"SELECT 
                                        b.[Book Id] AS BookId,
                                        b.BookTittle,
                                        b.AuthorId,
                                        a.AuthorName,
                                        b.CategoryId,
                                        c.CategoryName,
                                        b.AvailableCopies
                                    FROM 
                                        Books b
                                    INNER JOIN 
                                        Author a ON b.AuthorId = a.AuthorId
                                    INNER JOIN 
                                        Category c ON b.CategoryId = c.CategoryId
                                    ORDER BY 
                                        b.[Book Id]";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvBooks.DataSource = dt;

                        // Hide ID columns (They are needed to populate the ComboBoxes)
                        if (dgvBooks.Columns.Contains("AuthorId"))
                            dgvBooks.Columns["AuthorId"].Visible = false;

                        if (dgvBooks.Columns.Contains("CategoryId"))
                            dgvBooks.Columns["CategoryId"].Visible = false;

                        // Set display columns
                        dgvBooks.Columns["BookTittle"].HeaderText = "Book Title";
                        dgvBooks.Columns["AuthorName"].HeaderText = "Author";
                        dgvBooks.Columns["CategoryName"].HeaderText = "Category";
                        dgvBooks.Columns["AvailableCopies"].HeaderText = "Available Copies";

                        dgvBooks.Columns["BookTittle"].Width = 200;
                        dgvBooks.Columns["AuthorName"].Width = 150;
                        dgvBooks.Columns["CategoryName"].Width = 120;
                        dgvBooks.Columns["AvailableCopies"].Width = 100;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- UPDATED EVENT HANDLER ---
        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            // Use SelectionChanged for row clicks, more reliable than CellContentClick for selection
            if (dgvBooks.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvBooks.SelectedRows[0];

                try
                {
                    // 1. Set the selectedBook ID
                    if (int.TryParse(selectedRow.Cells["BookId"].Value.ToString(), out selectedBook))
                    {
                        // 2. Populate the Textbox
                        txtTitle.Text = selectedRow.Cells["BookTittle"].Value.ToString();
                        txtCopies.Text = selectedRow.Cells["AvailableCopies"].Value.ToString();

                        // 3. Populate the ComboBoxes by setting their SelectedValue to the ID from the DataGridView

                        // Set Author ComboBox
                        if (int.TryParse(selectedRow.Cells["AuthorId"].Value.ToString(), out int authorId))
                        {
                            cmbAuthor.SelectedValue = authorId;
                        }

                        // Set Category ComboBox
                        if (int.TryParse(selectedRow.Cells["CategoryId"].Value.ToString(), out int categoryId))
                        {
                            cmbCategory.SelectedValue = categoryId;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading book details: " + ex.Message, "Data Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Clear textboxes and reset selection when no row is selected
                selectedBook = 0;
                txtTitle.Text = "";
                txtCopies.Text = "";
                cmbAuthor.SelectedIndex = -1; // Clear ComboBox selection
                cmbCategory.SelectedIndex = -1; // Clear ComboBox selection
            }
        }
        // --- END UPDATED EVENT HANDLER ---

        // You can remove the empty AllBooksdataGridView1_CellContentClick method

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // It's generally better to use the dgvBooks_SelectionChanged event instead of CellContentClick 
            // for populating textboxes, as implemented above. You can remove the code in this method.
        }

        // --- UPDATED UPDATE METHOD ---
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (selectedBook == 0)
            {
                MessageBox.Show("Please select a book to update!", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Get NEW values from controls, specifically from the ComboBoxes!
            string newTitle = txtTitle.Text.Trim();
            int newAuthorId;
            int newCategoryId;
            int newAvailableCopies;

            // Input Validation: Check ComboBox selections first
            if (cmbAuthor.SelectedValue == null || !int.TryParse(cmbAuthor.SelectedValue.ToString(), out newAuthorId) || newAuthorId <= 0)
            {
                MessageBox.Show("Please select a valid Author.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbCategory.SelectedValue == null || !int.TryParse(cmbCategory.SelectedValue.ToString(), out newCategoryId) || newCategoryId <= 0)
            {
                MessageBox.Show("Please select a valid Category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Basic Input Validation for other fields
            if (string.IsNullOrEmpty(newTitle))
            {
                MessageBox.Show("Book Title cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtCopies.Text, out newAvailableCopies) || newAvailableCopies < 0)
            {
                MessageBox.Show("Please enter a valid number of Available Copies (0 or more).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // 2. Confirm Update (Rest of the update logic is fine)
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to update book ID: {selectedBook}?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(connection))
                    {
                        con.Open();

                        // 3. SQL UPDATE Command
                        string query = @"
                            UPDATE Books 
                            SET 
                                BookTittle = @title, 
                                AuthorId = @authorId,
                                CategoryId = @categoryId,
                                AvailableCopies = @copies
                            WHERE 
                                [Book Id] = @id";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            // 4. Use Parameters (Note: newAuthorId and newCategoryId are now from ComboBoxes)
                            cmd.Parameters.AddWithValue("@id", selectedBook);
                            cmd.Parameters.AddWithValue("@title", newTitle);
                            cmd.Parameters.AddWithValue("@authorId", newAuthorId);
                            cmd.Parameters.AddWithValue("@categoryId", newCategoryId);
                            cmd.Parameters.AddWithValue("@copies", newAvailableCopies);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            // 5. Check Result and Provide Feedback
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Book updated successfully! 🎉", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Clear selection and refresh the list
                                selectedBook = 0;
                                LoadBooks();
                            }
                            else
                            {
                                MessageBox.Show("Book not found or update failed (0 rows affected).", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("Cannot update book. The selected Author or Category ID does not exist.",
                            "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Database error: " + sqlEx.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // --- END UPDATED UPDATE METHOD ---

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            // (The DeleteBtn_Click method is correct and remains unchanged)
            if (selectedBook == 0)
            {
                MessageBox.Show("Please select a book to delete!", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete book ID: {selectedBook}?\n\n" +
                $"This action cannot be undone!",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(connection))
                    {
                        con.Open();

                        string query = "DELETE FROM Books WHERE [Book Id] = @id";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedBook);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Book deleted successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Clear selection
                                selectedBook = 0;

                                // Refresh the book list
                                LoadBooks();
                            }
                            else
                            {
                                MessageBox.Show("Book not found or deletion failed.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("Cannot delete this book. It has associated borrow records.",
                            "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Database error: " + sqlEx.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting book: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtCategoryId_TextChanged(object sender, EventArgs e)
        {
            // This method is now obsolete if you use a ComboBox instead of a TextBox
        }
    }
}