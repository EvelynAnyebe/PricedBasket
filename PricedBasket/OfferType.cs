using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricedBasket
{
    public class OfferType
    {
        protected Constants.OfferTypes Name { get; set; }
        protected DateTime StartDate { get; set; }
        protected DateTime EndDate { get; set; }

        public bool IsValid()
        {
            return StartDate <= DateTime.Now && EndDate>=DateTime.Now;
        }

        public string GetName()
        {
            return this.Name.ToString();
        }
        public virtual string GetDescription()
        {
            return this.Name.ToString();
        }

        public virtual decimal GetDeductionRate()
        {
            return 0;
        }
    }

   
}
