using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Helpers
{
    public class ChartJsHelper
    {
        public string[] barChartLabels { get; set; }
        public string barChartType { get; set; }
        public bool barChartLegend { get; set; }
       public IList<BarchartData> barChartData { get; set; }
    }


    public class BarchartData
    {
        public IList<float> data { get; set; }
        public string label { get; set; }
    }
}
