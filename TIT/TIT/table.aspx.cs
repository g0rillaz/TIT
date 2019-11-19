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
    public partial class table : System.Web.UI.Page
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
            ObservableCollection<Country> list_country = new ObservableCollection<Country>();

            Country country = new Country();
            country.ID = 1;
            country.IsoCode = "DE";
            country.Name = "Deutschland";
            list_country.Add(country);

            Country country2 = new Country();
            country2.ID = 2;
            country2.IsoCode = "EN";
            country2.Name = "England";
            list_country.Add(country2);

            dropdown_country.DataSource = list_country;
            dropdown_country.DataTextField = "Name";
            dropdown_country.DataValueField = "IsoCode";
            dropdown_country.DataBind();

            //Test Start
            dropdown_station.DataSource = list_country;
            dropdown_station.DataTextField = "Name";
            dropdown_station.DataValueField = "IsoCode";
            dropdown_station.DataBind();

            dropdown_sort.DataSource = list_country;
            dropdown_sort.DataTextField = "Name";
            dropdown_sort.DataValueField = "IsoCode";
            dropdown_sort.DataBind();
            //Test End

            gridview_main.DataSource = list_country.OrderBy(x => x.ID);
            gridview_main.DataBind();
        }

        private void refreshStations()
        {
            string IsoCode = dropdown_country.SelectedItem.Value;
        }

        private void getData()
        {
            string countryIcoCode = dropdown_country.SelectedValue;
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

        protected void dropdown_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshStations();
        }
    }
}