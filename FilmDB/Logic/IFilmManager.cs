using FilmDB.Models;
using System.Collections.Generic;

namespace FilmDB
{
    public interface IFilmManager
    {
        void AddFilm(FilmModel filmModel);
        void ChangeTitle(int id, string newTitle);
        FilmModel GetFilm(int id);
        List<FilmModel> GetFilms();
        void RemoveFilm(int id);
        void UpdateFilm(FilmModel filmModel);
    }
}