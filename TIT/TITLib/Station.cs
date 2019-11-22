using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TITLib
{
    public class Station
    {
        private int _id;
        public int ID
        {
            get => _id;
            set
            {
                _id = value;
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }

        private string _country;
        public string Country
        {
            get => _country;
            set
            {
                _country = value;
            }
        }

        private string _latitude;
        public string Latitude
        {
            get => _latitude;
            set
            {
                _latitude = value;
            }
        }

        private string _longitude;
        public string Longitude
        {
            get => _longitude;
            set
            {
                _longitude = value;
            }
        }

        public Station()
        {

        }

        public Station(int iD, string name, string country, string latitude, string longitude)
        {
            ID = iD;
            Name = name;
            Country = country;
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
