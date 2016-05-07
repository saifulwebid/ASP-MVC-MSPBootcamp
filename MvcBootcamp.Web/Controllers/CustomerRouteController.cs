using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcBootcamp.NorthwindRepository.Repositories;

namespace MvcBootcamp.Web.Controllers
{
    [RoutePrefix("CustomerData")]
    public class CustomerRouteController : Controller
    {
        private CustomerRepository custRepo = new CustomerRepository();

        [Route]
        [Route("AllCustomer")]
        public ActionResult Index()
        {
            return View(custRepo.GetAllData().Take(5));
        }

        [Route("{id}")]
        public ActionResult Search(string id)
        {
            return View(custRepo.Search(id));
        }
    }
}