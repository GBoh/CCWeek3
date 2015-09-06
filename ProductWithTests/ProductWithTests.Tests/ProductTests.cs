using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductWithTests.Models;
using System.Linq;

namespace ProductWithTests.Tests {
    [TestClass]
    public class ProductTests {

        [TestMethod]
        public void ProductNameRequired() {
            //Arrange
            var product = new Product {
                Name = "",
                Price = 1.00m,
            };
            //Act
            var results = TestHelper.Validate(product);
            //Assert
            Assert.IsTrue(results.Any(p => p.ErrorMessage == "Product name is required"));
        }

        [TestMethod]
        public void PriceGreaterThan0() {
            var product = new Product {
                Name = "Apple",
                Price = -1m
            };

            var results = TestHelper.Validate(product);
            Assert.IsTrue(results.Any(p => p.ErrorMessage == "Price must be larger than $0.00"));
        }

        [TestMethod]
        public void TestPriceNot17() {
            var product = new Product {
                Name = "Apple",
                Price = 17m
            };

            var results = TestHelper.Validate(product);
            Assert.IsTrue(results.Any(p => p.ErrorMessage == "Price cannot be $17.00"));
        }
    }
}
