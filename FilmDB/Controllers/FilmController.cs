using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            var filmManager = new FilmManager();
            var filmModel = filmManager.GetFilms();

            //filmModel.ID = 5;
            //filmModel.Title = "Titanic";
            //filmModel.Year = 1998;

            //filmManager.AddFilm(filmModel);
            //filmManager.RemoveFilm(1);
            //filmManager.UpdateFilm(filmModel);
            //filmManager.ChangeTitle(5, null);

            return View(filmModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(FilmModel film)
        {
            var manager = new FilmManager();
            manager.AddFilm(film);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            FilmManager filmManager = new FilmManager();
            var film = filmManager.GetFilm(id);
            return View(film);
        }


        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            FilmManager filmManager = new FilmManager();
            try
            {
                filmManager.RemoveFilm(id);
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                //var film = filmManager.GetFilm(id);
                //return RedirectToAction(String.Format("Remove/{0}",id));
                return RedirectToAction("Error");            
            }

            //FilmModel filmModel = new FilmModel();
            //filmModel = filmManager.GetFilm(id);

            //if (filmModel != null)
            //{
            //    filmManager.RemoveFilm(id);
            //}
            //return View("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            FilmManager filmManager = new FilmManager();
            FilmModel filmModel = filmManager.GetFilm(id);
            return View(filmModel);
        }

        [HttpPost]
        public IActionResult Edit(FilmModel filmModel)
        {
            FilmManager filmManager = new FilmManager();
            filmManager.UpdateFilm(filmModel);
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
