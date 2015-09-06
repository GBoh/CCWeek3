using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IdentityWoot.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using IdentityWoot.Models;
using System.Linq;
using Moq;

namespace IdentityWoot.Tests {
    [TestClass]
    public class ManageUsersControllerTests {
        [TestMethod]
        public void TestListUsers() {
            //Arrange
            var users = new List<ApplicationUser> {
                new ApplicationUser {FirstName = "Bob", LastName = "Bobson" },
                new ApplicationUser {FirstName = "Andrew", LastName = "Anderson" },
                new ApplicationUser {FirstName = "Carl", LastName = "Caaaaarrrllllllll" }
            };
            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(mock => mock.Query<ApplicationUser>()).Returns(users.AsQueryable());
            
            var manageUsersController = new ManageUsersController(mockRepo.Object);
            //Act
            var results = manageUsersController.Index() as ViewResult;
            var model = results.Model as IList<ApplicationUser>;
            //Assert
            Assert.AreEqual("Andrew", model.First().FirstName);

        }
    }
}
