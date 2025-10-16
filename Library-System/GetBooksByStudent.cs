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
    public partial class GetBooksByStudent : Form
    {
        public GetBooksByStudent()
        {
            InitializeComponent();
        }

        private void GetBooksBtn_Click(object sender, EventArgs e)
        {
            // 1.Get the Student ID from the TextBox
            if (!int.TryParse(txtStudentID.Text, out int studentId))
            {
                MessageBox.Show("Please enter a valid Student ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Call the Stored Procedure
            try
            {
                // Use 'using' blocks to ensure the connection and command objects are properly closed and disposed
                // IMPORTANT: Make sure you have added a reference to System.Configuration 
                // and have a valid connection string named "libraryCon" in your App.config/Web.config file.
                string connectionString = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // The name of the stored procedure
                    using (SqlCommand command = new SqlCommand("sp_GetBorrowedBooksByStudent", con))
                    {
                        // Specify that the command type is a Stored Procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Add the parameter required by the stored procedure
                        command.Parameters.AddWithValue("@StudentID", studentId);

                        // Execute the command and get the results
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // 3. Process the Results
                            string result = $"Borrowing Records for Student ID {studentId}:\n";
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    // 🌟 ADJUSTMENT HERE: Read BookId instead of BookTitle
                                    int bookId = reader.GetInt32(reader.GetOrdinal("BookId"));

                                    // You can read the BorrowingID as well for full data
                                    int borrowId = reader.GetInt32(reader.GetOrdinal("BorrowId"));

                                    DateTime borrowDate = (DateTime)reader["BorrowDate"];

                                    // 🌟 ADJUSTMENT HERE: Change the output message
                                    result += $"- Borrow ID: {borrowId}, Book ID: {bookId} (Borrowed: {borrowDate.ToShortDateString()})\n";
                                }
                            }
                            else
                            {
                                result += "No borrowing records found.";
                            }

                            MessageBox.Show(result, "Student Borrowing Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
