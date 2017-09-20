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

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int? year, int? month)
        {
            return Content(year + "/" + month);
        }
    }
}