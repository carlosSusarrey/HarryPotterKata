using System.Collections.Generic;

namespace HarryPotterKata
{
    public class ShoppingCart
    {
        private List<Book> _books;

        public ShoppingCart(Book book)
        {
            _books = new List<Book> {book};
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
            if (_books.Count == 0)
            {
                return 0;
            }
            return _books.Count * 8;
        }
    }
}