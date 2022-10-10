using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricedBasket
{
   public class Discount : OfferType
    {
        public decimal Percentage { get; set; }
        public Discount(DateTime startDate, DateTime endDate, decimal percentage)
        {
            this.Name = Constants.OfferTypes.Discount;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Percentage = percentage;
        }

        public override string GetDescription()
        {
            return Percentage + "% off";
        }

        public override decimal GetDeductionRate()
        {
            return (decimal)Percentage / 100;
        }
    }
}
