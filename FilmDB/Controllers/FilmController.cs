using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmManager _filmManager;

        public FilmController(IFilmManager filmManager)
        {
            _filmManager = filmManager;
        }

        public IActionResult Index()
        {
            var filmModel = _filmManager.GetFilms();

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
            _filmManager.AddFilm(film);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var film = _filmManager.GetFilm(id);
            return View(film);
        }


        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            try
            {
                _filmManager.RemoveFilm(id);
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
            FilmModel filmModel = _filmManager.GetFilm(id);
            return View(filmModel);
        }

        [HttpPost]
        public IActionResult Edit(FilmModel filmModel)
        {
            _filmManager.UpdateFilm(filmModel);
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
