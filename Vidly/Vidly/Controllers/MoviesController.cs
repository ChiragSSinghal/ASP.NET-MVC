using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.ID == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.ID == movie.ID);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreID = movie.GenreID;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieViewModel()
            {
                Movie = new Movie(),
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult DelResult(int ID)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.ID == ID);
            if (movie == null)
            {
                return View("Index");
            }
            else
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
                var movies = _context.Movies.Include(c => c.Genre).ToList();
                return View("Index", movies);
            }
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
    }
}