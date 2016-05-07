using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using MvcBootcamp.DAL;
using MvcBootcamp.NorthwindRepository.Interfaces;
using MvcBootcamp.NorthwindRepository.Repositories;

namespace MvcBootcamp.Web.Controllers
{
    public class CustomersController : Controller
    {
        //private NorthwindEntities db = new NorthwindEntities();
        private IEntityRepository<Customer, string> custRepo;

        public CustomersController()
        {
            custRepo = new CustomerRepository();
        }

        // GET: Customers
        public ActionResult Index()
        {
            //return View(db.Customers.ToList());
            return View(custRepo.GetAllData());
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = db.Customers.Find(id);
            Customer customer = custRepo.Search(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customer customer)
        {
            throw new Exception("Testing error");

            if (ModelState.IsValid)
            {
                try
                {
                    custRepo.Insert(customer);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Simpan error detail ke database.
                    ViewBag.ErrMsg = ex.Message;
                }
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = db.Customers.Find(id);
            Customer customer = custRepo.Search(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(customer).State = EntityState.Modified;
                //db.SaveChanges();
                custRepo.Update(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = db.Customers.Find(id);
            Customer customer = custRepo.Search(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            //Customer customer = db.Customers.Find(id);
            //db.Customers.Remove(customer);
            //db.SaveChanges();
            custRepo.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult CheckCustomerID(string CustomerID)
        {
            Customer customer = custRepo.Search(CustomerID);
            return Json(customer == null, JsonRequestBehavior.AllowGet);
        }
    }
}
