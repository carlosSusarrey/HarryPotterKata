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

        public int Price()
        {
            return _books.Count * BookPrice;
        }
    }
}