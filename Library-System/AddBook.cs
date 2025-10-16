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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void Author_Click(object sender, EventArgs e)
        {

        }
        private void LoadAuthors()
        {

            
                string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [Author]", con);
                    DataSet ds = new DataSet();
                sda.Fill(ds, "[Author]");
                DataTable dt = ds.Tables["[Author]"];
               
                DataRow placeholderRow = dt.NewRow();

                // Set the ID to a value that won't exist (e.g., 0 or -1)
                placeholderRow["AuthorId"] = 0;

                // Set the DisplayMember text to the desired prompt
                placeholderRow["AuthorName"] = "-- Select an Author --";
                

                dt.Rows.InsertAt(placeholderRow, 0);
                authorCombo.DataSource = ds.Tables["[Author]"];
                    authorCombo.DisplayMember = "AuthorName";
                    authorCombo.ValueMember = "AuthorId";
                }
            }
        private void LoadPublishers()
        {


            string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [Publisher]", con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "[Publisher]");
                publisherCombo.DataSource = ds.Tables["[Publisher]"];
                publisherCombo.DisplayMember = "PublisherName";
                publisherCombo.ValueMember = "PublisherId";
            }
        }
        private void LoadCategories()
        {


            string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [Category]", con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "[Category]");
                categoryCombo.DataSource = ds.Tables["[Category]"];
                categoryCombo.DisplayMember = "CategoryName";
                categoryCombo.ValueMember = "CategoryId";
            }
        }


        private void Language()
        {

            {
                string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [Language]", con);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "[Language]");
                    languageCombo.DataSource = ds.Tables["[Language]"];
                    languageCombo.DisplayMember = "LanguageName";
                    languageCombo.ValueMember = "LanguageId";
                    
                }
            }

        }


        private void AddBook_Load(object sender, EventArgs e)
        {
            LoadAuthors();
            Language();
            LoadCategories();
            LoadPublishers();

        }


        private void button1_Click(object sender, EventArgs e)
        {

            {
                string connection = ConfigurationManager.ConnectionStrings["libraryCon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connection))
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();


                        string query = "INSERT INTO Books (BookTittle, AuthorId, CategoryId, PublisherId, LanguageId, [PublicationYear], Pages, TotalCopies, Description, AvailableCopies) " +
               "VALUES (@bookName, @authorId, @categoryId, @publisherId, @languageId, @publicationYear, @pages, @totalCopies, @Description, @availableCopies)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@bookName", bookNameBox.Text);
                        cmd.Parameters.AddWithValue("@authorId", (int)authorCombo.SelectedValue);
                        cmd.Parameters.AddWithValue("@categoryId", (int)categoryCombo.SelectedValue);
                        cmd.Parameters.AddWithValue("@publisherId", (int)publisherCombo.SelectedValue);
                        cmd.Parameters.AddWithValue("@languageId", (int)languageCombo.SelectedValue);
                        cmd.Parameters.AddWithValue("@publicationYear", Convert.ToInt32(pubYearBox.Text));
                        cmd.Parameters.AddWithValue("@pages", Convert.ToInt32(pagesBox.Text));
                        cmd.Parameters.AddWithValue("@totalCopies", Convert.ToInt32(copiesNumberBox.Text));
                        cmd.Parameters.AddWithValue("@description", descriptionBox.Text);
                        cmd.Parameters.AddWithValue("@availableCopies", Convert.ToInt32(copiesNumberBox.Text));
                        cmd.ExecuteNonQuery();

                        con.Close();
                        MessageBox.Show("The new book record has been successfully.",
                                   "Book Save Successful",
                         MessageBoxButtons.OK,
                           MessageBoxIcon.Information
                                                       );
                    }


            }
        }

        private void authorCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void languageCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void categoryCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bookNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void viewBooksBtn_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
