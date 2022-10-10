using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PricedBasket;

namespace UnitTests
{
    [TestClass]
    public class ProductUnitTests
    {

        public static Product TestProduct = new Product("Beans", 98, Constants.Currencies.penny, "tin", 10);
        [TestMethod]
        public void IsQuantityEnough_returnsFalse()
        {
            Assert.IsFalse(TestProduct.IsQuantityEnough(20));
        }

        [TestMethod]
        public void IsQuantityEnough_returnsTrue()
        {
            Assert.IsTrue(TestProduct.IsQuantityEnough(10));
        }

        [TestMethod]
        public void GetPrice_returnsPoundEquivalent()
        {
            Assert.AreEqual(TestProduct.GetPrice(Constants.Currencies.pound),0.98m);
        }

        [TestMethod]
        public void GetPrice_returnsSame()
        {
            Assert.AreEqual(TestProduct.GetPrice(Constants.Currencies.penny), 98);
        }
    }
}
