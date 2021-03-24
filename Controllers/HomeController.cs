using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMoviesRepository _repository;

        public HomeController(ILogger<HomeController> logger, IMoviesRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //Returns Index view
        public IActionResult Index()
        {
            return View();
        }
        //Returns Podcasts view
        public IActionResult Podcasts()
        {
            return View();
        }
        //Returns MovieForm view
        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }
        //Verifies MovieForm view input data is valid, then adds it as a new object to the database, using the code in Models/EFMoviesRepository.cs
        //Returns the MovieList view with the database Movies.
        [HttpPost]
        public IActionResult MovieForm(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _repository.AddMovie(movie);
                return View("MovieList", _repository.Movies);

            }
            return View();
        }
        //Returns the MovieList view with the database Movies.
        public IActionResult MovieList()
        {
            return View(_repository.Movies);
        }
        //Passes in the data from the selected object in the MovieList view when clicking the Edit button.
        //Returns the Edit view with the selected object loaded into the input fields.
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            return View(movie);
        }
        //Verifies Edit view input data is valid, then updates it to the database as the selected object loaded into the Edit page, using the code in Models/EFMoviesRepository.cs
        //Returns the MovieList view with the database Movies.
        [HttpPost]
        public IActionResult EditSave(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateMovie(movie);
                return View("MovieList", _repository.Movies);

            }
            return View();
        }
        //Deletes the selected object from the database, using the code in Models/EFMoviesRepository.cs
        //Returns the MovieList view with the database Movies.
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _repository.DeleteMovie(movie);
            return View("MovieList", _repository.Movies);
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
