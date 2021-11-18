using Library.Domain;
using Library.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ConsoleApp
{
    public class BooksService
    {
        public BooksRepository _repository = new BooksRepository();

        public BooksService(BooksRepository book) { }

        public void AddBook()
        {
            Console.WriteLine("Podaj tytuł: ");
            string title = Console.ReadLine();

            Console.WriteLine("Podaj autora: ");
            string author = Console.ReadLine();

            Console.WriteLine("Podaj rok publikacji: ");
            int publicationYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Podaj isbn: ");
            string isbn = Console.ReadLine();

            Console.WriteLine("Podaj liczbę dostępnych egzemplarzy: ");
            int productsAvailable = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Podaj cenę: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Book book = new Book(title, author, publicationYear, isbn, productsAvailable, price);

            _repository.Insert(book);
        }

        public void RemoveBook()
        {
            Console.WriteLine("Podaj tytuł książki do usunięcia: ");
            string title = Console.ReadLine();
            _repository.RemoveByTitle(title);

        }

        public void ListBooks()
        {
            var books = _repository.GetAll();
            
            foreach(var book in books)
            {
                Console.WriteLine(book.Title +",    "+ book.Author +",    "+ book.PublicationYear + ",    "+ book.ISBN + ",    "+ book.ProductsAvailable + ",    "+ book.Price);
            }
        }

        public void ChangeState()
        {
            Console.WriteLine("Podaj tytuł książki, której stan chcesz zmienić: ");
            string title = Console.ReadLine();

            Console.WriteLine("Podaj zmianę stanu (np. -1): ");
            int change = Convert.ToInt32(Console.ReadLine()); ;

            _repository.ChangeState(title, change);
        }
    }
}
