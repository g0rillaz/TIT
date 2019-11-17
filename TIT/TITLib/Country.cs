using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TITLib
{
    public class Country
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

        private string _isoCode;
        public string IsoCode
        {
            get => _isoCode;
            set
            {
                _isoCode = value;
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

        public Country()
        {

        }
        public Country(int iD, string isoCode, string name)
        {
            ID = iD;
            IsoCode = isoCode;
            Name = name;
        }
    }
}
