using System.Data;
using System.Data.SqlClient;

namespace BookStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Books", Properties.Settings.Default.AppSetting);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            this.dataGridView1.DataSource = dataSet.Tables[0];
        }
        private void button2_Click(object sender, EventArgs e)
        {

            // Retrieve user input values
            string AuthorName = textBox1.Text;

            // Retrieve other input values as needed

            // Establish connection to the database
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AppSetting))
            {
                try
                {
                    connection.Open();

                    // Construct the INSERT statement
                    string insertQuery = "INSERT INTO Author (author_name) VALUES (@author_name)";
                    // Modify the column names and placeholders as per your table structure

                    // Create a SqlCommand with the INSERT statement and connection
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters and set their values
                        command.Parameters.AddWithValue("@author_name", AuthorName);

                        // Add other parameters as needed

                        // Execute the INSERT statement
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data inserted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while inserting data: " + ex.Message);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Retrieve user input values
            string bookTitle = textBox2.Text;

            // Retrieve other input values as needed

            // Establish connection to the database
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AppSetting))
            {
                try
                {
                    connection.Open();

                    // Construct the INSERT statement
                    string insertQuery = "INSERT INTO Books (Title) VALUES (@Title)";
                    // Modify the column names and placeholders as per your table structure

                    // Create a SqlCommand with the INSERT statement and connection
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters and set their values
                        command.Parameters.AddWithValue("@Title", bookTitle);

                        // Add other parameters as needed

                        // Execute the INSERT statement
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data inserted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while inserting data: " + ex.Message);
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            // Retrieve the value from the TextBox
            string searchValue = textBox3.Text;  // Replace textBox3 with the name of your TextBox control

            // Establish connection to the database
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.AppSetting))
            {
                try
                {
                    connection.Open();

                    // Create the SQL SELECT statement with the WHERE condition
                    string selectQuery = "SELECT * FROM Books WHERE Title = @SearchValue";  // Modify Column1 with the desired column name

                    // Create a SqlCommand to execute the SELECT statement
                    SqlCommand command = new SqlCommand(selectQuery, connection);

                    // Add parameter for the WHERE condition
                    command.Parameters.AddWithValue("@SearchValue", searchValue);

                    // Create a SqlDataAdapter and DataSet to fill with the results
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();

                    // Fill the DataSet with the data from the database
                    dataAdapter.Fill(dataSet);

                    // Bind the DataTable from the DataSet to the DataGridView or perform further processing
                    this.dataGridView1.DataSource = dataSet.Tables[0];

                    MessageBox.Show("Data retrieved successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while retrieving data: " + ex.Message);
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Author", Properties.Settings.Default.AppSetting);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            this.dataGridView1.DataSource = dataSet.Tables[0];
        }
        private void button6_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Publisher", Properties.Settings.Default.AppSetting);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            this.dataGridView1.DataSource = dataSet.Tables[0];
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}

