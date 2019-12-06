using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TITLib
{
    public class DBConnection
    {
        private SqlConnection _connection;
        public SqlConnection Connection
        {
            get => _connection;
            set
            {
                _connection = value;
            }
        }

        private SqlCommand _command;
        public SqlCommand Command
        {
            get => _command;
            set
            {
                _command = value;
            }
        }

        private SqlDataReader _datareader;
        public SqlDataReader DataReader
        {
            get => _datareader;
            set
            {
                _datareader = value;
            }
        }

        /// <summary>
        /// Erstellt eine neue Verbindung
        /// </summary>
        /// <param name="connectionstring"></param>
        public void createConnection(string connectionstring)
        {
            Connection = new SqlConnection(connectionstring);
        }

        /// <summary>
        /// Erstellt einen neuen Command
        /// </summary>
        /// <param name="command"></param>
        public void createCommand(string command)
        {
            Command = new SqlCommand(command, Connection);
        }


        /// <summary>
        /// Ausführen von SQL Befehlen die keine Rückgabe erwarten
        /// </summary>
        /// <param name="command"></param>
        public void executeSql(string command)
        {     
            createCommand(command);

            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        /// <summary>
        /// Ausführen von SQL Befehlen die eine Rückgabe erwarten
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public DataTable readDataSql(string command)
        {
            createCommand(command);
            Connection.Open();
            DataTable returnData = readData();
            Connection.Close();
            return returnData;
        }

        private DataTable readData()
        {
            DataReader = Command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(DataReader);

            return dataTable;
        }

    }
}
