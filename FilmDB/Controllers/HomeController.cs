using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FilmDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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



        [HttpGet]
        public IActionResult Remove(int id)
        {
            FilmManager filmManager = new FilmManager();
            return View(filmManager.GetFilm(id));
        }

        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            FilmManager filmManager = new FilmManager();
            FilmModel filmModel = new FilmModel();
            filmModel = filmManager.GetFilm(id);

            if(filmModel != null)
            {
                filmManager.RemoveFilm(id);
            }       
                return View("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            FilmManager filmManager = new FilmManager();
            return View(filmManager.GetFilm(id));
        }

        [HttpPost]
        public IActionResult Edit(FilmModel filmModel)
        {
            return View();
        }
    }
}
