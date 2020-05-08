using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TITLib;

namespace TITTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Statics.getListCountrys();
            Country country = Statics.list_country[164];

            Statics.getListStationsByCountry(country.IsoCode, "noaa");
            Station station = Statics.list_stations[12];


            Condition condition = new Condition();
            condition.Source = "NOAA";
            condition.Intervall = "'y'";
            condition.OrderBy = "mean";
            condition.OrderDirection = true;
            condition.DateFrom = new DateTime(1990, 1, 1);
            condition.DateTo = new DateTime(1990, 12, 31);
            condition.Deviation = false;
            condition.Max = false;
            condition.Min = false;
            condition.Mode = false;
            condition.Range = false;
            condition.Raw = false;
            condition.Mean = true;

            Statics.getWeatherData(country, station, condition);
        }
    }
}
