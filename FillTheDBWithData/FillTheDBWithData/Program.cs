using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheDBWithData
{
    class Program
    {
        static void Main(string[] args)
        {
            string connetionString;
            //SqlConnection cnn;
            connetionString = @"Data Source=s-mssql2017;Initial Catalog=IN18;User ID=IN18a;Password=TiTIN18";
            //cnn = new SqlConnection(connetionString);

            //SqlCommand command = new SqlCommand("Insert * from MeteostatData ", cnn);
            //string insertCommand = "INSERT into MeteostatData (_Id,) VALUES (2)";

            //SqlCommand sqlCommand = new SqlCommand(insertCommand);
            //sqlCommand.Parameters.AddWithValue("@zip", "india");

            //sqlCommand.Connection = cnn;

            //cnn.Open();

            //sqlCommand.ExecuteNonQuery();



            SqlConnection conn = new SqlConnection(connetionString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select * from MeteostatData", conn);
            //command.Parameters.AddWithValue("@zip", "india");
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader["_Id"]));
                }
            }

            Console.WriteLine("succes");
            Console.ReadKey();

            //conn.Close();


            //using (SqlConnection connection = new SqlConnection(connetionString))
            //{
            //    //String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username,@password, @email)";
            //    string insertCommand = "INSERT into MeteostatData (_Id,) VALUES (2)";


            //    using (SqlCommand command = new SqlCommand(insertCommand, connection))
            //    {
            //        //command.Parameters.AddWithValue("@zip", "india");

            //        //command.Parameters.AddWithValue("@id", "abc");
            //        //command.Parameters.AddWithValue("@username", "IN18a");
            //        //command.Parameters.AddWithValue("@password", "TiTIN18");
            //        //command.Parameters.AddWithValue("@email", "abc");

            //        connection.Open();
            //        int result = command.ExecuteNonQuery();

            //        // Check Error
            //        if (result < 0)
            //            Console.WriteLine("Error inserting data into Database!");
            //    }
            //}


        }
    }
}
