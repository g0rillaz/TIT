using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TITLib
{
    public class SelectedOptions
    {
        public SelectedOptions(
            string Modulname,
            string Fromdate,
            string Todate,
            string Region,
            string Station,
            string Interval,
            string OrderedBy,
            bool RawTemperature,
            bool MeanTemperature,
            bool MedianTemperature,
            bool MinTemperature,
            bool MaxTemperature,
            bool StandardDeviation,
            bool ModeTemperature,
            bool RangeTemperature
)
        {
            modulname = Modulname;
            fromDate = Fromdate;
            toDate = Todate;

            region = Region;
            station = Station;
            interval = Interval;
            orderedBy = OrderedBy;

            rawTemperature = RawTemperature;
            meanTemperature = MeanTemperature;
            medianTemperature = MedianTemperature;
            minTemperature = MinTemperature;
            maxTemperature = MaxTemperature;
            standardDeviation = StandardDeviation;
            modeTemperature = ModeTemperature;
            rangeTemperature = RangeTemperature;

        }
        string modulname { get; set; }
        string fromDate { get; set; }
        string toDate  { get; set; }

        string region  { get; set; }
        string station { get; set; }
        string interval  { get; set; }
        string orderedBy { get; set; }

        bool rawTemperature  { get; set; }
        bool meanTemperature { get; set; }
        bool medianTemperature { get; set; }
        bool minTemperature { get; set; }
        bool maxTemperature { get; set; }
        bool standardDeviation { get; set; }
        bool modeTemperature { get; set; }
        bool rangeTemperature { get; set; }
    }
}
