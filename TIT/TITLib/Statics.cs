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

            string command = "dbo.SP_DATA_ACCESS";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();


            SqlParameter parameter0 = new SqlParameter();
            parameter0.ParameterName = "USE_RAW";
            parameter0.SqlDbType = SqlDbType.Bit;
            parameter0.Direction = ParameterDirection.Input;

            if (condition.Source == "NOAA")
            {
                parameter0.Value = 0;
            } else
            {
                parameter0.Value = 1;
            }


            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "INTERVALL";
            parameter1.Value = $"{condition.Intervall}";
            parameter1.SqlDbType = SqlDbType.VarChar;
            parameter1.Direction = ParameterDirection.Input;

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "SHW_MEAN";
            parameter2.Value = Convert.ToInt32(condition.Mean);
            parameter2.SqlDbType = SqlDbType.Bit;
            parameter2.Direction = ParameterDirection.Input;

            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "SHW_MEDIAN";
            parameter3.Value = Convert.ToInt32(condition.Median);
            parameter3.SqlDbType = SqlDbType.Bit;
            parameter3.Direction = ParameterDirection.Input;

            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "SHW_MIN";
            parameter4.Value = Convert.ToInt32(condition.Min);
            parameter4.SqlDbType = SqlDbType.Bit;
            parameter4.Direction = ParameterDirection.Input;

            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "SHW_MAX";
            parameter5.Value = Convert.ToInt32(condition.Max);
            parameter5.SqlDbType = SqlDbType.Bit;
            parameter5.Direction = ParameterDirection.Input;

            SqlParameter parameter6 = new SqlParameter();
            parameter6.ParameterName = "SHW_SDEV";
            parameter6.Value = Convert.ToInt32(condition.Deviation);
            parameter6.SqlDbType = SqlDbType.Bit;
            parameter6.Direction = ParameterDirection.Input;

            //SqlParameter parameter7 = new SqlParameter();
            //parameter7.ParameterName = "SHW_MODE";
            //parameter7.Value = Convert.ToInt32(condition.Mode);
            //parameter7.SqlDbType = SqlDbType.Bit;
            //parameter7.Direction = ParameterDirection.Input;
             
            SqlParameter parameter8 = new SqlParameter();
            parameter8.ParameterName = "SHW_RANGE";
            parameter8.Value = Convert.ToInt32(condition.Range);
            parameter8.SqlDbType = SqlDbType.Bit;
            parameter8.Direction = ParameterDirection.Input;

            //SqlParameter parameter9 = new SqlParameter();
            //parameter9.ParameterName = "WH_DATE_BIT";
            //parameter9.Value = 1;
            //parameter9.SqlDbType = SqlDbType.Bit;
            //parameter9.Direction = ParameterDirection.Input;

            SqlParameter parameter10 = new SqlParameter();
            parameter10.ParameterName = "WH_DATE_BEGIN";
            parameter10.Value = condition.DateFrom;
            parameter10.SqlDbType = SqlDbType.Date;
            parameter10.Direction = ParameterDirection.Input;

            SqlParameter parameter11 = new SqlParameter();
            parameter11.ParameterName = "WH_DATE_END";
            parameter11.Value = condition.DateTo;
            parameter11.SqlDbType = SqlDbType.Date;
            parameter11.Direction = ParameterDirection.Input;

            SqlParameter parameter12 = new SqlParameter();
            parameter12.ParameterName = "WH_COUNTRY_BIT";
            parameter12.Value = 1;
            parameter12.SqlDbType = SqlDbType.Bit;
            parameter12.Direction = ParameterDirection.Input;

            SqlParameter parameter13 = new SqlParameter();
            parameter13.ParameterName = "WH_COUNTRY";
            parameter13.Value = country.ID;
            parameter13.SqlDbType = SqlDbType.Int;
            parameter13.Direction = ParameterDirection.Input;

            SqlParameter parameter14 = new SqlParameter();
            parameter14.ParameterName = "WH_STATION_BIT";
            parameter14.Value = 1;
            parameter14.SqlDbType = SqlDbType.Bit;
            parameter14.Direction = ParameterDirection.Input;

            SqlParameter parameter15 = new SqlParameter();
            parameter15.ParameterName = "WH_STATION";
            parameter15.Value = station.ID;
            parameter15.SqlDbType = SqlDbType.Int;
            parameter15.Direction = ParameterDirection.Input;

            SqlParameter parameter16 = new SqlParameter();
            parameter16.ParameterName = "ORDERCOLUMN";
            parameter16.Value = $"{condition.OrderBy}";
            parameter16.SqlDbType = SqlDbType.VarChar;
            parameter16.Direction = ParameterDirection.Input;

            SqlParameter parameter17 = new SqlParameter();
            parameter17.ParameterName = "ORDERDESC";
            parameter17.Value = Convert.ToInt32(condition.OrderDirection);
            parameter17.SqlDbType = SqlDbType.Bit;
            parameter17.Direction = ParameterDirection.Input;


            sqlParameters.Add(parameter0);
            sqlParameters.Add(parameter1);
            sqlParameters.Add(parameter2);
            sqlParameters.Add(parameter3);
            sqlParameters.Add(parameter4);
            sqlParameters.Add(parameter5);
            sqlParameters.Add(parameter6);
            //sqlParameters.Add(parameter7);
            sqlParameters.Add(parameter8);
            //sqlParameters.Add(parameter9);
            sqlParameters.Add(parameter10);
            sqlParameters.Add(parameter11);
            sqlParameters.Add(parameter12);
            sqlParameters.Add(parameter13);
            sqlParameters.Add(parameter14);
            sqlParameters.Add(parameter15);
            sqlParameters.Add(parameter16);
            sqlParameters.Add(parameter17);

            DataTable table = dBConnection.readDataWithStoredProcedure(command, sqlParameters);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                WeatherData weatherdata = new WeatherData();
                //weatherdata.ID = Convert.ToInt32(table.Rows[i]["ID"]);
                weatherdata.CountryName = table.Rows[i]["Country"].ToString();
                weatherdata.StationName = table.Rows[i]["Station"].ToString();
                //weatherdata.StationNumber = table.Rows[i]["s.[Number]"].ToString();
                weatherdata.Date = table.Rows[i]["Date"].ToString();
                weatherdata.Mean = Convert.ToDecimal(table.Rows[i]["Mean"]);
                weatherdata.Median = Convert.ToDecimal(table.Rows[i]["Median"]);
                weatherdata.Min = Convert.ToDecimal(table.Rows[i]["Min"]);
                weatherdata.Max = Convert.ToDecimal(table.Rows[i]["Max"]);
                weatherdata.Deviation = Convert.ToDecimal(table.Rows[i]["SDev"]);
                //weatherdata.Mode = Convert.ToDecimal(table.Rows[i]["Mode"]);
                weatherdata.Range = Convert.ToDecimal(table.Rows[i]["Range"]);

                list_weatherdata.Add(weatherdata);
            }

            return list_weatherdata;
        }

    }
}
