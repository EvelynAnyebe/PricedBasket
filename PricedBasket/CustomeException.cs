using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricedBasket
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException() { }

        public InvalidValueException(string name)
            : base("Invalid value: " + name)
        {

        }
    }

}
