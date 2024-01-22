using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentCrud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-K44F6SQU\\SQLEXPRESS01;Initial Catalog=StudentInfo;Integrated Security=True;Encrypt=False");
        private void button1_Click(object sender, EventArgs e)
        {
            // Create Student Data

            int studentID = int.Parse(textBox1.Text);
            string studentName = textBox2.Text;
            string city = comboBox1.Text;
            string contact = textBox4.Text;
            string sex = " ";
            DateTime enrollmentDate = DateTime.Parse(dateTimePicker1.Text);
            int age = int.Parse(textBox3.Text);

            if (radioButton1.Checked == true)
            {
                sex = "Male";
            }
            else
            {
                sex = "Female";
            }
            
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("exec InsertStudent '" + studentID + "','"
                                                                          + studentName + "','"
                                                                          + city + "','"
                                                                          + age + "','"
                                                                          + sex + "','"
                                                                          + enrollmentDate + "','"
                                                                          + contact + "'", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Data Inserted");
            GetStudentList();
        }

        void GetStudentList()
        {
            SqlCommand sqlCommand = new SqlCommand("exec ListStudent", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudentList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Update Student Data

            int studentID = int.Parse(textBox1.Text);
            string studentName = textBox2.Text;
            string city = comboBox1.Text;
            string contact = textBox4.Text;
            string sex = " ";
            DateTime enrollmentDate = DateTime.Parse(dateTimePicker1.Text);
            int age = int.Parse(textBox3.Text);

            if (radioButton1.Checked == true)
            {
                sex = "Male";
            }
            else
            {
                sex = "Female";
            }

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("exec UpdateStudent '" + studentID + "','"
                                                                          + studentName + "','"
                                                                          + city + "','"
                                                                          + age + "','"
                                                                          + sex + "','"
                                                                          + enrollmentDate + "','"
                                                                          + contact + "'", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Data Updated");
            GetStudentList();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Delete Student Data

            int studentID = int.Parse(textBox1.Text);
            
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("exec DeleteStudent '" + studentID + "'", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Data Deleted");
            GetStudentList();
        }
    }
}
