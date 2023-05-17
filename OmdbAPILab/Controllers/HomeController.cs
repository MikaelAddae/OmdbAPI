using Microsoft.AspNetCore.Mvc;
using OmdbAPILab.Models;
using System.Diagnostics;

namespace OmdbAPILab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        MoviesDAL moviesAPI = new MoviesDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieSearch()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieSearchForm()
        {

            return View("MovieSearch");

        }

        [HttpPost]
        public IActionResult MovieSearchResults(string title)
        {
            Movie m = moviesAPI.GetMovie(title);
            return View("MovieSearch", m);
            
        }

        public IActionResult MovieNight()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieNightForm()
        {

            return View("MovieNight");

        }

        [HttpPost]
        public IActionResult MovieNightResult(string title1, string title2, string title3)
        {
            Movie m1 = moviesAPI.GetMovie(title1);
            Movie m2 = moviesAPI.GetMovie(title2);
            Movie m3 = moviesAPI.GetMovie(title3);
            List<Movie> results = new List<Movie>() { m1, m2, m3};

            return View("MovieNight", results);

        }

        public IActionResult Privacy()
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