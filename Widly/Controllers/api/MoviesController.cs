using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Widly.Dtos;
using Widly.Models;
using Widly.Models.IdentityModels;

namespace Widly.Controllers.api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _applicationDbContext;

        public MoviesController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        // GET: api/Movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _applicationDbContext.Movies.
                Include(g=>g.GenreType).ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        // GET: api/Movies/5
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _applicationDbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();


            return Ok(Mapper.Map<Movie,MovieDto>(movie));
        }

        // POST: api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _applicationDbContext.Movies.Add(movie);
            _applicationDbContext.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }

        // PUT: api/Movies/5
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _applicationDbContext.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);

            _applicationDbContext.SaveChanges();
        }

        // DELETE: api/Movies/5
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _applicationDbContext.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _applicationDbContext.Movies.Remove(movieInDb);
            _applicationDbContext.SaveChanges();
        }
    }
}
