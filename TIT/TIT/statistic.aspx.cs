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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
            //dropdown_station.DataSource = list_country;
            //dropdown_station.DataTextField = "Name";
            //dropdown_station.DataValueField = "IsoCode";
            //dropdown_station.DataBind();

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
            string IsoCode = dropdown_country.SelectedItem.Value;
            Statics.getListStationsByCountry(IsoCode, "meteo");

            dropdown_station.DataSource = Statics.list_stations;
            dropdown_station.DataTextField = "Name";
            dropdown_station.DataValueField = "Number";
            dropdown_station.DataBind();


        }

        private void getData()
        {
            string countryIcoCode = Region.SelectedValue;
            string stationID = dropdown_station.SelectedValue;
            string sortby = dropdown_sort.SelectedValue;
            DateTime.TryParse(datepicker_from.Value, out DateTime datefrom);
            DateTime.TryParse(datepicker_to.Value, out DateTime dateto);
            bool option1 = checkbox_option1.Checked;
            bool option2 = checkbox_option2.Checked;
            bool option3 = checkbox_option3.Checked;



            Debug.WriteLine($"{countryIcoCode}, {stationID}, {sortby}, {datefrom.ToShortDateString()}, {dateto.ToShortDateString()}, {option1}, {option2}, {option3}");
        }

        protected void button_getData_Click(object sender, EventArgs e)
        {
            getData();
        }

        protected void Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshStations();
        }

        protected void getDataButton_Click(object sender, EventArgs e)
        {

            SelectedOptions selectedOptions = new SelectedOptions(
                Modulname.Text, 
                FromDate.Text,
                ToDate.Text,
                Region.Text,
                Station.Text,
                Interval.Text,
                OrderedBy.Text,
                RawTemperature.Checked,
                MeanTemperature.Checked,
                MedianTemperature.Checked,
                MinTemperature.Checked,
                MaxTemperature.Checked,
                StandardDeviation.Checked,
                ModeTemperature.Checked,
                RangeTemperature.Checked
                );



            Console.WriteLine(selectedOptions);
        }
    }
}