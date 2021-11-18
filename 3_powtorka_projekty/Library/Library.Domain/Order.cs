using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain
{
    public class Order
    {
        DateTime Date { get; set; }
        List<BookOrdered> BooksOrderedList { get; set; }

        public Order()
        {
            Date = DateTime.Now;
            BooksOrderedList = new List<BookOrdered>();
        }

        public override string ToString()
        {
            string order = $"Order: {Date} ";
            order += Environment.NewLine;

            foreach(var bookOrdered in BooksOrderedList)
            {
                order += $"Book: {bookOrdered.BookID} IloscZamowionych: {bookOrdered.NumerOrdered}";
                order += Environment.NewLine;
            }

            return order;

        }

        public void AddOrder(BookOrdered book)
        {
            BooksOrderedList.Add(book);
        }
    }
}
