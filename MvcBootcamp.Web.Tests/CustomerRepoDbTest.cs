using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MvcBootcamp.DAL;
using MvcBootcamp.NorthwindRepository.Repositories;
using System.Linq;

namespace MvcBootcamp.Web.Tests
{
    [TestClass]
    public class CustomerRepoDbTest
    {
        [TestMethod]
        public void GetAllData_ReturnAllCustomers()
        {
            var repo = new CustomerRepository();
            var allCust = repo.GetAllData().ToList();
            Assert.AreEqual(91, allCust.Count());
        }

        [TestMethod]
        public void Search_ReturnACustomer()
        {
            var repo = new CustomerRepository();
            var cust = repo.Search("ALFKI");
            Assert.AreNotEqual("Alfred F", cust.CompanyName);
        }
    }
}
