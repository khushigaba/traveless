using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveless.Data
{
    public class Reservation
    {
        public Flights Flight { get; set; }
        public string Name { get; set; }
        public string Citizenship { get; set; }
        public string ReservationCode { get; set; }
        public string Status { get; set; }

        public Reservation()
        {
        }

        public Reservation(Flights flight, string name, string citizenship, string reservationCode, string status = "Active")
        {
            Flight = flight;
            Name = name;
            Citizenship = citizenship;
            ReservationCode = reservationCode;
            Status = status;
        }
        public string FormatForFile()
        {
            return$"{Flight.FormatForFile()},{Name},{Citizenship},{ReservationCode},{Status}";
        }

        public override string ToString()
        {
            return $"{Flight}";
        }

        
    }
}
