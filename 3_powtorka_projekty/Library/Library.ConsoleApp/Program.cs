using Library.Domain;
using Library.Persistence;
using System;

namespace Library.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Lśnienie", "Stephen King", 1977, "9780385121675", 50, 49.99M);
            BooksRepository repository = new BooksRepository();


            Console.WriteLine("Podaj login");
            string login = Console.ReadLine();

            Console.WriteLine("Podaj hasło");
            string password = Console.ReadLine();

            if (login == "admin" && password == "password")
            {
                Console.WriteLine("Access Granted");
            }
            else
            {
                Console.WriteLine("Access Denied");
            }

            BooksRepository respo = new BooksRepository();
            BooksService booksService = new BooksService(respo);
            OrdersRepository repo = new OrdersRepository();
            OrderService service = new OrderService(repo);

            string input = "a";

            while (input != "wyjdz")
            {
                Console.Clear();

                booksService.ListBooks();
                Console.WriteLine("\nMożliwe komendy do wpisania: \ndodaj,\nusun,\nzmien,\ndodaj zamowienie,\nlista zamowien,\nwyjdz\n");
                input = Console.ReadLine();

                switch (input)
                {
                    case "dodaj":
                        booksService.AddBook();
                    break;

                    case "usun":
                        booksService.RemoveBook();
                    break;

                    case "zmien":
                        booksService.ChangeState();
                    break;

                    case "dodaj zamowienie":
                        service.PlaceOrder();
                    break;

                    case "lista zamowien":
                        service.ListAll();
                    break;

                    case "wyjdz":
                    break;

                    default:
                        Console.WriteLine("Podana komenda nie jest wspierana");
                    break;
                }
                Console.WriteLine("\nPress AnyKey");
                Console.ReadKey();
            }
        }
    }
}