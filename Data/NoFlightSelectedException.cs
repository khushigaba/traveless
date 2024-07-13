using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveless.Data
{
    public class NoFlightSelectedException : Exception
    {
        public NoFlightSelectedException() : base("Try Again, No flight is selected!")
        { }
    }
}
