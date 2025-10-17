using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library_System
{
    public partial class Borrowbook : Form
    {
        private int currentStudentId;
        private int currentUserRoleId;
        private object lblHistoryCount;

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
            LoadBorrowHistory(); // Load student's borrow history
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

                        if (dgvBooks.Columns.Contains("AuthorId"))
                            dgvBooks.Columns["AuthorId"].Visible = false;

                        if (dgvBooks.Columns.Contains("CategoryId"))
                            dgvBooks.Columns["CategoryId"].Visible = false;

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

        // Load borrow history for current student
        private void LoadBorrowHistory()
        {
            try
            {
                // DEBUG: Show StudentId
                MessageBox.Show($"StudentId: {currentStudentId}", "Debug Info");

                if (dgvBooks.SelectedRows.Count == 0)
                {
                    string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(connection))
                    {
                        con.Open();

                        // Query to get current student's borrow history
                        string query = @"SELECT 
                                        br.BorrowId,
                                        br.BookId,
                                        b.BookTittle,
                                        a.AuthorName,
                                        c.CategoryName,
                                        b.AvailableCopies,
                                        br.BorrowDate,
                                        br.ReturnDate
                                    FROM 
                                        Borrowing br
                                    INNER JOIN 
                                        Books b ON br.BookId = b.[Book Id]
                                    INNER JOIN 
                                        Author a ON b.AuthorId = a.AuthorId
                                    INNER JOIN 
                                        Category c ON b.CategoryId = c.CategoryId
                                    WHERE 
                                        br.StudentId = @studentId
                                    ORDER BY 
                                        br.BorrowDate DESC";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@studentId", currentStudentId);

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Bind to history DataGridView
                            dgvHistory.DataSource = dt;

                            // Hide ID columns
                            if (dgvHistory.Columns.Contains("BorrowId"))
                                dgvHistory.Columns["BorrowId"].Visible = false;

                            if (dgvHistory.Columns.Contains("BookId"))
                                dgvHistory.Columns["BookId"].Visible = false;

                            // Rename and format column headers (same as books grid)
                            dgvHistory.Columns["BookTittle"].HeaderText = "Book Title";
                            dgvHistory.Columns["AuthorName"].HeaderText = "Author";
                            dgvHistory.Columns["CategoryName"].HeaderText = "Category";
                            dgvHistory.Columns["AvailableCopies"].HeaderText = "Available Copies";
                            dgvHistory.Columns["BorrowDate"].HeaderText = "Borrow Date";
                            dgvHistory.Columns["ReturnDate"].HeaderText = "Return Date";

                            // Format date columns
                            dgvHistory.Columns["BorrowDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                            dgvHistory.Columns["ReturnDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

                            // Set column widths (same as books grid)
                            dgvHistory.Columns["BookTittle"].Width = 200;
                            dgvHistory.Columns["AuthorName"].Width = 150;
                            dgvHistory.Columns["CategoryName"].Width = 120;
                            dgvHistory.Columns["AvailableCopies"].Width = 100;
                            dgvHistory.Columns["BorrowDate"].Width = 100;
                            dgvHistory.Columns["ReturnDate"].Width = 100;

                            // Set as read-only
                            dgvHistory.ReadOnly = true;

                            // Show record count
                            //lblHistoryCount.Text = $"Your Borrow History: {dt.Rows.Count} book(s)";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading borrow history: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Borrow button click event
        private void borrowBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBooks.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a book to borrow.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dgvBooks.SelectedRows[0];
                int bookId = Convert.ToInt32(selectedRow.Cells["BookId"].Value);
                string bookTitle = selectedRow.Cells["BookTittle"].Value.ToString();
                int availableCopies = Convert.ToInt32(selectedRow.Cells["AvailableCopies"].Value);

                if (availableCopies <= 0)
                {
                    MessageBox.Show("This book is currently not available.", "Not Available",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime borrowDate = DateTime.Now;
                DateTime returnDate = borrowDate.AddDays(14);

                string message = $"Book: {bookTitle}\n\n" +
                               $"Borrow Date: {borrowDate.ToString("dddd, MMMM dd, yyyy")}\n" +
                               $"Return Date: {returnDate.ToString("dddd, MMMM dd, yyyy")}\n\n" +
                               $"You have 14 days to return this book.\n\n" +
                               $"Do you want to borrow this book?";

                DialogResult result = MessageBox.Show(message, "Confirm Borrowing",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    bool success = SaveBorrowRecord(bookId, currentStudentId, borrowDate, returnDate);

                    if (success)
                    {
                        MessageBox.Show("Book borrowed successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh both grids
                        LoadBooks();
                        LoadBorrowHistory(); // Refresh history to show new borrow
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

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Database error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}