using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TITLib;

namespace TIT
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            createControl();

            if (!IsPostBack)
            {
                loadInfo();
            }
        }

        private void createControl()
        {
            HtmlControl control = new HtmlGenericControl();
            control = baum;


        }

        private Feature createPointFeature(Station station)
        {
            Position position = new Position(station.Latitude, station.Longitude);
            Point point = new Point(position);

            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("name", station.Name);
            properties.Add("country", station.CountryName);
            properties.Add("latitude", position.Latitude);
            properties.Add("longitude", position.Longitude);
            //properties.Add("altitude", position.Altitude);

            Feature feature = new Feature(point, properties);

            return feature;
        }

        private Feature createPolygonFeature(List<Station> list_station, string areaname)
        {
            List<Position> list_position = new List<Position>();
            foreach (Station station in list_station)
            {
                Position position = new Position(station.Latitude, station.Longitude);
                list_position.Add(position);
            }

            LineString lineString = new LineString(list_position);
            List<LineString> list_linestring = new List<LineString>();
            list_linestring.Add(lineString);

            Polygon polygon = new Polygon(list_linestring);

            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("name", areaname);

            Feature feature = new Feature(polygon, properties);
            return feature;
        }

        private void createGeoJson()
        {

            Statics.getListStationsAllByDatasource("meteo");
            FeatureCollection collection = new FeatureCollection();
            foreach (Station station in Statics.list_stations)
            {
                if (Decimal.TryParse(station.Latitude, out decimal latitude) && Decimal.TryParse(station.Longitude, out decimal longitude))
                {

                    station.Latitude = Convert.ToString(latitude, System.Globalization.CultureInfo.InvariantCulture);
                    station.Longitude = Convert.ToString(longitude, System.Globalization.CultureInfo.InvariantCulture);

                }
                else
                {
                    station.Latitude = "0";
                    station.Longitude = "0";
                }

                collection.Features.Add(createPointFeature(station));
            }

            //collection.Features.Add(createPolygonFeature(list_station, "Area"));

            //LineString line = new LineString(new[] { position, position2 });

            string geojson = JsonConvert.SerializeObject(collection);
            createCookie("GeoJson", geojson);

            string path = @"~\App_Data\GeoData.geojson";
            File.WriteAllText(Server.MapPath(path), geojson);
            Debug.WriteLine(geojson);
        }

        private void createCookie(string name, string input)
        {
            Response.Cookies[name].Value = input;
            Response.Cookies[name].Expires = DateTime.Now.AddMinutes(5);
        }


        private void loadInfo()
        {
            Statics.getListCountrys();

            gridview_main.DataSource = Statics.list_country.OrderBy(x => x.Name);
            gridview_main.DataBind();

        }

        protected void button_createGeoJson_Click(object sender, EventArgs e)
        {
            createGeoJson();
        }
    }
}