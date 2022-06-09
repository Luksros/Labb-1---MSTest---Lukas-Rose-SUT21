using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Lions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Lions_Test
{
    [TestClass]
    public class InternalTransferTest
    {
        [TestMethod]
        public void Withdraw_10000_From_Account1_Expect_10000_Remaining_Balance()
        {
            //Arrange
            Customer testUser = new Customer("Test", "TestPass1!", new Account() { Name = "Lönekonto", Balance = 20000m, Currency = "SEK" });
            testUser.Accounts.Add(new Account() { Name = "Sparkonto", Balance = 20000m, Currency = "SEK" });
            int moveFrom = 1;
            int moveTo = 2;
            decimal amount = 10000m;
            decimal expected = 10000m;

            //Act
            testUser.ExecuteInternalTransfer(moveFrom, moveTo, amount);
            decimal actual = testUser.Accounts[moveFrom - 1].Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Add_10000_To_Account2_Expect_30000_Balance()
        {
            //Arrange
            Customer testUser = new Customer("Test", "TestPass1!", new Account() { Name = "Lönekonto", Balance = 20000m, Currency = "SEK" });
            testUser.Accounts.Add(new Account() { Name = "Sparkonto", Balance = 20000m, Currency = "SEK" });
            int moveFrom = 1;
            int moveTo = 2;
            decimal amount = 10000m;
            decimal expected = 30000m;

            //Act
            testUser.ExecuteInternalTransfer(moveFrom, moveTo, amount);
            decimal actual = testUser.Accounts[moveTo - 1].Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Move_MaxValueMinus1_From_Account3_To_Account_1_Expect_1_Remaining_Balance()
        {
            //Arrange
            Customer testUser = new Customer("Test", "TestPass1!", new Account() { Name = "Lönekonto", Balance = 0, Currency = "SEK" });
            testUser.Accounts.Add(new Account() { Name = "Sparkonto", Balance = 357000, Currency = "SEK" });
            testUser.Accounts.Add(new Account() { Name = "Semesterkonto", Balance = decimal.MaxValue, Currency = "SEK" });
            int moveFrom = 3;
            int moveTo = 1;
            decimal amount = decimal.MaxValue - 1;
            decimal expected = 1m;

            //Act
            testUser.ExecuteInternalTransfer(moveFrom, moveTo, amount);
            decimal actual = testUser.Accounts[moveFrom - 1].Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Move_negative40000_From_Account1_To_Account2_Expect_Failure()
        {
            //Arrange
            Customer testUser = new Customer("Test", "TestPass1!", new Account() { Name = "Lönekonto", Balance = 20000m, Currency = "SEK" });
            testUser.Accounts.Add(new Account() { Name = "Sparkonto", Balance = 20000m, Currency = "SEK" });
            int moveFrom = 1;
            int moveTo = 2;
            decimal amount = -40000m;

            //Act, Assert
            testUser.ExecuteInternalTransfer(moveFrom, moveTo, amount);
        }
    }
}
