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
            
            return View(_movieService.GetAll());
        }

        public IActionResult Details(int id)
        {
            Movie m = _movieService.GetById(id);
            return View(m);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.Create(movie);
                return RedirectToAction("Liste");
            }
            return View(movie);
        }

        /*
         Mettre en place le formulaire de mise à jour d'un film
            => L'action en HttpPost pour enregistrer les modif quand on a cliqué sur Valider
            => La méthode de service Edit qui fait la mise à jour dans la liste
            => La vu qui présente le formulaire prérempli avec les données du film à éditer
         */

        //Afficher le formulaire prérempli sur base d'un id
        public IActionResult Edit(int id)
        {
            Movie aModifier = _movieService.GetById(id);
            return View(aModifier);
        }

        //Action entreprise quand je clique sur Valider dans le formulaire
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if(ModelState.IsValid)
            {
                _movieService.Edit(movie);
                return RedirectToAction("Liste");
            }
            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return RedirectToAction("Liste");
        }
    }
}
