using System.Collections.Generic;

namespace HarryPotterKata
{
    public class ShoppingCart
    {
        private readonly List<Book> _books = new List<Book>();
        private const int BookPrice = 8;

        public ShoppingCart(Book book)
        {
            _books.Add(book);
        }

        public ShoppingCart(List<Book> bookList)
        {
            _books = bookList;
        }

        public ShoppingCart()
        {
            
        }

        public double Price()
        {
            var numberOfDistinctBooks = DistinctBooksCount();

            if (numberOfDistinctBooks == 2)
            {
                return _books.Count * BookPrice * .95;
            }
            return _books.Count * BookPrice;
        }

        private int DistinctBooksCount()
        {
            var distinctBooks = new HashSet<Book>(_books);
            return distinctBooks.Count;
        }
    }
}