using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Library_System
{
    public partial class Register : Form
    {
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

        // Get selected role ID
        private int GetSelectedRoleId()
        {
            if (rbStudent.Checked)
                return 3; // Student
            else if (rbLibrarian.Checked)
                return 2; // Librarian
            else if (rbAdmin.Checked)
                return 1; // Admin
            else
                return 0; // No role selected
        }

        // Check if student role is selected
        private bool IsStudentRole()
        {
            return rbStudent.Checked;
        }

        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            // Initialize password box to show dots
            RPasswordBox.UseSystemPasswordChar = true;
        }

        // Role radio buttons changed event - to enable/disable Student ID field
        private void rbStudent_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStudentIdRequirement();
        }

        private void rbLibrarian_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStudentIdRequirement();
        }

        private void rbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStudentIdRequirement();
        }

        // Update Student ID field requirement based on role
        private void UpdateStudentIdRequirement()
        {
            if (IsStudentRole())
            {
                // Student ID is required for students
                studentIdBox.Enabled = true;
                studentIdBox.BackColor = System.Drawing.Color.White;
            }
            else
            {
                // Student ID is optional for non-students
                studentIdBox.Enabled = false;
                studentIdBox.BackColor = System.Drawing.Color.LightGray;
                studentIdBox.Clear();
            }
        }

        // Create Account button click
        private void CreateAccBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(RNamesBox.Text))
                {
                    MessageBox.Show("Please enter a full name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(REmailBox.Text))
                {
                    MessageBox.Show("Please enter an email.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(RPasswordBox.Text))
                {
                    MessageBox.Show("Please enter a password.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int roleId = GetSelectedRoleId();
                if (roleId == 0)
                {
                    MessageBox.Show("Please select a role.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate Student ID only if Student role is selected
                int? studentId = null;
                if (IsStudentRole())
                {
                    if (string.IsNullOrWhiteSpace(studentIdBox.Text))
                    {
                        MessageBox.Show("Please enter a Student ID.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!int.TryParse(studentIdBox.Text, out int parsedStudentId))
                    {
                        MessageBox.Show("Please enter a valid Student ID (numbers only).", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    studentId = parsedStudentId;
                }

                // Parse phone number (now optional)
                int? phoneNumber = null;
                if (!string.IsNullOrWhiteSpace(studentIdBox.Text) && !IsStudentRole())
                {
                    if (int.TryParse(studentIdBox.Text, out int parsedPhone))
                    {
                        phoneNumber = parsedPhone;
                    }
                }

                // Hash the password
                string hashedPassword = HashPassword(RPasswordBox.Text);

                // Database insertion
                string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connection))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    // Start transaction to ensure both inserts succeed
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            int newUserId = 0;

                            // 1. Insert into User table
                            string userQuery = @"INSERT INTO [User] (FullName, Email, [Phone Number], Password, RoleId, RegisteredAt) 
                                               VALUES (@fullName, @email, @phoneNbr, @password, @roleId, @registeredAt);
                                               SELECT CAST(SCOPE_IDENTITY() AS INT);";

                            using (SqlCommand cmdUser = new SqlCommand(userQuery, con, transaction))
                            {
                                cmdUser.Parameters.AddWithValue("@fullName", RNamesBox.Text.Trim());
                                cmdUser.Parameters.AddWithValue("@email", REmailBox.Text.Trim());
                                cmdUser.Parameters.AddWithValue("@phoneNbr", phoneNumber.HasValue ? (object)phoneNumber.Value : DBNull.Value);
                                cmdUser.Parameters.AddWithValue("@password", hashedPassword);
                                cmdUser.Parameters.AddWithValue("@roleId", roleId);
                                cmdUser.Parameters.AddWithValue("@registeredAt", DateTime.Now);

                                // Get the newly inserted UserId
                                newUserId = (int)cmdUser.ExecuteScalar();
                            }

                            // 2. If Student role, also insert into Student table
                            if (IsStudentRole() && studentId.HasValue)
                            {
                                string studentQuery = @"INSERT INTO Student (StudentId, UserId, Department, YearLevel) 
                                                      VALUES (@studentId, @userId, @department, @yearLevel)";

                                using (SqlCommand cmdStudent = new SqlCommand(studentQuery, con, transaction))
                                {
                                    cmdStudent.Parameters.AddWithValue("@studentId", studentId.Value);
                                    cmdStudent.Parameters.AddWithValue("@userId", newUserId);
                                    // Set default values for Department and YearLevel (you can modify these)
                                    cmdStudent.Parameters.AddWithValue("@department", DBNull.Value); // Can be updated later
                                    cmdStudent.Parameters.AddWithValue("@yearLevel", DBNull.Value); // Can be updated later

                                    cmdStudent.ExecuteNonQuery();
                                }
                            }

                            // Commit transaction if all operations succeed
                            transaction.Commit();

                            string roleMessage = IsStudentRole() ? "Student" : (roleId == 2 ? "Librarian" : "Admin");
                            MessageBox.Show($"{roleMessage} Registered Successfully!",
                                          "Registration Successful",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);

                            // Clear form after successful registration
                            ClearForm();
                        }
                        catch (SqlException sqlEx)
                        {
                            // Rollback transaction on error
                            transaction.Rollback();

                            // Check for specific errors
                            if (sqlEx.Number == 2627 || sqlEx.Number == 2601) // Duplicate key error
                            {
                                MessageBox.Show("This Student ID or Email already exists. Please use a different one.",
                                              "Duplicate Entry",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show("Database Error: " + sqlEx.Message,
                                              "Error",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message,
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        // Clear form fields
        private void ClearForm()
        {
            RNamesBox.Clear();
            REmailBox.Clear();
            studentIdBox.Clear();
            RPasswordBox.Clear();
            rbStudent.Checked = false;
            rbLibrarian.Checked = false;
            rbAdmin.Checked = false;
            chkSeePassword.Checked = false;
            RPasswordBox.UseSystemPasswordChar = true;
        }

        // See password checkbox
        private void chkSeePassword_CheckedChanged(object sender, EventArgs e)
        {
            RPasswordBox.UseSystemPasswordChar = !chkSeePassword.Checked;
        }

        // Empty event handlers (can be removed if not needed)
        private void LEmailBox_TextChanged(object sender, EventArgs e) { }
        private void LNamesBox_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RPasswordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void StudentId_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void rbStudent_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void rbLibrarian_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void rbAdmin_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}