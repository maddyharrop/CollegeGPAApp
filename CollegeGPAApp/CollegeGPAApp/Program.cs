using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace CollegeGPAApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString;

            //Get ConnectionString form app.config.
            //Make sure the connection string name is the same with app.config.
            connString = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;

            //Create SQL connection object.
            //Pass in the connection string into the constructor.
            SqlConnection sqlConnection = new SqlConnection(connString);
                        
            try
            {
                //Open the database connection.
                sqlConnection.Open();
                Console.WriteLine("Connection to database is  successfull");
            }
            catch (Exception e) //Creating an object from Expection class.
            {
                //If there are errors, it will come to this block.
                Console.WriteLine($"Connection to database is unsuccessfull. Error");
                
            }
            finally //Finally block will run no matter what
            {
                //Close the database connection after use.
                sqlConnection.Close();
            }
                        
        }
    }
}
