using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricedBasket
{
    public class Multibuy : OfferType
    {
        public Product ProductToBuy { get; set; }
        public Product ProductToDiscountedOn { get; set; }
        public double QuantityToBuy { get; set; }
        public double QuantityDiscounted { get; set; }

        public Multibuy(DateTime startDate, DateTime endDate,
            Product productToBuy, Product productToDiscountedOn, double quantityToBuy, double quantityDiscounted)
        {
            this.Name = Constants.OfferTypes.Multibuy;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.ProductToBuy = productToBuy;
            this.ProductToDiscountedOn = productToDiscountedOn;
            this.QuantityToBuy = quantityToBuy;
            this.QuantityDiscounted = quantityDiscounted;
        }

        public override string GetDescription()
        {
            return String.Format("Buy {0} {1} and get {2} of {3}",
                QuantityToBuy, ProductToBuy.Name, QuantityDiscounted, ProductToDiscountedOn.Name);
        }

        public override decimal GetDeductionRate()
        {
            return (decimal)QuantityDiscounted * ProductToDiscountedOn.Price;
        }
    }

}
