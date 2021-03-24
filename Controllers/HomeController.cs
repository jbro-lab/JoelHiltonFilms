using JoelHiltonFilms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHiltonFilms.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieDbContext _context;

        public HomeController(ILogger<HomeController> logger, MovieDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()//Home response for Index view
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]//httpget response for NewMovie view
        public IActionResult NewMovie()
        {
            return View();
        }

        [HttpPost]//httppost response for NewMovie view
        public IActionResult NewMovie(Movie movie)
        {
            //checks model to make sure its valid
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Confirmation", movie);
            }
            
            
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int movieId)
        {
            //for the HTtp Get request, couldn't figure how to do it with post
            return View(_context.Movies.Where(m => m.movieId == movieId).FirstOrDefault());
        }
       
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            //edits movie if model State is valid, if not just returns to Edit page
            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("AllMovies");
            }
            
            return View();
        }

       public IActionResult Podcasts()
        {//for returning Podcasts page
            return View();
        }
       

        public IActionResult Delete(int movieId)
        {//for deleting movies
            Movie movie = _context.Movies.Where(m => m.movieId == movieId).FirstOrDefault();
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("AllMovies");
        }

        public IActionResult Confirmation(Movie movie)
        {
            //for confirming you have added a movie
            
            return View(movie);
        }

        public IActionResult AllMovies()
        {
            //returns all ovies except for independence day cuz it's trash
            return View(_context.Movies.Where(m => m.title.ToLower() != "independence day"));
        }

        public IActionResult IndyDay()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
