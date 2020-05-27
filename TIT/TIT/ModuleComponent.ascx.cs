using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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

            //ObservableCollection<Country> oc_country = new ObservableCollection<Country>();

            Region.DataSource = Statics.list_country;
            Region.DataTextField = "Name";
            Region.DataValueField = "IsoCode";
            Region.DataBind();

            //Source.DataSource = Statics.list_country;
            //Source.DataTextField = "Name";
            //Source.DataValueField = "IsoCode";
            //Source.DataBind();

            //dropdown_sort.DataSource = list_country;
            //dropdown_sort.DataTextField = "Name";
            //dropdown_sort.DataValueField = "IsoCode";
            //dropdown_sort.DataBind();
            //Test End

            //gridview_main.DataSource = Statics.list_country.OrderBy(x => x.ID);
            //gridview_main.DataBind();
        }

        private void refreshStations()
        {

            string IsoCode = Region.SelectedItem.Value;
            Statics.getListStationsByCountry(IsoCode, Source.SelectedValue);

            Station.DataSource = Statics.list_stations;
            Station.DataTextField = "Name";
            Station.DataValueField = "ID";
            Station.DataBind();
        }


        protected void Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshStations();
        }

        protected void getDataButton_Click(object sender, EventArgs e)
        {

            TITLib.Condition condition = new Condition();

            //condition.Raw = RawTemperature.Checked;
            condition.Source = Source.SelectedValue;
            condition.Mean = MeanTemperature.Checked;
            condition.Median = MedianTemperature.Checked;
            condition.Min = MinTemperature.Checked;
            condition.Max = MaxTemperature.Checked;
            condition.Deviation = StandardDeviation.Checked;
            //condition.Mode = ModeTemperature.Checked;
            condition.Range = RangeTemperature.Checked;
            condition.DateFrom = Convert.ToDateTime(FromDate.Text);
            condition.DateTo = Convert.ToDateTime(ToDate.Text);
            condition.Intervall = Interval.SelectedValue;
            condition.OrderBy = OrderedBy.SelectedValue;
            condition.OrderDirection = false;


            var test = FromDate.Text;


            TITLib.Country country = Statics.list_country.Find(x => x.IsoCode == Region.SelectedValue);
            TITLib.Station station = Statics.list_stations.Find(x => x.ID == Convert.ToInt32(Station.SelectedValue));

            //List<WeatherData> list_weatherdata = Statics.getWeatherData(country, station, condition);
            List<WeatherData> test_list_weatherdata = Statics.getWeatherData(country, station, condition);


            //gridview_main.DataSource = list_weatherdata;
            gridview_main.DataSource = test_list_weatherdata;

            gridview_main.DataBind();

        }

        protected void Table_Load(object sender, EventArgs e)
        {
            Console.WriteLine("EDDW");
        }

        protected void removeModule_Click(object sender, EventArgs e)
        {
            //string moduleCmtId = this.ID;
            //Control myUserControl = (this.Parent).FindControl(moduleCmtId);


            statistic stat = this.Page as statistic;
            stat.Count -= 1;
            this.Parent.Controls.Remove(this);
        }
    }
}