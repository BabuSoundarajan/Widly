using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Widly.Models;
using Widly.Views.ViewModel;

namespace Widly.Views.Customers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer{Id=1, Name="Babu"},
                new Customer{Id=2, Name="Kumar"},
            };

            var viewModel = new CustomerViewModel();
            viewModel.customers = customers;
            return View(viewModel);
        }
    }
}