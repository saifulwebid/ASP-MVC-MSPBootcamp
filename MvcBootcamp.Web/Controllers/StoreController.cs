using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.Web.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public string Index()
        {
            return "Store.Index returns.";
        }

        public string Browse(string category)
        {
            return HttpUtility.HtmlEncode("Category: " + category);
        }

        public string News(int year, int month, int day)
        {
            return HttpUtility.HtmlEncode("Year: " + year + ", month: " + month + ", day: " + day);
        }

        public ActionResult Home()
        {
            // return View();
            // return View("About");
            return View("~/Views/Home/Contact.cshtml");
        }

        public ActionResult DataSample()
        {
            ViewData["event"] = "MSP Bootcamp";
            ViewData["place"] = "Hotel Neo";

            ViewBag.events = "MSP Bootcamp";
            ViewBag.place = "Hotel Neo Bandung";

            var books = new List<String>() { "ASP.NET", "SQL Server", "Windows 10" };
            ViewBag.bookList = books;

            return View();
        }

        public ViewResult StronglyTypeView()
        {
            var newCust = new Models.CustomerData()
            {
                CompanyName = "Native Enterprise",
                City = "Bandung"
            };

            return View(newCust);
        }

        public ViewResult StronglyTypeViewCollection()
        {
            var CustA = new Models.CustomerData()
            {
                CompanyName = "Microsoft Indonesia",
                City = "Jakarta"
            };
            var CustB = new Models.CustomerData()
            {
                CompanyName = "Native Enterprise",
                City = "Bandung"
            };
            var Coll = new List<Models.CustomerData>() { CustA, CustB };

            return View(Coll);
        }
    }
}