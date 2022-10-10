using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricedBasket
{
    public class Constants
    {
        // Currency defs
        public enum Currencies
        {
            penny,
            pound
        }

        public static IDictionary<Currencies, string> CurrencySign = new Dictionary<Currencies, string>()
        {
            { Currencies.penny, "p" },
            { Currencies.pound, "£" }
        };

        // ErrorType defs
        public enum ErrorType
        {
            DivideByZeroException,
            InvalidOperationException,
            FormatException,
            InvalidValueException,
            Exception,
            IndexOutOfRangeException
        }

        public static IDictionary<ErrorType, string> ErrorMessages = new Dictionary<ErrorType, string>()
        {
            { ErrorType.DivideByZeroException, "Cannot divide by zero. Please try again." },
            { ErrorType.InvalidOperationException, "Cannot divide by zero. Please try again." },
            { ErrorType.FormatException, "Cannot divide by zero. Please try again." },
            { ErrorType.Exception, "Error occurred! Please try again." },
            {ErrorType.InvalidValueException, "Invalid Value received" },
            {ErrorType.IndexOutOfRangeException, "Index out of range error" }
        };

        // Offer type defs
        public enum OfferTypes
        {
            Discount,
            Multibuy
        }

    }
}
