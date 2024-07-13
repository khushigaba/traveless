using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveless.Data
{
    public class NoMoreSeatsException : Exception
    {
        public NoMoreSeatsException() : base("Sorry, No more seats Left!")
        { }
    }
}
