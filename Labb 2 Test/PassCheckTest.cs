using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Lions;
using System;

namespace Project_Lions_Test
{
    [TestClass]
    public class PassCheckTest
    {
        [TestMethod]
        public void CorrectUserNameAndPassword_ExpectTrue()
        {
            //Arrange
            Customer testUser = new Customer("Test", "TestPass1!", new Account());

            //Act
            bool actual = BankSystem.PassCheck(testUser, "Test", "TestPass1!");

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CorrectUserNameAndMistypedPassword_ExpectFalse()
        {
            //Arrange
            Customer testUser = new Customer("Test", "TestPass1!", new Account());

            //Act
            bool actual = BankSystem.PassCheck(testUser, "Test", "testpass1!");

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void WrongCapsUserNameAndCorrectPassword_ExpectTrue()
        {
            //Arrange
            Customer testUser = new Customer("Test", "TestPass1!", new Account());

            //Act
            bool actual = BankSystem.PassCheck(testUser, "tEST", "TestPass1!");

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void MismatchExistingUserNameAndPassword_ExpectFalse()
        {
            //Arrange
            Customer testUser = new Customer("Test", "TestPass1!", new Account());
            Customer testUser2 = new Customer("Test2", "WrongPass1&", new Account());

            //Act
            bool actual = BankSystem.PassCheck(testUser, "Test", "WrongPass1&");

            //Assert
            Assert.IsFalse(actual);
        }
    }
}
