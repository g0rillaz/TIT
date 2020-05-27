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
            Station station = Statics.list_stations.Find(x => x.ID == 13);


            Condition condition = new Condition();
            condition.Source = "NOAA";
            condition.Intervall = "y";
            condition.OrderBy = "date";
            condition.OrderDirection = true;
            condition.DateFrom = new DateTime(1990, 1, 1);
            condition.DateTo = new DateTime(1991, 12, 31);
            condition.Deviation = true;
            condition.Mean = true;
            condition.Max = true;
            condition.Min = true;
            //condition.Mode = false;
            condition.Range = true;
            condition.Raw = true;
            condition.Mean = true;

            Statics.getWeatherData(country, station, condition);
        }
    }
}
