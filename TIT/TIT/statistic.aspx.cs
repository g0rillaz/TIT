using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TITLib;

namespace TIT
{
    public partial class statistic : System.Web.UI.Page
    {
        private Control ucUserControl;
        private int counter = 0;

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

            //Test Start

            //dropdown_sort.DataSource = list_country;
            //dropdown_sort.DataTextField = "Name";
            //dropdown_sort.DataValueField = "IsoCode";
            //dropdown_sort.DataBind();
            //Test End

            gridview_main.DataSource = Statics.list_country.OrderBy(x => x.ID);
            gridview_main.DataBind();
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

        //private void getData()
        //{
        //    string countryIcoCode = Region.SelectedValue;
        //    string stationID = dropdown_station.SelectedValue;
        //    string sortby = dropdown_sort.SelectedValue;
        //    DateTime.TryParse(datepicker_from.Value, out DateTime datefrom);
        //    DateTime.TryParse(datepicker_to.Value, out DateTime dateto);
        //    bool option1 = checkbox_option1.Checked;
        //    bool option2 = checkbox_option2.Checked;
        //    bool option3 = checkbox_option3.Checked;



        //    Debug.WriteLine($"{countryIcoCode}, {stationID}, {sortby}, {datefrom.ToShortDateString()}, {dateto.ToShortDateString()}, {option1}, {option2}, {option3}");
        //}

        //protected void button_getData_Click(object sender, EventArgs e)
        //{
        //    getData();
        //}

        protected void Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshStations();
        }

        protected void getDataButton_Click(object sender, EventArgs e)
        {

            //SelectedOptions selectedOptions = new SelectedOptions(
            //    Modulname.Text, 
            //    FromDate.Text,
            //    ToDate.Text,
            //    Region.Text,
            //    Station.Text,
            //    Interval.Text,
            //    OrderedBy.Text,

            //    );

            Condition condition = new Condition();

            condition.Raw = RawTemperature.Checked;
            condition.Mean = MeanTemperature.Checked;
            condition.Median = MedianTemperature.Checked;
            condition.Min = MinTemperature.Checked;
            condition.Max = MaxTemperature.Checked;
            condition.Deviation = StandardDeviation.Checked;
            condition.Mode = ModeTemperature.Checked;
            condition.Range = RangeTemperature.Checked;

            Country country = Statics.list_country.Find(x => x.IsoCode == Region.SelectedValue);
            TITLib.Station station = Statics.list_stations.Find(x => x.Number == Station.SelectedValue);



            Statics.getWeatherData(country, station, condition);



            //Console.WriteLine(selectedOptions);
        }

        protected void createNewModule_Click(object sender, EventArgs e)
        {

            Control control = new Control();
            ModuleComponent component = new ModuleComponent();
            control = component as Control;
            
            dwd.Controls.Add(control);

            Console.WriteLine("test");
          
            //ucUserControl = (Control)Page.LoadControl("ModuleComponent.ascx");
            //dwd.Controls.Add(ucUserControl);
            //dwd.InnerHtml = ucUserControl;
            //MyPlaceholder.Controls.Add(new Literal() { Text = "<div>some markup " + counter + "</div>" });
            //LiteralControl lit = new LiteralControl("ModuleComponent.ascx");
            //Page.Controls.Add(lit);
        }
    }
}