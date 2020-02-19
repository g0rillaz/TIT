using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TITLib
{
    public static class Statics
    {
        public static string connectionstring = "Data Source=s-mssql2019.it.gla; Initial Catalog=ProjectTIT; User id=IN18a; Password=IN18BSDGG;";
        //Server=localhost;Database=IN18;User Id=IN18a;Password=IN18BSDGG;";
        private static DBConnection dBConnection;
        public static List<Country> list_country;
        public static List<Station> list_stations;

        /// <summary>
        /// Lädt alle Länder aus der Datenbank und fügt Sie zur list_country hinzu
        /// </summary>
        public static  void getListCountrys()
        {
            list_country = new List<Country>();
            dBConnection = new DBConnection();
            dBConnection.createConnection(connectionstring);

            string command = "SELECT * FROM V_COUNTRY";
            DataTable table = dBConnection.readDataSql(command);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                Country country = new Country();
                country.ID = Convert.ToInt32(table.Rows[i]["ID"]);
                country.Name = table.Rows[i]["NAME"].ToString();
                country.IsoCode = table.Rows[i]["A_CODE_2"].ToString();

                list_country.Add(country);
            }

        }

        /// <summary>
        /// Lädt eine Liste aller Stationen
        /// </summary>
        public static void getListStationsAll()
        {
            list_stations = new List<Station>();
            dBConnection = new DBConnection();
            dBConnection.createConnection(connectionstring);

            string command = "SELECT * FROM [dbo].[V_STATIONS_METEO-WITHOUT_ELEV]";
            DataTable table = dBConnection.readDataSql(command);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                Station station = new Station();
                station.ID = Convert.ToInt32(table.Rows[i]["ID"]);
                station.Number = table.Rows[i]["NUMBER"].ToString();
                station.Name = table.Rows[i]["NAME"].ToString();
                //station.Country = table.Rows[i]["COUNTRY_NAME_TMP"].ToString();
                station.Country = table.Rows[i]["COUNTRY_ID"].ToString();
                station.Longitude = table.Rows[i]["LON"].ToString();
                station.Latitude = table.Rows[i]["LAT"].ToString();

                list_stations.Add(station);
            }

        }

        /// <summary>
        /// Lädt eine Liste aller Stationen eines bestimmten Landes
        /// </summary>
        /// <param name="isocode"></param>
        public static void getListStationsByCountry(string isocode)
        {
            list_stations = new List<Station>();
            dBConnection = new DBConnection();
            dBConnection.createConnection(connectionstring);

            string command = $"SELECT * FROM PTIT_V_STAT_METEO WHERE COUNTRY_NAME_TMP='{isocode}'";
            DataTable table = dBConnection.readDataSql(command);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                Station station = new Station();
                station.ID = Convert.ToInt32(table.Rows[i]["ID"]);
                station.Number = table.Rows[i]["NUMBER"].ToString();
                station.Name = table.Rows[i]["NAME"].ToString();
                station.Country = table.Rows[i]["COUNTRY_NAME_TMP"].ToString();
                station.Longitude = table.Rows[i]["LON"].ToString();
                station.Latitude = table.Rows[i]["LAT"].ToString();

                list_stations.Add(station);
            }
        }

    }
}
