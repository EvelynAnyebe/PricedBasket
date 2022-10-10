using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricedBasket
{
   public class Result
    {
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public List<string> Offers { get; set; }
    }
}
