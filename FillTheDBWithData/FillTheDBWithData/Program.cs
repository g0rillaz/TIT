using System;
using System.Data;
using System.Data.SqlClient;

namespace FillTheDBWithData
{

    class Program
    {
        static void Main(string[] args)
        {
            APIInteraction apiInteaction = new APIInteraction();
            string startDate = "2017-01-01";
            string endDate = "2017-01-02";

            apiInteaction.getData(startDate, endDate);
       
        //MSSQL connection
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.ConnectionString = "server=DESKTOP-I80KJME\\DBSERVER;initial catalog=IN18";
            builder.IntegratedSecurity = true;

            //using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            //{
            //    conn.Open();
            //    Console.WriteLine("works");

                //Select cmd
                //SqlCommand SelectAll = new SqlCommand("SELECT * FROM [dbo].[MeteostatData]", conn);

                //SqlDataReader reader = SelectAll.ExecuteReader();

                //while (reader.Read())
                //{
                //    Console.WriteLine("{0}", reader[0]);
                //}
                //reader.Close();
                //conn.Close();
                //Console.ReadLine();

                //_________

                //Insert cmd
                //SqlCommand InsertContact = new SqlCommand("INSERT INTO [dbo].[MeteostatData](_ID) VALUES(10)", conn);
                //InsertContact.ExecuteNonQuery();
                ////using (SqlConnection openCon = new SqlConnection(connetionString))
                ////{
                //    string saveStaff = "INSERT into [dbo].[MeteostatData] (_Id,_StationId) VALUES (@_Id, @_StationId)";

                //    using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                //    {
                //        querySaveStaff.Connection = conn;
                //    querySaveStaff.Parameters.Add("@_Id", SqlDbType.Int).Value = 5;
                //    querySaveStaff.Parameters.Add("@_StationId", SqlDbType.Int).Value = 123;


                //    //openCon.Open();

                //    querySaveStaff.ExecuteNonQuery();
                //    }
                //}
            //}

            






           


        }
    }
}
