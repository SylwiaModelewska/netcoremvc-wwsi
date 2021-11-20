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
            FilmManager filmManager = new FilmManager();
            FilmModel filmModel = new FilmModel();
            
            //filmModel.ID = 1;
            //filmModel.Title = "Titanic";
            //filmModel.Year = 1998;
            
            //filmManager.AddFilm(filmModel);
            //filmManager.RemoveFilm(1);

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
