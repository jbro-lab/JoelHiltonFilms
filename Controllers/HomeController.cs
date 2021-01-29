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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
         
            if (movie.title.ToLower() != "independence day")
            {
                MovieDB.AddMovie(movie);
            }
            return View("Confirmation", movie);
        }

        public IActionResult Confirmation(Movie movie)
        {
            return View(movie);
        }

        public IActionResult AllMovies()
        {
            return View(MovieDB.Movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
