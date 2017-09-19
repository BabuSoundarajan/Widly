using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Widly.Models;

namespace Widly.Views.Customers
{


    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = _context.Customers.Where(s => s.Id == id).FirstOrDefault();
            return View(nameof(CustomersController.Details), customers);
        }
    }
}