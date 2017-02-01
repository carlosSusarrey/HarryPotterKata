namespace HarryPotterKata
{
    public class ShoppingCart
    {
        private Book book;

        public ShoppingCart(Book book)
        {
            this.book = book;
        }

        public ShoppingCart()
        {
            
        }

        public int Price()
        {
            return book != null ? 8 : 0;
        }
    }
}