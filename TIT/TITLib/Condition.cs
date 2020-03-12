using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TITLib
{
    public class Condition
    {

        private DateTime _dateFrom;
        public DateTime DateFrom
        {
            get => _dateFrom;
            set
            {
                _dateFrom = value;
            }
        }

        private DateTime _dateTo;
        public DateTime DateTo
        {
            get => _dateTo;
            set
            {
                _dateTo = value;
            }
        }

        private bool _raw;
        public bool Raw
        {
            get => _raw;
            set
            {
                _raw = value;
            }
        }

        private bool _mean;
        public bool Mean
        {
            get => _mean;
            set
            {
                _mean = value;
            }
        }

        private bool _median;
        public bool Median
        {
            get => _median;
            set
            {
                _median = value;
            }
        }

        private bool _min;
        public bool Min
        {
            get => _min;
            set
            {
                _min = value;
            }
        }

        private bool _max;
        public bool Max
        {
            get => _max;
            set
            {
                _max = value;
            }
        }

        private bool _deviation;
        public bool Deviation
        {
            get => _deviation;
            set
            {
                _deviation = value;
            }
        }

        private bool _mode;
        public bool Mode
        {
            get => _mode;
            set
            {
                _mode = value;
            }
        }

        private bool _range;
        public bool Range
        {
            get => _range;
            set
            {
                _range = value;
            }
        }
    }
}
