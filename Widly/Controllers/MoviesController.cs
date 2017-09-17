using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Widly.Models;
using Widly.Views.ViewModel;

namespace Widly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = new List<Movie> {
                new Movie{ Name = "Shrek!" },
                new Movie{ Name = "Sherin!" }
            };
           
            var viewModel = new MovieViewModel();
            viewModel.Movies = movies;
            
            return View(viewModel);
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int? year, int? month)
        {
            return Content(year + "/" + month);
        }
    }
}