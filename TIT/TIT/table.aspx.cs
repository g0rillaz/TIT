using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        }

        private void refreshStations()
        {
            string IsoCode = dropdown_country.SelectedItem.Value;
        }

        private void getData()
        {

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