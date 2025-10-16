using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_System
{
    public partial class StudentLoginFrm : Form
    {
        public StudentLoginFrm()
        {
            InitializeComponent();
        }

        private void StudentLoginFrm_Load(object sender, EventArgs e)
        {
            // Initialize password box to show dots
            LPasswordBox.UseSystemPasswordChar = true;
        }

        // Hash password method
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
       

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(LNamesBox.Text))
                {
                    MessageBox.Show("Please enter your full name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(LStudentIdBox.Text))
                {
                    MessageBox.Show("Please enter your Student ID.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(LEmailBox.Text))
                {
                    MessageBox.Show("Please enter your email.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(LPasswordBox.Text))
                {
                    MessageBox.Show("Please enter your password.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse Student ID
                if (!int.TryParse(LStudentIdBox.Text, out int enteredStudentId))
                {
                    MessageBox.Show("Please enter a valid Student ID (numbers only).", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hash the entered password
                string hashedPassword = HashPassword(LPasswordBox.Text);

                // Verify credentials in database
                string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();

                    // Join User and Student tables to verify all credentials
                    string query = @"SELECT u.UserId, u.FullName, u.Email, u.RoleId, s.StudentId 
                                   FROM [User] u
                                   INNER JOIN Student s ON u.UserId = s.UserId
                                   WHERE u.FullName = @fullName 
                                   AND s.StudentId = @studentId
                                   AND u.Email = @email 
                                   AND u.Password = @password
                                   AND u.RoleId = 3";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@fullName", LNamesBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentId", enteredStudentId);
                        cmd.Parameters.AddWithValue("@email", LEmailBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // User found - get details
                                int userId = Convert.ToInt32(reader["UserId"]);
                                int studentId = Convert.ToInt32(reader["StudentId"]);
                                int userRoleId = Convert.ToInt32(reader["RoleId"]);
                                string fullName = reader["FullName"].ToString();

                                // Success - show message
                                MessageBox.Show($"Login Successful!\n\nWelcome {fullName}\nStudent ID: {studentId}",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Navigate to BorrowBook form with StudentId
                                Borrowbook borrowBookForm = new Borrowbook(studentId, userRoleId);
                                borrowBookForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid credentials. Please check:\n" +
                                              "- Full Name\n" +
                                              "- Student ID\n" +
                                              "- Email\n" +
                                              "- Password",
                                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database Error: " + sqlEx.Message +
                              "\n\nPlease check your database connection.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void seepasscheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LPasswordBox.UseSystemPasswordChar = !seepasscheckBox.Checked;
        }
    }
}
