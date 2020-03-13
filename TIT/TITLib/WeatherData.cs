using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TITLib
{
    public class WeatherData
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

        private string _countryName;
        public string CountryName
        {
            get => _countryName;
            set
            {
                _countryName = value;
            }
        }

        private string _stationName;
        public string StationName
        {
            get => _stationName;
            set
            {
                _stationName = value;
            }
        }

        private string _stationNumber;
        public string StationNumber
        {
            get => _stationNumber;
            set
            {
                _stationNumber = value;
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
            }
        }

        private decimal _mean;
        public decimal Mean
        {
            get => _mean;
            set
            {
                _mean = value;
            }
        }

        private decimal _median;
        public decimal Median
        {
            get => _median;
            set
            {
                _median = value;
            }
        }

        private decimal _min;
        public decimal Min
        {
            get => _min;
            set
            {
                _min = value;
            }
        }

        private decimal _max;
        public decimal Max
        {
            get => _max;
            set
            {
                _max = value;
            }
        }

        private decimal _deviation;
        public decimal Deviation
        {
            get => _deviation;
            set
            {
                _deviation = value;
            }
        }

        private decimal _mode;
        public decimal Mode
        {
            get => _mode;
            set
            {
                _mode = value;
            }
        }

        private decimal _range;
        public decimal Range
        {
            get => _range;
            set
            {
                _range = value;
            }
        }

    }
}
