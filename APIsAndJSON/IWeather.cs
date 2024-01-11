using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public interface IWeather
    {
        public string CurrentTemp { get; set; }
        public string FeelsTemp { get; set; }
        public string MinTemp { get; set; }
        public string MaxTemp { get; set; }
        public string Pressure {  get; set; }
        public string Humidity { get; set; }
    }
}
