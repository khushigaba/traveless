using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveless.Data
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException() :base("Sorry, Name cannot be empty!")
        { }
    }
}
