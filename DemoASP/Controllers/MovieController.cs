using DemoASP.Models;
using DemoASP.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoASP.Controllers
{
    public class MovieController : Controller
    {
        private MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Liste()
        {
            
            return View(_movieService.maListe);
        }

        public IActionResult Details(int id)
        {
            Movie m = _movieService.maListe.Where(f => f.Id == id).SingleOrDefault();
            return View(m);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            movie.Id = _movieService.maListe.Max(s => s.Id) + 1;
            _movieService.maListe.Add(movie);
            return RedirectToAction("Liste");
        }
    }
}
