using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricedBasket
{
    // This class handles conrency conversion
     public class CurrencyManager
    {
       
        public static decimal GetPriceByCurrency(decimal amount, Constants.Currencies currentCurrency, Constants.Currencies newCurrency) {
            if (amount < 0)
            {
                throw new InvalidValueException("amount");
            }

            // Calculate the price for new currency
            if (currentCurrency != newCurrency)
            {
                if (currentCurrency == Constants.Currencies.penny && newCurrency == Constants.Currencies.pound)
                {
                    return amount / 100;
                }
                else if (currentCurrency == Constants.Currencies.pound && newCurrency == Constants.Currencies.penny)
                {
                    return amount * 100;
                }
            }

            return amount;
        }

        public static string ValueAndCurrency(decimal value)
        {
            if (value >= 100)
            {
                return String.Format("{0}{1}", Constants.CurrencySign[Constants.Currencies.pound],Math.Round(value/100,2));
            }
            else return String.Format("{0}{1}", Math.Round(value), Constants.CurrencySign[Constants.Currencies.penny]);
        }

    }
}
