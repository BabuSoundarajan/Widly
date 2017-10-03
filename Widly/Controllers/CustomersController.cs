using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Widly.Models;
using Widly.Models.ViewModel;
using Widly.Views.ViewModel;

namespace Widly.Views.Customers
{


    public class CustomersController : Controller
    {

        ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(nameof(CustomersController.Index), customers);
        }

        public ActionResult Details(int id)
        {
            var customers = _context.Customers.Where(s => s.Id == id).FirstOrDefault();
            return View(nameof(CustomersController.Details), customers);
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.Single(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
      public ActionResult Save(Customer customer)
      {
          if (customer.Id == 0)
              _context.Customers.Add(customer);
          else
          {
              var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
              customerInDb.Name = customer.Name;
              customerInDb.BirthDate = customer.BirthDate;
              customerInDb.MembershipTypeId = customer.MembershipTypeId;
              customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
          }

          _context.SaveChanges();

          return RedirectToAction("Index", "Customers");
      }
    }
}