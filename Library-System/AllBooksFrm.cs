using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_System
{
    public partial class AllBooksFrm : Form
    {
        private void LoadBooks()
        {
            try
            {
                string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();

                    // Query with both IDs and Names (useful for editing)
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

                        // Bind to DataGridView
                        dgvBooks.DataSource = dt;

                        // Hide ID columns (but they're still accessible)
                        if (dgvBooks.Columns.Contains("AuthorId"))
                            dgvBooks.Columns["AuthorId"].Visible = false;

                        if (dgvBooks.Columns.Contains("CategoryId"))
                            dgvBooks.Columns["CategoryId"].Visible = false;

                        // Rename column headers for better display
                        dgvBooks.Columns["BookTittle"].HeaderText = "Book Title";
                        dgvBooks.Columns["AuthorName"].HeaderText = "Author";
                        dgvBooks.Columns["CategoryName"].HeaderText = "Category";
                        dgvBooks.Columns["AvailableCopies"].HeaderText = "Available Copies";

                        // Optional: Set column widths
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


        public AllBooksFrm()
        {
            InitializeComponent();
        }

        private void AllBooksdataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AllBooksFrm_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a valid data row (not the header) was clicked
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBooks.Rows[e.RowIndex];

                // Ensure the column name 'BookId' matches the alias you used in LoadBooks()
                // (Your LoadBooks() query uses 'BookId')
                if (row.Cells["BookId"].Value != null)
                {
                    // Safely convert the BookId from the cell's value to an integer
                    if (int.TryParse(row.Cells["BookId"].Value.ToString(), out int bookId))
                    {
                        selectedBook = bookId;

                        // *** IMPORTANT ***
                        // At this point, you should also load the selected book's 
                        // data (Title, AuthorId, etc.) into your text boxes so the 
                        // user can see and edit the current values.
                        // e.g., txtBookTitle.Text = row.Cells["BookTittle"].Value.ToString();
                    }
                    else
                    {
                        // Failed to parse, reset selection
                        selectedBook = 0;
                    }
                }
            }
        }

        
        private int selectedBook = 0;
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
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

                        // FIXED: Changed "Books" to "Book" (your actual table name)
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
                    // Handle foreign key errors (if book is referenced in Borrow table)
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

        // ADD THIS METHOD if you don't have it already:


        // ADD THIS EVENT HANDLER to capture selected book:
        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                selectedBook = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["BookId"].Value);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (selectedBook == 0)
            {
                MessageBox.Show("Please select a book to update!", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // You would get the new values from your UI controls here.
            // Replace these placeholder variables with your actual UI control references.
            string newTitle = txtTitle.Text.Trim(); // Example: Assuming a textbox named txtBookTitle
            int newAuthorId;
            int newCategoryId;
            int newAvailableCopies;

            // Basic Input Validation
            if (string.IsNullOrEmpty(newTitle))
            {
                MessageBox.Show("Book Title cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtAuthorId.Text, out newAuthorId) || newAuthorId <= 0) // Example: Assuming a textbox for Author ID
            {
                MessageBox.Show("Please enter a valid Author ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtCategoryId.Text, out newCategoryId) || newCategoryId <= 0) // Example: Assuming a textbox for Category ID
            {
                MessageBox.Show("Please enter a valid Category ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtCopies.Text, out newAvailableCopies) || newAvailableCopies < 0) // Example: Assuming a textbox for copies
            {
                MessageBox.Show("Please enter a valid number of Available Copies.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // 2. Confirm Update
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to update book ID: {selectedBook}?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question // Changed icon to Question as it's not destructive like a delete
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
                            // 4. Use Parameters to prevent SQL Injection
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
                    // Handle specific SQL errors, like trying to assign an AuthorId or CategoryId
                    // that doesn't exist (Foreign Key Constraint violation, error number 547).
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("Cannot update book. Author ID or Category ID does not exist.",
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
    }
    }




