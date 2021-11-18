using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            FilmModel filmModel = new FilmModel() { ID = 1, Title = "Shrek", Year = 2001 };

            FilmManager filmManager = new FilmManager();
            filmManager.AddFilm(filmModel);

            return View(filmManager.GetFilms());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new FilmModel());
        }

        [HttpPost]
        public IActionResult Add(FilmModel model)
        {
            return View();
        }
    }
}
