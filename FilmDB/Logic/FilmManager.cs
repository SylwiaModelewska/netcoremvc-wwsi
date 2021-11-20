using FilmDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmDB
{
    public class FilmManager
    {
        public void AddFilm(FilmModel filmModel)
        {
            using (var context = new FilmContext())
            {
                context.Films.Add(filmModel);

                try
                {
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    if (ex is SqlException || ex is DbUpdateException)
                    {
                        filmModel.ID = 0;
                        context.Films.Add(filmModel);
                        context.SaveChanges();
                    }
                }       
            }
        }

        public void RemoveFilm(int id)
        {
            using (var context = new FilmContext())
            {
                FilmModel filmModel = context.Films.SingleOrDefault(f => f.ID == id);
                context.Films.Remove(filmModel);
                context.SaveChanges();
            }
        }

        public void UpdateFilm(FilmModel filmModel)
        {
            using (var context = new FilmContext())
            {
                context.Films.Update(filmModel);
                context.SaveChanges();
            }
        }

        public void ChangeTitle(int id, string newTitle)
        {
            using (var context = new FilmContext())
            {
                FilmModel filmModel = context.Films.Single(f => f.ID == id);
                
                if(newTitle is null)
                {
                    filmModel.Title = "Brak tytułu";
                }
                else
                {
                    filmModel.Title = newTitle;
                }

                context.SaveChanges();
            }
        }

        public FilmModel GetFilm(int id)
        {
            using (var context = new FilmContext())
            {
                FilmModel filmModel = context.Films.SingleOrDefault(f => f.ID == id);

                return filmModel;
            }
        }

        public List<FilmModel> GetFilms()
        {
            using (var context = new FilmContext())
            {

                List<FilmModel> films = context.Films.ToList();

                return films;
            }
        }
    }
}
