using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerData customerDb;

        public CustomerController(ICustomerData customerDb )
        {
            this.customerDb = customerDb;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = customerDb.GetAllCustomers();
            return View(customers);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer) {
            if (ModelState.IsValid) { 
                customerDb.CreateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = customerDb.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
    }
}