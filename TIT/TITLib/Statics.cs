using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        /// Lädt eine Liste aller Stationen einer bestimmten Datenquelle
        /// </summary>
        public static void getListStationsAllByDatasource(string datasource)
        {
            list_stations = new List<Station>();
            dBConnection = new DBConnection();
            dBConnection.createConnection(connectionstring);
            string command;

            if (datasource == "meteo")
            {
                command = $"SELECT ID, NUMBER, NAME, COUNTRY_ID, COUNTRY_NAME, COUNTRY_ISO, LAT, LON FROM V_STATIONS_METEO";

            }
            else
            {
                command = $"SELECT ID, NUMBER, NAME, COUNTRY_ID, COUNTRY_NAME, COUNTRY_ISO, LAT, LON FROM V_STATIONS_NOAA";
            }

            DataTable table = dBConnection.readDataSql(command);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                Station station = new Station();
                station.ID = Convert.ToInt32(table.Rows[i]["ID"]);
                station.Number = table.Rows[i]["NUMBER"].ToString();
                station.Name = table.Rows[i]["NAME"].ToString();
                station.CountryId = table.Rows[i]["COUNTRY_ID"].ToString();
                station.CountryName = table.Rows[i]["COUNTRY_NAME"].ToString();
                station.CountryIso = table.Rows[i]["COUNTRY_ISO"].ToString();
                station.Longitude = table.Rows[i]["LON"].ToString();
                station.Latitude = table.Rows[i]["LAT"].ToString();

                list_stations.Add(station);
            }

        }

        /// <summary>
        /// Lädt eine Liste aller Stationen eines bestimmten Landes
        /// </summary>
        /// <param name="isocode"></param>
        public static void getListStationsByCountry(string isocode, string datasource)
        {
            list_stations = new List<Station>();
            dBConnection = new DBConnection();
            dBConnection.createConnection(connectionstring);
            string command;

            if(datasource == "meteo")
            {
                command = $"SELECT ID, NUMBER, NAME, COUNTRY_ID, COUNTRY_NAME, COUNTRY_ISO, LAT, LON FROM V_STATIONS_METEO WHERE COUNTRY_ISO='{isocode}'";

            } else
            {
                command = $"SELECT ID, NUMBER, NAME, COUNTRY_ID, COUNTRY_NAME, COUNTRY_ISO, LAT, LON FROM V_STATIONS_NOAA WHERE COUNTRY_ISO='{isocode}'";
            }

            
            DataTable table = dBConnection.readDataSql(command);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                Station station = new Station();
                station.ID = Convert.ToInt32(table.Rows[i]["ID"]);
                station.Number = table.Rows[i]["NUMBER"].ToString();
                station.Name = table.Rows[i]["NAME"].ToString();
                station.CountryId = table.Rows[i]["COUNTRY_ID"].ToString();
                station.CountryName = table.Rows[i]["COUNTRY_NAME"].ToString();
                station.CountryIso = table.Rows[i]["COUNTRY_ISO"].ToString();
                station.Longitude = table.Rows[i]["LON"].ToString();
                station.Latitude = table.Rows[i]["LAT"].ToString();

                list_stations.Add(station);
            }
        }

        /// <summary>
        /// Fragt alle Wettedaten mit den vorgegebenen Bedingungen bei der Datenbank ab.
        /// Zur DB Abfrage wird eine Stored Procedure verwendet
        /// Übergeben werden Land, Station und Bedingungen
        /// </summary>
        public static void getWeatherData(Country country, Station station, Condition condition)
        {
            List<WeatherData> list_weatherdata = new List<WeatherData>();
            dBConnection = new DBConnection();
            dBConnection.createConnection(connectionstring);
            string command = $"SELECT ";


            if(condition.Raw)
            {
                command += "RAW, ";
            }

            if(condition.Mean)
            {
                command += "MEAN, ";
            }

            if (condition.Median)
            {
                command += "MEDIAN, ";
            }

            if (condition.Min)
            {
                command += "MIN, ";
            }

            if (condition.Max)
            {
                command += "MAX, ";
            }

            if (condition.Deviation)
            {
                command += "DEVIATION, ";
            }

            if (condition.Mode)
            {
                command += "MODE, ";
            }

            if (condition.Range)
            {
                command += "RANGE, ";
            }

            command += $"ID ... FROM ... WHERE datefrom = {condition.DateFrom} AND dateto = {condition.DateTo}...";
            DataTable table = dBConnection.readDataSql(command);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                WeatherData weatherdata = new WeatherData();
                weatherdata.ID = Convert.ToInt32(table.Rows[i]["ID"]);
                //station.Number = table.Rows[i]["NUMBER"].ToString();

                list_weatherdata.Add(weatherdata);
            }
        }

    }
}
