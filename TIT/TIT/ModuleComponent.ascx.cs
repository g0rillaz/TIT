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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //loadInfo();
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
            Statics.getListStationsByCountry(IsoCode, "meteo");

            Station.DataSource = Statics.list_stations;
            Station.DataTextField = "Name";
            Station.DataValueField = "Number";
            Station.DataBind();
        }


        protected void Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshStations();
        }

        protected void getDataButton_Click(object sender, EventArgs e)
        {

            TITLib.Condition condition = new Condition();

            condition.Raw = RawTemperature.Checked;
            condition.Mean = MeanTemperature.Checked;
            condition.Median = MedianTemperature.Checked;
            condition.Min = MinTemperature.Checked;
            condition.Max = MaxTemperature.Checked;
            condition.Deviation = StandardDeviation.Checked;
            condition.Mode = ModeTemperature.Checked;
            condition.Range = RangeTemperature.Checked;
            // condition.Intervall = Interval.SelectedValue;
            condition.Intervall = Interval.SelectedValue;


            
            Console.WriteLine(Convert.ToString(FromDate.Text.GetType().Name));

            DateTime fromDate = Convert.ToDateTime(FromDate.Text); // EndZeitpunkt
            DateTime toDate = Convert.ToDateTime(ToDate.Text); // Startzeitpunkt
            TimeSpan SpanDateInput = toDate - fromDate; // Timespanne            

            System.Diagnostics.Debug.WriteLine("das ist unser Debugger");
            System.Diagnostics.Debug.WriteLine(Convert.ToString(fromDate), Convert.ToString(toDate));
            System.Diagnostics.Debug.WriteLine("Der Timesppan beträgt: "+ Convert.ToString(SpanDateInput.Days));           


            for (int i = 0; i < SpanDateInput.Days; i++)
            {
               // Response.Cookies["WeatherData"][SpanDateInput[]] = "John Doe";
                
                System.Diagnostics.Debug.WriteLine(i);
            }



            Response.Cookies["user"]["Date"] = "05.05.2018";
            Response.Cookies["user"]["Temp"] = "15";




            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "GetData()", true);

            // Anyone can call this.

            var test = Table.GridLines;


            //TITLib.Country country = Statics.list_country.Find(x => x.IsoCode == Region.SelectedValue);
            //TITLib.Station station = Statics.list_stations.Find(x => x.Number == Station.SelectedValue);

           // Statics.getWeatherData(country, station, condition);
        }

        public void ChartSize(int spanday)

        {
            return;
        }

        protected void Table_Load(object sender, EventArgs e)
        {
            Console.WriteLine("EDDW");
        }

    }
}