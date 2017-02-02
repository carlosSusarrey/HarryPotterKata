using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Wintellect.PowerCollections;

namespace HarryPotterKata
{
    public class ShoppingCart
    {
        private readonly Bag<Book> _books = new Bag<Book>();
        private const int BookPrice = 800;
        private readonly Dictionary<int, double> discountsDictionary = new Dictionary<int, double>
        {
            {1, 0 },
            {2, .05 },
            {3, 0.1 },
            {4, 0.20 },
            {5, 0.25 }
        };

        public double PriceInCents()
        {
            double total = 0;
            var remainingBooks = new Bag<Book>(_books);
            
            while (GetNumberOfBooks(remainingBooks) > 0)
            {
                var numberOfDistinctBooks = GetNumberOfDistinctBooks(remainingBooks);
                total += numberOfDistinctBooks * BookPrice * (1 - discountsDictionary[numberOfDistinctBooks]);
                RemoveOneOfEachBook(remainingBooks);
            }
            return total;
        }

        private static void RemoveOneOfEachBook(ICollection<Book> remainingBooks)
        {
            var distinctBooks = new Bag<Book>(remainingBooks);
            foreach (var book in distinctBooks.DistinctItems())
            {
                remainingBooks.Remove(book);
            }
        }

        private static int GetNumberOfBooks(ICollection books)
        {
            return books.Count;
        }

        private static int GetNumberOfDistinctBooks(Bag<Book> books)
        {
            return books.DistinctItems().Count();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);    
        }
    }
}