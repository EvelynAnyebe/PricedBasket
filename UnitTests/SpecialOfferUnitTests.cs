using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PricedBasket;

namespace UnitTests
{
    [TestClass]
    public class SpecialOfferUnitTests
    {

        static DayOfWeek day = DateTime.Now.DayOfWeek;
        static int days = day - DayOfWeek.Sunday;
        static DateTime startDate = DateTime.Now.AddDays(-days);
        static DateTime endDate = startDate.AddDays(6);
        SpecialOffer TestSpecialOffer = new SpecialOffer(1, new Product("Oranges", 1.9m, Constants.Currencies.pound, "bag", 10),
                new Discount(startDate, endDate, 20));

        [TestMethod]
        public void GetDescription_returnsTrue()
        {
            Assert.IsTrue(TestSpecialOffer.GetDescription().Contains("20"));
        }

        [TestMethod]
        public void GetDeduction_returnsExpectedDeduction()
        {
            Assert.AreEqual(TestSpecialOffer.GetDeduction(1, Constants.Currencies.penny),38m);
        }
    }
}
