namespace HarryPotterKata
{
    public class Book
    {
        public int BookNumber
        {
            get;
        }
        public Book(int i)
        {
            BookNumber = i;
        }

        public override bool Equals(object obj)
        {
            return obj?.GetType() == typeof(Book) && Equals((Book) obj);
        }

        protected bool Equals(Book other)
        {
            return BookNumber == other.BookNumber;
        }

        public override int GetHashCode()
        {
            return BookNumber;
        }
    }
}