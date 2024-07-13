using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveless.Data
{
    public class Airports
    {
        public string AirportCode { get; set; }
        public string AirportName { get; set; }

        public Airports() 
        {
        }

        public Airports(string airportCode, string airportName)
        {
            AirportCode = airportCode;
            AirportName = airportName;
        }
    }
}
