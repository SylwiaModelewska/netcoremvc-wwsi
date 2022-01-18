using FilmDB;
using FilmDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmDB
{
    public class FilmManager : IFilmManager
    {
        private readonly FilmContext _filmContext;

        public FilmManager(FilmContext filmContext)
        {
            _filmContext = filmContext;
        }

        //public FilmModel Film { get; set; }


        public void AddFilm(FilmModel filmModel)
        {
            _filmContext.Films.Add(filmModel);

            try
                {
                _filmContext.SaveChanges();
                }
            catch (Exception ex)
                {
                    if (ex is SqlException || ex is DbUpdateException)
                    {
                        filmModel.ID = 0;
                    _filmContext.Films.Add(filmModel);
                        _filmContext.SaveChanges();
                    }
                }
        }

        public void RemoveFilm(int id)
        {
           var filmModel = _filmContext.Films.SingleOrDefault(f => f.ID == id);
           _filmContext.Films.Remove(filmModel);
           _filmContext.SaveChanges();
        }

        public void UpdateFilm(FilmModel filmModel)
        {
          _filmContext.Films.Update(filmModel);
          _filmContext.SaveChanges();

        }

        public void ChangeTitle(int id, string newTitle)
        {
                FilmModel filmModel = _filmContext.Films.Single(f => f.ID == id);

                if (newTitle is null)
                {
                    filmModel.Title = "Brak tytułu";
                }
                else
                {
                    filmModel.Title = newTitle;
                }
                //context.SaveChanges();
                this.UpdateFilm(filmModel);
            
        }

        public FilmModel GetFilm(int id)
        {
                FilmModel filmModel = _filmContext.Films.SingleOrDefault(f => f.ID == id);
                return filmModel;
        }

        public List<FilmModel> GetFilms()
        {
                List<FilmModel> films = _filmContext.Films.ToList<FilmModel>();
                return films;
        }
    }
}
