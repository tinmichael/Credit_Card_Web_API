using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCardWebAPI;
using CreditCardWebAPI.Controllers;
using CreditCardWebAPI.Models;
using System.Web.Http.Results;

namespace CreditCardWebAPI.Tests.Controllers
{
    [TestClass]
    public class CreditCardsControllerTest
    {


        [TestMethod]
        public void TestVisaCardType()
        {
            // Arrange
            CreditCardsController controller = new CreditCardsController();

            // Act
            var httpResult = controller.GetCreditCard("4444333322221111");
            
            var result = httpResult as OkNegotiatedContentResult<ValidateResult>;

            // Assert
            Assert.AreEqual("VISA", result.Content.cardType);
        }

        [TestMethod]
        public void TestMasterCardType()
        {
            // Arrange
            CreditCardsController controller = new CreditCardsController();

            // Act
            var httpResult = controller.GetCreditCard("5105105105105100");

            var result = httpResult as OkNegotiatedContentResult<ValidateResult>;

            // Assert
            Assert.AreEqual("MasterCard", result.Content.cardType);
        }

        [TestMethod]
        public void TestAmexCardType()
        {
            // Arrange
            CreditCardsController controller = new CreditCardsController();

            // Act
            var httpResult = controller.GetCreditCard("378282246310005");

            var result = httpResult as OkNegotiatedContentResult<ValidateResult>;

            // Assert
            Assert.AreEqual("Amex", result.Content.cardType);
        }

        [TestMethod]
        public void TestJCBCardType()
        {
            // Arrange
            CreditCardsController controller = new CreditCardsController();

            // Act
            var httpResult = controller.GetCreditCard("3530111333300000");

            var result = httpResult as OkNegotiatedContentResult<ValidateResult>;

            // Assert
            Assert.AreEqual("JCB", result.Content.cardType);
        }

        [TestMethod]
        public void TestUnknown()
        {
            // Arrange
            CreditCardsController controller = new CreditCardsController();

            // Act
            var httpResult = controller.GetCreditCard("6011111111111117");

            var result = httpResult as OkNegotiatedContentResult<ValidateResult>;

            // Assert
            Assert.AreEqual("Unknown", result.Content.cardType);
        }

        [TestMethod]
        public void TestValidAmexCard()
        {
            // Arrange
            CreditCardsController controller = new CreditCardsController();

            // Act
            var httpResult = controller.GetCreditCard("378282246310005");

            var result = httpResult as OkNegotiatedContentResult<ValidateResult>;

            // Assert
            Assert.AreEqual("Valid", result.Content.result);
            Assert.AreEqual("Amex", result.Content.cardType);
        }


        [TestMethod]
        public void TestValidVisaCard()
        {
            // Arrange
            CreditCardsController controller = new CreditCardsController();

            // Act
            var httpResult = controller.GetCreditCard("4444333322221111");

            var result = httpResult as OkNegotiatedContentResult<ValidateResult>;

            // Assert
            Assert.AreEqual("Valid", result.Content.result);
            Assert.AreEqual("VISA", result.Content.cardType);
        }

        [TestMethod]
        public void TestValidMasterCard()
        {
            // Arrange
            CreditCardsController controller = new CreditCardsController();

            // Act
            var httpResult = controller.GetCreditCard("5105105105105100");

            var result = httpResult as OkNegotiatedContentResult<ValidateResult>;

            // Assert
            Assert.AreEqual("Valid", result.Content.result);
            Assert.AreEqual("MasterCard", result.Content.cardType);
        }

        [TestMethod]
        public void TestValidJCBCard()
        {
            // Arrange
            CreditCardsController controller = new CreditCardsController();

            // Act
            var httpResult = controller.GetCreditCard("3530111333300000");

            var result = httpResult as OkNegotiatedContentResult<ValidateResult>;

            // Assert
            Assert.AreEqual("Valid", result.Content.result);
            Assert.AreEqual("JCB", result.Content.cardType);
        }

        [TestMethod]
        public void TestDoesNotExist()
        {
            // Arrange
            CreditCardsController controller = new CreditCardsController();

            // Act
            var httpResult = controller.GetCreditCard("4111111111111111");

            var result = httpResult as OkNegotiatedContentResult<ValidateResult>;

            // Assert
            Assert.AreEqual("Does Not Exist", result.Content.result);

        }

        [TestMethod]
        public void TestInvalid()
        {
            // Arrange
            CreditCardsController controller = new CreditCardsController();

            // Act
            var httpResult = controller.GetCreditCard("6011111111111117");

            var result = httpResult as OkNegotiatedContentResult<ValidateResult>;

            // Assert
            Assert.AreEqual("Invalid", result.Content.result);

        }
    }
}


 
