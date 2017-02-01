using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace HarryPotterKata
{
    public class ShoppingCart
    {
        private readonly Dictionary<Book, int> _books = new Dictionary<Book, int>();
        private const int BookPrice = 8;

        public ShoppingCart()
        {
            
        }

        public double Price()
        {
            var total = 0.0;
            var remainingBooks = _books;
            
            while (GetNumberOfBooks(remainingBooks) > 0)
            {
                var numberOfDistinctBooks = GetNumberOfDistinctBooks(remainingBooks);
                if (numberOfDistinctBooks == 2)
                    total += 2 * BookPrice * .95;
                else
                    total +=  BookPrice;

                RemoveOneOfEachBook(remainingBooks);
            }
            return total;
        }

        private static void RemoveOneOfEachBook(Dictionary<Book, int> remainingBooks)
        {
            if (remainingBooks == null) throw new ArgumentNullException(nameof(remainingBooks));
            var distinctBooks = new Dictionary<Book, int>(remainingBooks);
            foreach (var book in distinctBooks.Keys)
            {
                if (remainingBooks[book] == 1)
                {
                    remainingBooks.Remove(book);
                }
                else
                {
                    remainingBooks[book] -= 1;
                }
            }
        }

        private static int GetNumberOfBooks(Dictionary<Book, int> books)
        {
            return books.Values.Sum(x => x);
        }

        private static int GetNumberOfDistinctBooks(Dictionary<Book, int> books)
        {
            return books.Count;
        }

        public void AddBook(Book book)
        {
            if (_books.ContainsKey(book))
            {
                _books[book] += 1;
            }
            else
            {
                _books.Add(book, 1);
            }
            
        }
    }
}