using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using TITLib;



namespace TIT
{
    public partial class ModuleComponent : System.Web.UI.UserControl
    {
        static class Butter
        {
            public static int counter = 1;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                loadInfo();
            }

        }

        private void loadInfo()
        {
            Statics.getListCountrys();

            Region.DataSource = Statics.list_country.OrderBy(x => x.Name);
            Region.DataTextField = "Name";
            Region.DataValueField = "IsoCode";
            Region.DataBind();
        }

        private void refreshStations()
        {

            string IsoCode = Region.SelectedItem.Value;
            Statics.getListStationsByCountry(IsoCode, "NOAA");

            Station.DataSource = Statics.list_stations.OrderBy(o => o.Name);
            Station.DataTextField = "Name";
            Station.DataValueField = "ID";
            Station.DataBind();
        }


        protected void Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshStations();
        }

        /// <summary>
        /// Führt eine Datenbankabfrage aus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void getDataButton_Click(object sender, EventArgs e)
        {
            TITLib.Condition condition = new Condition();
            //condition.Raw = RawTemperature.Checked;
            condition.Source = "NOAA";
            condition.Mean = true;
            condition.Median = true;
            condition.Min = true;
            condition.Max = true;
            condition.Deviation = true;
            //condition.Mode = ModeTemperature.Checked;
            condition.Range = true;
            condition.DateFrom = Convert.ToDateTime(FromDate.Text);
            condition.DateTo = Convert.ToDateTime(ToDate.Text);
            condition.Intervall = Interval.SelectedValue;
            condition.OrderBy = "date";
            condition.OrderDirection = false;

            TITLib.Country country = Statics.list_country.Find(x => x.IsoCode == Region.SelectedValue);
            TITLib.Station station = Statics.list_stations.Find(x => x.ID == Convert.ToInt32(Station.SelectedValue));

            Statics.list_weatherdata = Statics.getWeatherData(country, station, condition);
            gridview_main.DataSource = Statics.list_weatherdata.OrderBy(x => x.ID);
            gridview_main.DataBind();

            sendDataToChart(Statics.list_weatherdata, condition);
        }
        public void ChartSize(int spanday)

        {
            return;
        }

        /// <summary>
        /// Erstellt ein Cookie mit den Daten
        /// </summary>
        /// <param name="list_weatherdata"></param>
        /// <param name="condition"></param>
        private void sendDataToChart(List<WeatherData> list_weatherdata, Condition condition)
        {
            Series seriesMin = new Series("WeatherDataMin");
            Series seriesMean = new Series("WeatherDataMean");
            Series seriesMax = new Series("WeatherDataMax");
            Series seriesMedian = new Series("WeatherDataMedian");
            Series seriesDeviation = new Series("WeatherDataDeviation");
            Series seriesRange = new Series("WeatherDataRange");

            Chart_WeatherData.Series.Add(seriesMin);
            Chart_WeatherData.Series.Add(seriesMean);
            Chart_WeatherData.Series.Add(seriesMax);
            Chart_WeatherData.Series.Add(seriesMedian);
            Chart_WeatherData.Series.Add(seriesDeviation);
            Chart_WeatherData.Series.Add(seriesRange);

            Chart_WeatherData.DataSource = list_weatherdata;
            Chart_WeatherData.Series["WeatherDataMin"].XValueMember = "Date";
            Chart_WeatherData.Series["WeatherDataMin"].YValueMembers = "Min";
            Chart_WeatherData.Series["WeatherDataMin"].ChartType = SeriesChartType.Line;
            Chart_WeatherData.Series["WeatherDataMin"].IsVisibleInLegend = true;

            Chart_WeatherData.Series["WeatherDataMean"].XValueMember = "Date";
            Chart_WeatherData.Series["WeatherDataMean"].YValueMembers = "Mean";
            Chart_WeatherData.Series["WeatherDataMean"].ChartType = SeriesChartType.Line;
            Chart_WeatherData.Series["WeatherDataMean"].IsVisibleInLegend = true;

            Chart_WeatherData.Series["WeatherDataMax"].XValueMember = "Date";
            Chart_WeatherData.Series["WeatherDataMax"].YValueMembers = "Max";
            Chart_WeatherData.Series["WeatherDataMax"].ChartType = SeriesChartType.Line;
            Chart_WeatherData.Series["WeatherDataMax"].IsVisibleInLegend = true;

            Chart_WeatherData.Series["WeatherDataMedian"].XValueMember = "Date";
            Chart_WeatherData.Series["WeatherDataMedian"].YValueMembers = "Median";
            Chart_WeatherData.Series["WeatherDataMedian"].ChartType = SeriesChartType.Line;
            Chart_WeatherData.Series["WeatherDataMedian"].IsVisibleInLegend = true;

            Chart_WeatherData.Series["WeatherDataDeviation"].XValueMember = "Date";
            Chart_WeatherData.Series["WeatherDataDeviation"].YValueMembers = "Deviation";
            Chart_WeatherData.Series["WeatherDataDeviation"].ChartType = SeriesChartType.Line;
            Chart_WeatherData.Series["WeatherDataDeviation"].IsVisibleInLegend = true;

            Chart_WeatherData.Series["WeatherDataRange"].XValueMember = "Date";
            Chart_WeatherData.Series["WeatherDataRange"].YValueMembers = "Range";
            Chart_WeatherData.Series["WeatherDataRange"].ChartType = SeriesChartType.Line;
            Chart_WeatherData.Series["WeatherDataRange"].IsVisibleInLegend = true;

            Chart_WeatherData.Legends.Add(new Legend());

            Chart_WeatherData.DataBind();

            //foreach (WeatherData weatherdata in Statics.list_weatherdata)
            //{
            //    DataPoint dp = new DataPoint(Convert.ToDouble(weatherdata.Min), Convert.ToDouble(weatherdata.ID));
            //    series.Points.Add(dp);
            //}

            //Chart_WeatherData.Series.Add("WeatherDataMin");
            //Chart_WeatherData.DataBind();



            //Console.WriteLine(Convert.ToString(FromDate.Text.GetType().Name));

            //DateTime fromDate = Convert.ToDateTime(condition.DateFrom); // EndZeitpunkt
            //DateTime toDate = Convert.ToDateTime(condition.DateTo); // Startzeitpunkt
            //TimeSpan SpanDateInput = toDate - fromDate; // Timespanne            

            //System.Diagnostics.Debug.WriteLine("das ist unser Debugger");
            //System.Diagnostics.Debug.WriteLine(Convert.ToString(fromDate), Convert.ToString(toDate));
            //System.Diagnostics.Debug.WriteLine("Der Timesppan beträgt: " + Convert.ToString(SpanDateInput.Days));

            //string json = JsonConvert.SerializeObject(list_weatherdata);
            //Response.Cookies["WeatherData"]["list_weatherdata"] = json;
        }


        protected void removeModule_Click(object sender, EventArgs e)
        {
            //string moduleCmtId = this.ID;
            //Control myUserControl = (this.Parent).FindControl(moduleCmtId);


            statistic stat = this.Page as statistic;
            stat.Count -= 1;
            this.Parent.Controls.Remove(this);
        }

        /// <summary>
        /// Ordnet die Daten
        /// </summary>
        /// <param name="ordertype"></param>
        /// <param name="orderdirection"></param>
        private void Order(string ordertype, string orderdirection)
        {

            object datasource = gridview_main.DataSource;

            if (Statics.list_weatherdata != null)
            {
                List<WeatherData> list_weatherdata = Statics.list_weatherdata;

                if (ordertype == "date")
                {
                    if (orderdirection == "auf")
                    {
                        gridview_main.DataSource = list_weatherdata.OrderBy(x => x.ID);
                    }
                    else
                    {
                        gridview_main.DataSource = list_weatherdata.OrderByDescending(x => x.ID);
                    }

                }

                if (ordertype == "country")
                {
                    if (orderdirection == "auf")
                    {
                        gridview_main.DataSource = list_weatherdata.OrderBy(x => x.CountryName);
                    }
                    else
                    {
                        gridview_main.DataSource = list_weatherdata.OrderByDescending(x => x.CountryName);
                    }
                }

                if (ordertype == "station")
                {
                    if (orderdirection == "auf")
                    {
                        gridview_main.DataSource = list_weatherdata.OrderBy(x => x.StationName);
                    }
                    else
                    {
                        gridview_main.DataSource = list_weatherdata.OrderByDescending(x => x.StationName);
                    }
                }

                if (ordertype == "mean")
                {
                    if (orderdirection == "auf")
                    {
                        gridview_main.DataSource = list_weatherdata.OrderBy(x => x.Mean);
                    }
                    else
                    {
                        gridview_main.DataSource = list_weatherdata.OrderByDescending(x => x.Mean);
                    }
                }

                if (ordertype == "min")
                {
                    if (orderdirection == "auf")
                    {
                        gridview_main.DataSource = list_weatherdata.OrderBy(x => x.Min);
                    }
                    else
                    {
                        gridview_main.DataSource = list_weatherdata.OrderByDescending(x => x.Min);
                    }
                }

                if (ordertype == "max")
                {
                    if (orderdirection == "auf")
                    {
                        gridview_main.DataSource = list_weatherdata.OrderBy(x => x.Max);
                    }
                    else
                    {
                        gridview_main.DataSource = list_weatherdata.OrderByDescending(x => x.Max);
                    }
                }

                if (ordertype == "deviation")
                {
                    if (orderdirection == "auf")
                    {
                        gridview_main.DataSource = list_weatherdata.OrderBy(x => x.Deviation);
                    }
                    else
                    {
                        gridview_main.DataSource = list_weatherdata.OrderByDescending(x => x.Deviation);
                    }
                }

                if (ordertype == "median")
                {
                    if (orderdirection == "auf")
                    {
                        gridview_main.DataSource = list_weatherdata.OrderBy(x => x.Median);
                    }
                    else
                    {
                        gridview_main.DataSource = list_weatherdata.OrderByDescending(x => x.Median);
                    }
                }

                if (ordertype == "range")
                {
                    if (orderdirection == "auf")
                    {
                        gridview_main.DataSource = list_weatherdata.OrderBy(x => x.Range);
                    }
                    else
                    {
                        gridview_main.DataSource = list_weatherdata.OrderByDescending(x => x.Range);
                    }
                }

                gridview_main.DataBind();
            }
        }

        /// <summary>
        /// Führt die Methode Order aus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void button_order_Click(object sender, EventArgs e)
        {
            Order(OrderedBy.SelectedValue, Direction.SelectedValue);
        }
    }
}