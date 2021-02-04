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
            //checks model to make sure its valid
            if (ModelState.IsValid)
            {
                MovieDB.AddMovie(movie);
                return RedirectToAction("Confirmation", movie);
            }
            
            
            return View();
        }

        public IActionResult Confirmation(Movie movie)
        {
            
            
            return View(movie);
        }

        public IActionResult AllMovies()
        {
            return View(MovieDB.Movies);
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
