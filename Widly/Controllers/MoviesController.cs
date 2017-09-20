using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Widly.Models;

namespace Widly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.GenreType).ToList();

            return View(movies);
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.GenreType).Where(m => m.Id == Id).FirstOrDefault();
            return View(movie);
        }
    }
}