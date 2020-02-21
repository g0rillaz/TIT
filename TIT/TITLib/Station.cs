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

        private string _number;
        public string Number
        {
            get => _number;
            set
            {
                _number = value;
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

        private string _countryId;
        public string CountryId
        {
            get => _countryId;
            set
            {
                _countryId = value;
            }
        }

        private string _countryName;
        public string CountryName
        {
            get => _countryName;
            set
            {
                _countryName = value;
            }
        }

        private string _countryIso;
        public string CountryIso
        {
            get => _countryIso;
            set
            {
                _countryIso = value;
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

        public Station(int iD, string number, string name, string countryId, string countryName, string countryIso, string latitude, string longitude)
        {
            ID = iD;
            Number = number;
            Name = name;
            CountryId = countryId;
            CountryName = countryName;
            CountryIso = countryIso;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
