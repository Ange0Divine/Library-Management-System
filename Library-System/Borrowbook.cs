using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library_System
{
    public partial class Borrowbook : Form
    {
        private int currentStudentId; // Store the logged-in student's ID (actual StudentId from Student table)
        private int currentUserRoleId; // Store the user's role

        // Constructor to receive user information from login
        public Borrowbook(int studentId, int roleId)
        {
            InitializeComponent();
            currentStudentId = studentId;
            currentUserRoleId = roleId;
        }

        // Default constructor (for designer)
        public Borrowbook()
        {
            InitializeComponent();
        }

        private void Borrowbook_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        // Load books into DataGridView
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
        // Borrow button click event
        private void borrowBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a book is selected
                if (dgvBooks.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a book to borrow.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get selected book details
                DataGridViewRow selectedRow = dgvBooks.SelectedRows[0];
                int bookId = Convert.ToInt32(selectedRow.Cells["BookId"].Value);
                string bookTitle = selectedRow.Cells["BookTittle"].Value.ToString();
                int availableCopies = Convert.ToInt32(selectedRow.Cells["AvailableCopies"].Value);

                // Check if book is available
                if (availableCopies <= 0)
                {
                    MessageBox.Show("This book is currently not available.", "Not Available",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calculate borrow and return dates
                DateTime borrowDate = DateTime.Now;
                DateTime returnDate = borrowDate.AddDays(14);

                // Show confirmation message with dates
                string message = $"Book: {bookTitle}\n\n" +
                               $"Borrow Date: {borrowDate.ToString("dddd, MMMM dd, yyyy")}\n" +
                               $"Return Date: {returnDate.ToString("dddd, MMMM dd, yyyy")}\n\n" +
                               $"You have 14 days to return this book.\n\n" +
                               $"Do you want to borrow this book?";

                DialogResult result = MessageBox.Show(message, "Confirm Borrowing",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    // Save borrowing record to database
                    bool success = SaveBorrowRecord(bookId, currentStudentId, borrowDate, returnDate);

                    if (success)
                    {
                        MessageBox.Show("Book borrowed successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh the books list to show updated available copies
                        LoadBooks();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error borrowing book: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Save borrow record to database and update available copies
        private bool SaveBorrowRecord(int bookId, int studentId, DateTime borrowDate, DateTime returnDate)
        {
            string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                // Start a transaction to ensure both operations complete successfully
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert borrow record
                        string insertQuery = @"INSERT INTO Borrowing (BookId, StudentId, BorrowDate, ReturnDate) 
                                             VALUES (@bookId, @studentId, @borrowDate, @returnDate)";

                        using (SqlCommand cmdInsert = new SqlCommand(insertQuery, con, transaction))
                        {
                            cmdInsert.Parameters.AddWithValue("@bookId", bookId);
                            cmdInsert.Parameters.AddWithValue("@studentId", studentId);
                            cmdInsert.Parameters.AddWithValue("@borrowDate", borrowDate);
                            cmdInsert.Parameters.AddWithValue("@returnDate", returnDate);
                            cmdInsert.Parameters.AddWithValue("@fineAmount", 0); // Initial fine is 0

                            cmdInsert.ExecuteNonQuery();
                        }

                        // 2. Update available copies (decrease by 1)
                        string updateQuery = @"UPDATE Books 
                                             SET AvailableCopies = AvailableCopies - 1 
                                             WHERE [Book Id] = @bookId";

                        using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, con, transaction))
                        {
                            cmdUpdate.Parameters.AddWithValue("@bookId", bookId);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        // Commit transaction if both operations succeed
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction if any error occurs
                        transaction.Rollback();
                        MessageBox.Show("Database error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        // Check if student has already borrowed this book and not returned it
        private bool HasAlreadyBorrowedBook(int bookId, int studentId)
        {
            try
            {
                string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();

                    // Check for active borrows (you might need to add a Status column to track returns)
                    string query = @"SELECT COUNT(*) 
                                   FROM Borrow 
                                   WHERE BookId = @bookId 
                                   AND StudentId = @studentId 
                                   AND ReturnDate >= @today";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@today", DateTime.Now);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking borrow status: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Handle cell click if needed
        }

        private void dgvHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Handle history cell click if needed
        }
    }
}