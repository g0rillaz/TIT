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

        private void createGeoJson()
        {
            Position position = new Position(53.55021, 8.57673);
            Point point = new Point(position);
           
            Position position2 = new Position(52.52437, 13.41053);
            Point point2 = new Point(position);

            LineString line = new LineString(new[] { position, position2 });

            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("title", "Bremerhaven");

            Dictionary<string, object> properties2 = new Dictionary<string, object>();
            properties2.Add("title", "Berlin");

            Dictionary<string, object> properties3 = new Dictionary<string, object>();
            properties3.Add("title", "Bremerhaven - Berlin");

            Feature feature = new Feature(point, properties);
            Feature feature2 = new Feature(point2, properties2);
            Feature feature3 = new Feature(line, properties3);

            FeatureCollection collection = new FeatureCollection();
            collection.Features.Add(feature);
            collection.Features.Add(feature2);
            collection.Features.Add(feature3);

            string output = JsonConvert.SerializeObject(collection);

            createCookie("GeoJson",output); 

            string path = @"~\App_Data\GeoData.geojson";
            File.WriteAllText(Server.MapPath(path), output);
            Debug.WriteLine(output);
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