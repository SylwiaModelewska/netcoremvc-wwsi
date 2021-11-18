using Library.Domain;
using Library.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ConsoleApp
{
    public class OrderService
    {
        private OrdersRepository _orderRepository;

        public OrderService(OrdersRepository repo) 
        {
            _orderRepository = repo;
        }

        public void PlaceOrder()
        {
            var continueProgram = true;
            Order order = new Order();

            while (continueProgram)
            {
                Console.WriteLine("add - dodaj pozycję do zamówienia\nend - zamknij zamowienie");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "add":
                        BookOrdered book = new BookOrdered();
                        Console.WriteLine("Podaj ID książki: ");
                        book.BookID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Podaj ilość: ");
                        book.NumerOrdered = Convert.ToInt32(Console.ReadLine());

                        order.AddOrder(book);

                        break;

                    case "end":
                        _orderRepository.Insert(order);
                        continueProgram = false;
                    break;

                    default:
                        Console.WriteLine("Nieprawidłowa komenda!");
                    break;
                }
            }
        }

        public void ListAll()
        {
            var orders = _orderRepository.GetAll();

            foreach(var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }
    }
}
