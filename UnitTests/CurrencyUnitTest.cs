using Microsoft.VisualStudio.TestTools.UnitTesting;
using PricedBasket;
using System;

namespace UnitTests
{
    [TestClass]
    public class CurrencyManagerTests
    {
        [TestMethod]
        public void GetPriceByCurrency_amountZero_throwException()
        {
            // Arrange
            // Act
            var result = CurrencyManager.GetPriceByCurrency(0, Constants.Currencies.pound, Constants.Currencies.penny);

            //Assert
            Assert.AreEqual(0,result);
        }

        [TestMethod]
        public void GetPriceByCurrency_currencyTheSame_returnsAmount()
        {
            // Arrange
            // Act
            var result = CurrencyManager.GetPriceByCurrency(98, Constants.Currencies.penny, Constants.Currencies.penny);

            //Assert
            Assert.AreEqual(result,98);
        }


        [TestMethod]
        public void GetPriceByCurrency_currencyPound_returnsAmount()
        {
            var result = CurrencyManager.GetPriceByCurrency(1.9m, Constants.Currencies.pound, Constants.Currencies.penny);
            Assert.AreEqual(result, 190);

        }

        [TestMethod]
        public void GetPriceByCurrency_currencyPenny_returnsAmount()
        {
            var result = CurrencyManager.GetPriceByCurrency(98, Constants.Currencies.penny, Constants.Currencies.pound);
            Assert.AreEqual(result, 0.98m);
        }

        [TestMethod]
        public void ValueAndCurrency_pound_returnsPoundSign()
        {
            var result = CurrencyManager.ValueAndCurrency(190);
            Assert.IsTrue(result.Contains("£"));
        }

        [TestMethod]
        public void ValueAndCurrency_pound_returnsPennySign()
        {
            var result = CurrencyManager.ValueAndCurrency(99);
            Assert.IsTrue(result.Contains("p"));
        }
    }
}
