using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Widly.Models;
using Widly.Models.IdentityModels;
using Widly.Views.ViewModel;

namespace Widly.Controllers
{
    [Authorize(Roles =RoleName.CanChangeMovies)]
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        protected override void Dispose(bool diposing)
        {
            _context.Dispose();
        }

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
       
        [AllowAnonymous]
       
        public ActionResult Index()
        {
            if(User.IsInRole(RoleName.CanChangeMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.GenreType).Where(m => m.Id == Id).FirstOrDefault();
            return View(movie);
        }

        public ActionResult New()
        {
            ViewBag.Operation = "Add";
            var genreTypes = _context.GenreType.ToList();

            var movieViewModel = new MovieFormViewModel()
            {
                GenreTypes = genreTypes
            };

            return View("MovieForm", movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                   GenreTypes = _context.GenreType.ToList()
                };

                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Stock = movie.Stock;
                movieInDb.GenreTypeId = movie.GenreTypeId;
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(MoviesController.Index));
             
        }
    }
}