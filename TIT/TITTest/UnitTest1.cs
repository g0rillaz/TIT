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
            Country country = Statics.list_country[15];

            Statics.getListStationsByCountry(country.IsoCode, "noaa");
            Station station = Statics.list_stations[5];


            Condition condition = new Condition();
            condition.DateFrom = new DateTime(2010, 1, 1);
            condition.DateTo = new DateTime(2010, 1, 7);
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
