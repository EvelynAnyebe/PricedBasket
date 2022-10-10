using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricedBasket
{
    public class BasketManager
    {
        // Define this week
        static DayOfWeek day = DateTime.Now.DayOfWeek;
        static int days = day - DayOfWeek.Sunday;
        static DateTime startDate = DateTime.Now.AddDays(-days);
        static DateTime endDate = startDate.AddDays(6);

        // Define the store
        static List<Product> Products = new List<Product>()
                {
                     new Product("Beans", 98,Constants.Currencies.penny, "tin",10),
                     new Product("Bread", 84,Constants.Currencies.penny, "loaf",10),
                     new Product("Milk", 1.5m, Constants.Currencies.pound, "bottle",10),
                     new Product("Oranges", 1.9m, Constants.Currencies.pound, "bag",10)
                };
        static List<SpecialOffer> SpecialOffers = new List<SpecialOffer>()
        {
            new SpecialOffer(1, Products[3],
                new Discount(startDate, endDate, 20)),
            new SpecialOffer(1, Products[0],
                new Multibuy(startDate, endDate, Products[0], Products[3], 2, 0.5)),
        };
        static Constants.Currencies DefaultCurrency= Constants.Currencies.penny;

        // Priced basket function
        public static void PriceBasket()
        {
            try
            {
                //Show currently available items
                MessageManager.Print("\nThe currently available goods are:");
                foreach (Product item in Products)
                    MessageManager.Print(item.GetFullDescription());

                // Get pricedBasket
                string pricedBasket = null;
                MessageManager.Print("\nEnter your PricedBasket items in a single line.\n Each item and/or quantity should be separated by a single space. " +
                    "For example: \n----------------\n" +
                    "Beans 2 Milk 2 Oranges 1" +
                    "\n---------------------\n " +
                    "Press the enter key when done.");
                pricedBasket = Console.ReadLine();

                // Validate input
                if (String.IsNullOrWhiteSpace(pricedBasket))
                {
                    throw new InvalidValueException("Priced basket");
                }

                // Process Basket
                Result result = ProcessBasket(pricedBasket);

                // Print result
                MessageManager.Print(String.Format("\nSubtotal: {0}", CurrencyManager.ValueAndCurrency(result.SubTotal)));
                MessageManager.Print("--------------\nOffers");
                if (result.Offers.Count > 0)
                {
                    foreach (string offer in result.Offers)
                        MessageManager.Print(offer);
                }
                else
                {
                    MessageManager.Print("No offers available");
                }
                MessageManager.Print("--------------");
                MessageManager.Print(String.Format("Total: {0}", CurrencyManager.ValueAndCurrency(result.Total)));

            }
            catch (DivideByZeroException e)
            {
                MessageManager.LogError(Constants.ErrorType.DivideByZeroException);
            }
            catch (InvalidOperationException e)
            {
                MessageManager.LogError(Constants.ErrorType.InvalidOperationException);
            }
            catch (IndexOutOfRangeException e)
            {
                MessageManager.LogError(Constants.ErrorType.IndexOutOfRangeException, e.Message);
            }
            catch (FormatException e)
            {
                MessageManager.LogError(Constants.ErrorType.FormatException);
            }
            catch (InvalidValueException e)
            {
                MessageManager.LogError(Constants.ErrorType.InvalidValueException, e.Message);
            }
            catch (Exception e)
            {
                MessageManager.LogError(Constants.ErrorType.Exception, e.Message);
            }
            finally
            {
                MessageManager.Print("REQUEST COMPLETED");
            }
        }


        /**
         * <summary>Process the priced basket fromthe user</summary>
         *
         * <param name="pricedBasket">String input from user</param>
         * <returns Result></returns>
         */
        public static Result ProcessBasket(string pricedBasket)
        {
            Result result = new Result() { SubTotal = 0, Total = 0, Offers = new List<string>() };
            string[] stringList = pricedBasket.ToLower().Split(' ');
            decimal totalDiscount = 0;

            // process subtotal and offers
            int currentItemIndex = -1;
            int currentQuantity = 1;
            int currentOfferIndex = -1;
            decimal offerCost = 0;
            int i = 0;
            int j = 0;
            while (i < stringList.Length)
            {
                // Validate input
                if (!String.IsNullOrWhiteSpace(stringList[i]))
                {

                    currentItemIndex = Products.FindIndex(p => p.Name.ToLower() == stringList[i]);
                    if (currentItemIndex == -1)
                    {
                        throw new InvalidValueException(stringList[i]);
                    }
                    else if ((i + 1) < stringList.Length && int.TryParse(stringList[i + 1], out currentQuantity))
                    {
                        // validate quantity
                        if (currentQuantity <= 0)
                        {
                            throw new InvalidValueException("Quantity:  " + currentQuantity);
                        }
                        result.SubTotal += HandleProductCost(currentItemIndex, currentQuantity);
                        j = 1;
                    }
                    else
                    {
                        // There is no quantity specified for this item, quantity=1
                        currentQuantity = 1;
                        result.SubTotal += HandleProductCost(currentItemIndex, currentQuantity);
                    }

                    // Set the offer and calculate total discount
                    currentOfferIndex = SpecialOffers.FindIndex(offer => offer.Item.Name.ToLower() == stringList[i]);
                    if (currentOfferIndex != -1)
                    {
                        offerCost = SpecialOffers[currentOfferIndex].GetDeduction(currentQuantity, DefaultCurrency);
                        totalDiscount += offerCost;
                        result.Offers.Add(SpecialOffers[currentOfferIndex].GetDescription() + " -" + CurrencyManager.ValueAndCurrency(offerCost));

                    }
                }

                i+=1+j;
                j = 0;
                currentItemIndex = -1;
                currentOfferIndex = -1;
            }
            // Calculate total here
            result.Total = result.SubTotal - totalDiscount;
            return result;

        }

        // Calculate price for item in basket
        public static decimal HandleProductCost(int currentItemIndex, int currentQuantity)
        {
            // Check if quantity is sufficient
            if (Products[currentItemIndex].IsQuantityEnough(currentQuantity))
            {
                Products[currentItemIndex].Quantity = Products[currentItemIndex].Quantity - currentQuantity;
                return currentQuantity * Products[currentItemIndex].GetPrice(DefaultCurrency);
            }
            MessageManager.Print(String.Format("\nProduct: {0} not added due to insufficient quantity", Products[currentItemIndex].Name));
            return 0;
        }
    }
}
