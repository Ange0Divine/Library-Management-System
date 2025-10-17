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
    public partial class Form1 : Form
    {
        private string generatedOTP = "";
        private DateTime otpGeneratedTime;
        private int userId = 0;
        private int userRoleId = 0;

        public Form1()
        {
            InitializeComponent();
            LPasswordBox.UseSystemPasswordChar = true;
        }
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
        // Generate random 6-digit OTP
        private string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
       

        // Send OTP via email
        private bool SendOTPEmail(string recipientEmail, string otp, string fullName)
        {
            try
            {
                // Configure your SMTP settings here
                string senderEmail = "tuyizereangedivine@gmail.com"; // Your email
                string senderPassword = "ldmz pfpf utcf hhrr"; // Your app password

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(recipientEmail);
                mail.Subject = "Library System - Login OTP Verification";
                mail.Body = $@"
Hello {fullName},

Your One-Time Password (OTP) for login is: {otp}

This OTP is valid for 5 minutes.

If you did not request this OTP, please ignore this email.

Best regards,
Library System Team
";
                mail.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtp.EnableSsl = true;

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send OTP email: " + ex.Message, "Email Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LNamesBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void LEmailBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void LPasswordBox_TextChanged(object sender, EventArgs e)
        {

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

                // Hash the entered password
                string hashedPassword = HashPassword(LPasswordBox.Text);

                // Verify credentials in database
                string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();

                    string query = @"SELECT UserId, FullName, Email, RoleId 
                                   FROM [User] 
                                   WHERE FullName = @fullName 
                                   AND Email = @email 
                                   AND Password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@fullName", LNamesBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", LEmailBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // User found - store user details
                                userId = Convert.ToInt32(reader["UserId"]);
                                userRoleId = Convert.ToInt32(reader["RoleId"]);
                                string fullName = reader["FullName"].ToString();
                                string email = reader["Email"].ToString();

                                // Generate and send OTP
                                generatedOTP = GenerateOTP();
                                otpGeneratedTime = DateTime.Now;

                                if (SendOTPEmail(email, generatedOTP, fullName))
                                {
                                    MessageBox.Show("OTP has been sent to your email. Please check your inbox.",
                                        "OTP Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Show OTP verification form
                                    ShowOTPVerificationForm();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid credentials. Please check your name, email, and password.",
                                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowOTPVerificationForm()
        {
            Form otpForm = new Form();
            otpForm.Text = "OTP Verification";
            otpForm.Size = new System.Drawing.Size(400, 200);
            otpForm.StartPosition = FormStartPosition.CenterParent;
            otpForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            otpForm.MaximizeBox = false;
            otpForm.MinimizeBox = false;

            Label lblInstruction = new Label();
            lblInstruction.Text = "Enter the OTP sent to your email:";
            lblInstruction.Location = new System.Drawing.Point(30, 20);
            lblInstruction.Size = new System.Drawing.Size(320, 20);

            TextBox txtOTP = new TextBox();
            txtOTP.Location = new System.Drawing.Point(30, 50);
            txtOTP.Size = new System.Drawing.Size(320, 30);
            txtOTP.MaxLength = 6;
            txtOTP.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);

            Button btnVerify = new Button();
            btnVerify.Text = "Verify OTP";
            btnVerify.Location = new System.Drawing.Point(130, 100);
            btnVerify.Size = new System.Drawing.Size(120, 35);

            btnVerify.Click += (s, e) =>
            {
                VerifyOTP(txtOTP.Text, otpForm);
            };

            otpForm.Controls.Add(lblInstruction);
            otpForm.Controls.Add(txtOTP);
            otpForm.Controls.Add(btnVerify);

            otpForm.ShowDialog();
        }

        // Verify OTP
        private void VerifyOTP(string enteredOTP, Form otpForm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(enteredOTP))
                {
                    MessageBox.Show("Please enter the OTP.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if OTP is expired (5 minutes validity)
                TimeSpan timeDifference = DateTime.Now - otpGeneratedTime;
                if (timeDifference.TotalMinutes > 5)
                {
                    MessageBox.Show("OTP has expired. Please login again to receive a new OTP.",
                        "OTP Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    otpForm.Close();
                    return;
                }

                // Verify OTP
                if (enteredOTP == generatedOTP)
                {
                    MessageBox.Show("Login successful!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    otpForm.Close();

                    // Navigate based on role
                    NavigateByRole(userRoleId, userId);
                }
                else
                {
                    MessageBox.Show("Invalid OTP. Please try again.", "Verification Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during OTP verification: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Navigate to appropriate form based on user role
        private void NavigateByRole(int roleId, int userId)
        {
            try
            {
                if (roleId == 3) // Student
                {
                    // Get StudentId from Student table using UserId
                    int studentId = GetStudentIdFromUserId(userId);

                    if (studentId > 0)
                    {
                        Borrowbook borrowForm = new Borrowbook(studentId, roleId);
                        borrowForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Student record not found. Please contact administrator.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (roleId == 2) // Librarian
                {
                    LibrarianHomeFrm librarianForm = new LibrarianHomeFrm(userId, roleId);
                    librarianForm.Show();
                    this.Hide();
                }
                else if (roleId == 1) // Admin
                {
                    AdminHomeFrm adminForm = new AdminHomeFrm(userId, roleId);
                    adminForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Unknown role. Please contact administrator.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during navigation: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Get StudentId from Student table using UserId
        private int GetStudentIdFromUserId(int userId)
        {
            try
            {
                string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    string query = "SELECT StudentId FROM Student WHERE UserId = @userId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving Student ID: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void seepasscheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LPasswordBox.UseSystemPasswordChar = !seepasscheckBox.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
