using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MvcBootcamp.NorthwindRepository.Interfaces;
using MvcBootcamp.NorthwindRepository.Repositories;
using MvcBootcamp.DAL;
using Telerik.JustMock;
using MvcBootcamp.Web.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace MvcBootcamp.Web.Tests
{
    [TestClass]
    public class CustomerMockTest
    {
        [TestMethod]
        public void GetAllData_ReturnAllCustomers()
        {
            // Arrange
            var custRepo = Mock.Create<IEntityRepository<Customer, string>>();
            Mock.Arrange(() => custRepo.GetAllData()).Returns(
                new List<Customer>()
                {
                    new Customer { CustomerID = "1", CompanyName = "Native 1" },
                    new Customer { CustomerID = "2", CompanyName = "Native 2" },
                    new Customer { CustomerID = "3", CompanyName = "Native 3" }
                }.AsQueryable()).MustBeCalled();

            // Act
            CustomersController controller = new CustomersController(custRepo);
            ViewResult view = controller.Index() as ViewResult;
            var model = view.Model as IEnumerable<Customer>;

            // Assert
            Assert.AreEqual(3, model.Count());
            Assert.IsNotNull(model);
            Assert.AreEqual("Native 2", model.ToList()[1].CompanyName);
        }

        [TestMethod]
        public void Search_ReturnACustomer()
        {
            // Arrange
            var custRepo = Mock.Create<IEntityRepository<Customer, string>>();
            Mock.Arrange(() => custRepo.Search("1")).Returns(
                new Customer {
                    CustomerID = "1",
                    CompanyName = "Native 1"
                }).MustBeCalled();

            // Act
            CustomersController controller = new CustomersController(custRepo);
            ViewResult view = controller.Details("1") as ViewResult;
            var model = view.Model as Customer;

            // Assert
            Assert.AreEqual("Native 1", model.CompanyName);
        }
    }
}
