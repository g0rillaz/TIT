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
        public static string connectionstring = "Data Source=s-mssql2019.it.gla; Initial Catalog=ProjectTIT; User id=IN18a; Password=IN18BSDGG; Connection Timeout=0;";
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
        public static List<WeatherData> getWeatherData(Country country, Station station, Condition condition)
        {          
            List<WeatherData> list_weatherdata = new List<WeatherData>();
            dBConnection = new DBConnection();
            dBConnection.createConnection(connectionstring);

            string command = "dbo.SP_DATA_NOAA";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            sqlParameters.Add(new SqlParameter("INTERVALL", condition.Intervall));
            sqlParameters.Add(new SqlParameter("USE_RAW", '0'));
            sqlParameters.Add(new SqlParameter("SHW_MEAN", Convert.ToInt32(condition.Mean)));
            sqlParameters.Add(new SqlParameter("SHW_MEDIAN", Convert.ToInt32(condition.Median)));
            sqlParameters.Add(new SqlParameter("SHW_MIN", Convert.ToInt32(condition.Min)));
            sqlParameters.Add(new SqlParameter("SHW_MAX", Convert.ToInt32(condition.Max)));
            sqlParameters.Add(new SqlParameter("SHW_SDEV", Convert.ToInt32(condition.Deviation)));
            sqlParameters.Add(new SqlParameter("SHW_MODE", Convert.ToInt32(condition.Mode)));
            sqlParameters.Add(new SqlParameter("SHW_RANGE", Convert.ToInt32(condition.Range)));
            sqlParameters.Add(new SqlParameter("WH_DATE_BIT", '1'));
            sqlParameters.Add(new SqlParameter("WH_DATE_BEGIN", condition.DateFrom));
            sqlParameters.Add(new SqlParameter("WH_DATE_END", condition.DateTo));
            sqlParameters.Add(new SqlParameter("WH_COUNTRY_BIT", '1'));
            sqlParameters.Add(new SqlParameter("WH_COUNTRY", country.ID));
            sqlParameters.Add(new SqlParameter("WH_STATION_BIT", 1));
            sqlParameters.Add(new SqlParameter("WH_STATION", station.ID));
            sqlParameters.Add(new SqlParameter("ORDERCOLUMN", condition.OrderBy));
            sqlParameters.Add(new SqlParameter("ORDERDESC", condition.OrderDirection));

            DataTable table = dBConnection.readDataWithStoredProcedure(command, sqlParameters);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                WeatherData weatherdata = new WeatherData();
                weatherdata.ID = Convert.ToInt32(table.Rows[i]["ID"]);
                weatherdata.CountryName = table.Rows[i]["c.[Name]"].ToString();
                weatherdata.StationName = table.Rows[i]["s.[Name]"].ToString();
                weatherdata.StationNumber = table.Rows[i]["s.[Number]"].ToString();
                weatherdata.Date = Convert.ToDateTime(table.Rows[i]["Date"]);
                weatherdata.Mean = Convert.ToDecimal(table.Rows[i]["Mean"]);
                weatherdata.Median = Convert.ToDecimal(table.Rows[i]["Median"]);
                weatherdata.Min = Convert.ToDecimal(table.Rows[i]["Min"]);
                weatherdata.Max = Convert.ToDecimal(table.Rows[i]["Max"]);
                weatherdata.Deviation = Convert.ToDecimal(table.Rows[i]["Deviation"]);
                weatherdata.Mode = Convert.ToDecimal(table.Rows[i]["Mode"]);
                weatherdata.Range = Convert.ToDecimal(table.Rows[i]["Range"]);

                list_weatherdata.Add(weatherdata);
            }

            return list_weatherdata;
        }

    }
}
