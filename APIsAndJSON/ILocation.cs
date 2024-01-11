using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public interface ILocation
    {
        public string City { get; set; }
        public string Country { get; set; }
    }
}
