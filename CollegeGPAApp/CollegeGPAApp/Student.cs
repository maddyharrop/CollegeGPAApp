using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeGPAApp.Student
{
    class Student
    {
        public int Id { get; set; }
        public string SFirstName { get; set; }
        public string SLastName { get; set; }
        public string SEmail { get; set; }
        public int DoB { get; set; }


        static string connString = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;

        public DataTable Select()
        {
            //Database connection
            SqlConnection sqlConnection = new SqlConnection(connString);
            DataTable dt = new DataTable();
            try
            {
                //Writing sql query
                string sql = "SELECT * FROM Student";

                //Creating cmd using sql and sqlConnection
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                //Creating SQL DataAdapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open the database connection.
                sqlConnection.Open();

                adapter.Fill(dt);
                Console.WriteLine("Connection to database is  successfull");

            }
            catch (Exception e)
            {

            }
            finally
            {
                //Close the database connection after use.
                sqlConnection.Close();
            }
            return dt;

        }
        //Method to insert data in database from our application
        public bool InsertStudent(Student s)
        {
            //Creating a default return type and setting its value to false
            bool isSuccess = false;

            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                //Creating a sql querys to inset data
                string newStudent = $"INSERT INTO Student ( SFirstName, SLastName, , DoB) VALUES (@SFirstName, @SLastName, @SEmail, @DoB)";
                SqlCommand cmd = new SqlCommand(newStudent, sqlConnection);
                //Creat parameters to add data
                cmd.Parameters.AddWithValue("@SFirstName", s.SFirstName);
                cmd.Parameters.AddWithValue("@SLastName", s.SLastName);
                cmd.Parameters.AddWithValue("@SEmail", s.SEmail);
                cmd.Parameters.AddWithValue("@DoB", s.DoB);

                //Connection open here
                sqlConnection.Open();

                int rows = cmd.ExecuteNonQuery();
                //If query runs successfully then the value of rows will be greater than zero e;se its value will be 0.
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception e)
            {

            }
            finally
            {
                //Close the database connection after use.
                sqlConnection.Close();
            }
            return isSuccess;
        }

        //Method to update data in database from our application
        public bool UpdateContact(Student s)
        {
            //Creating a default return type and setting its value to false
            bool isSuccess = false;

            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                //SQl to update data in the database
                string student = "UPDATE Student SET SFirstname = @SFirstname, SLastname = @SLastname, SEmail = @SEmail, DoB =@DoB WHERE Id = @Id";

                //Creating SQL Command
                SqlCommand cmd = new SqlCommand(student, sqlConnection);
                //Create parrameters to add values
                cmd.Parameters.AddWithValue("@SFirstName", s.SFirstName);
                cmd.Parameters.AddWithValue("@SLastName", s.SLastName);
                cmd.Parameters.AddWithValue("@SEmail", s.SEmail);
                cmd.Parameters.AddWithValue("@DoB", s.DoB);

                //Connection open here
                sqlConnection.Open();

                int rows = cmd.ExecuteNonQuery();
                //If query runs successfully then the value of rows will be greater than zero e;se its value will be 0.
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception e)
            {

            }
            finally
            {
                //Close the database connection after use.
                sqlConnection.Close();
            }
            return isSuccess;
        }

        //Method to update data in database from our application
        public bool DeleteStudent(Student s)
            {
                //Creating a default return type and setting its value to false
                bool isSuccess = false;

                SqlConnection sqlConnection = new SqlConnection(connString);
                try
                {
                    //SQl to update data in the database
                    string student = "DELETE FROM Student WHERE Id = Id";

                    //Creating SQL Command
                    SqlCommand cmd = new SqlCommand(student, sqlConnection);
                    cmd.Parameters.AddWithValue("@Id", s.Id);

                    //Connection open here
                    sqlConnection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    //If query runs successfully then the value of rows will be greater than zero e;se its value will be 0.
                    if (rows > 0)
                    {
                        isSuccess = true;
                    }
                    else
                    {
                        isSuccess = false;
                    }

                }
                catch (Exception e)
                {

                }
                finally
                {
                    //Close the database connection after use.
                    sqlConnection.Close();
                }
                return isSuccess;

                //Method to Deted data from database

            }
        }
    }
