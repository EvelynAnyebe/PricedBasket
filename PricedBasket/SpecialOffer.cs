using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricedBasket
{
    public class SpecialOffer
    {
        public int Id { get; set; }
        public Product Item { get; set; }
        public OfferType Offertype { get; set; }

        public SpecialOffer(int id, Product item, OfferType offertype)
        {
            Id = id;
            Item = item;
            Offertype = offertype;
        }

        public decimal GetDeduction(int quantity, Constants.Currencies currency)
        {
            if(Offertype.GetName()== Constants.OfferTypes.Multibuy.ToString())
            {
                var multibuyOffer = (Multibuy)Offertype;
                decimal quantityToDiscount = (int) (quantity / multibuyOffer.QuantityToBuy);
                return CurrencyManager.GetPriceByCurrency(quantityToDiscount * multibuyOffer.GetDeductionRate(),multibuyOffer.ProductToDiscountedOn.Currency,currency);
            }
            return Item.GetPrice(currency) * Offertype.GetDeductionRate()*quantity;
        }

        public string GetDescription()
        {
            return Item.Name + " " + Offertype.GetDescription();
        }
    }
}
