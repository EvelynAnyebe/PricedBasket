using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace PricedBasket
{

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Constants.Currencies Currency { get; set; }
        public string UnitMeasure { get; set; }
        public float Quantity { get; set; }

        public Product(string name, decimal price, Constants.Currencies currency = Constants.Currencies.penny, string unitOfMeasure=null, float quantity=0)
        {
            Name = name;
            Price = price;
            Currency = currency;
            UnitMeasure = unitOfMeasure;
            Quantity = quantity;
        }

        public string GetFullDescription()
        {
            return Name +"-" + Math.Round(Price,2) + Constants.CurrencySign[Currency] + " per "+ UnitMeasure + ". Quantity left-"+ Quantity;
        }


        public decimal GetPrice(Constants.Currencies expectedCurrency)
        {
            return CurrencyManager.GetPriceByCurrency(Price,Currency,expectedCurrency);
        }

        public bool IsQuantityEnough(int quantity)
        {
            return Quantity >= quantity;
        }

    }
}
