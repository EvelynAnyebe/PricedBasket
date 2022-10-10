using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricedBasket
{
    
    class Program
    {
       
        static void Main(string[] args)
        {
            int runPriceBasket = 1;
            while (runPriceBasket == 1)
            {
                MessageManager.Print("WELCOME TO PRICED BASKET APP.");

                BasketManager.PriceBasket();

                MessageManager.Print("\nEnter 1 to price basket again or press any key to quit.");
                if (!int.TryParse(Console.ReadLine(), out runPriceBasket) || runPriceBasket != 1)
                {
                    break;
                    
                }
            }
            MessageManager.Print("\nGOODBYE.\nPRESS ENTER KEY TO CLOSE PROGRAM.\n");
            Console.ReadLine();
        }  
    }
}
