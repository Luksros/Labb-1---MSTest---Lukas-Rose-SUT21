using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Lions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Lions_Test
{
    [TestClass]
    public class CalcInterestTest
    {
        [TestMethod]
        public void Save_20000_For_2_Years_5Percent_Interest_Expect_22500()
        {
            //Arrange
            decimal rate = 0.05m;
            int years = 2;
            decimal amount = 20000;
            decimal expected = 22050;

            //Act
            decimal actual = decimal.Round(BankSystem.CalcInterest(rate, years, amount), 2);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Save_MaxValue_For_5_Years_1Percent_Interest_Expect_MaxValue()
        {
            //Arrange
            decimal rate = 0.01m;
            int years = 5;
            decimal amount = decimal.MaxValue;
            decimal expected = 116778.78m;

            //Act
            decimal actual = decimal.Round(BankSystem.CalcInterest(rate, years, amount), 2);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Save_20000_For_5_Years_With_Negative_1_Interest_Expect_19019_80()
        {
            //Arrange
            decimal rate = -0.01m;
            int years = 5;
            decimal amount = 20000;
            decimal expected = 19019.80m;

            //Act
            decimal actual = decimal.Round(BankSystem.CalcInterest(rate, years, amount), 2);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Save_Negative20000_For_5_Years_With_3_Interest_Expect_Larger_Than_0()
        {
            //Arrange
            decimal rate = 0.03m;
            int years = 5;
            decimal amount = -20000;
            //decimal expected = -23185.48m;

            //Act
            decimal actual = decimal.Round(BankSystem.CalcInterest(rate, years, amount), 2);

            //Assert
            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Save_MinValue_For_3_Expect_Failure()
        {
            //Arrange
            decimal rate = 0.05m;
            int years = 3;
            decimal amount = decimal.MinValue;

            //Act, Assert
            decimal actual = decimal.Round(BankSystem.CalcInterest(rate, years, amount), 2);
        }
    }
}
