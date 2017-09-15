using Fiver.Mvc.ModelBinding.Custom.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Fiver.Mvc.ModelBinding.Custom.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<MovieViewModel> model = GetMovies();
            return View(model);
        }

        public IActionResult Details(MovieInputModel model)
        {
            return Content(model.Id);
        }

        public List<MovieViewModel> GetMovies()
        {
            return new List<MovieViewModel>
            {
                new MovieViewModel { Id = "1", Title = "Never Say Never Again", ReleaseYear = 1983, Summary = "A SPECTRE agent has stolen two American nuclear warheads, and James Bond must find their targets before they are detonated." },
                new MovieViewModel { Id = "2", Title = "Diamonds Are Forever ", ReleaseYear = 1971, Summary = "A diamond smuggling investigation leads James Bond to Las Vegas, where he uncovers an evil plot involving a rich business tycoon." },
                new MovieViewModel { Id = "3", Title = "You Only Live Twice ", ReleaseYear = 1967, Summary = "Agent 007 and the Japanese secret service ninja force must find and stop the true culprit of a series of spacejackings before nuclear war is provoked." }
            };
        }
    }
}
