using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveless.Data
{
    public class Flights
    {

        public string FlightCode { get; set; }
        public string AirlineName { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public int Seatsleft { get; set; }
        public double Price { get; set; }

        public Flights()
        {
        }
        public Flights(string flightCode, string airlineName, string origin, string destination, string day, string time, int seatsleft, double price)
        {
            FlightCode = flightCode;
            AirlineName = airlineName;
            Origin = origin;
            Destination = destination;
            Day = day;
            Time = time;
            Seatsleft = seatsleft;
            Price = price;
        }
        public string FormatForFile()
        {
            string formattedPrice = Price.ToString("0.00");
            return $"{FlightCode},{AirlineName},{Origin},{Destination},{Day},{Time},{Seatsleft},{formattedPrice}";
        }

        public override string ToString()
        {
            string formattedPrice = Price.ToString("0.00");
            return $"{FlightCode}, {AirlineName}, {Origin}, {Destination}, {Day}, {Time}, {formattedPrice}";
        }
    }
}
