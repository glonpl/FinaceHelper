using NUnit.Framework;
using FinanceHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FinanceHelperTests
{
    [TestClass]
    public class UserTests
    {
        User user;
        string testNick;
        string testPass;
        DateTime testDate;
        double testAmount;
        string testCurrency;
        string testName;
        double testExchangePrice;
        [TestInitialize]
        public void TestInitialize()
        {
            testNick = "Richman";
            testPass = "Rockefeller";
            testDate = new DateTime(2019, 03, 14);
            testAmount = 230.00;
            testCurrency = "philippines peso";
            testName = "BeachBar: CubaLibre";
            testExchangePrice = 0.073;
            user = new User(testNick, testPass);
        }
        [TestMethod]
        CalculateValueInPLN()


    }

}