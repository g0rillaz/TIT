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
using System.Web.UI.WebControls;
using TITLib;

namespace TIT
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Feature createPointFeature(Station station)
        {
            Position position = new Position(station.Latitude, station.Longitude);
            Point point = new Point(position);

            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("name", station.Name);
            properties.Add("country", station.Country);
            properties.Add("latitude", position.Latitude);
            properties.Add("longitude", position.Longitude);
            //properties.Add("altitude", position.Altitude);

            Feature feature = new Feature(point, properties);

            return feature;
        }

        private Feature createPolygonFeature(List<Station> list_station, string areaname)
        {
            List<Position> list_position = new List<Position>();
            foreach(Station station in list_station)
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

            List<Station> list_station = new List<Station>();
            list_station.Add(new Station(1, "Bremerhaven", "Deutschland", "53.55021", "8.57673"));
            list_station.Add(new Station(2, "Limburg", "Deutschland", "50.383", "8.067"));
            list_station.Add(new Station(3, "Berlin", "Deutschland", "52.52437", "13.41053"));
            list_station.Add(new Station(4, "Otterndorf", "Deutschland", "53.817", "8.900"));
            list_station.Add(new Station(5, "Cuxhaven", "Deutschland", "53.867", "8.700"));
            list_station.Add(new Station(6, "Bremerhaven", "Deutschland", "53.55021", "8.57673"));

            FeatureCollection collection = new FeatureCollection();
            foreach (Station station in list_station)
            {
                collection.Features.Add(createPointFeature(station));
            }

            collection.Features.Add(createPolygonFeature(list_station, "Area"));

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

        protected void button_createGeoJson_Click(object sender, EventArgs e)
        {
            createGeoJson();
        }
    }
}