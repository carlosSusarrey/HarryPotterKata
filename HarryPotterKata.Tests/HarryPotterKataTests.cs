using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Wintellect.PowerCollections;
using Xunit;

namespace HarryPotterKata.Tests
{
    public class HarryPotterKataTests
    {
        private const int BookPrice = 800;

        private void SetUpEmptyCart()
        {
            _myCart = new ShoppingCart();
        }

        private void CartPriceInCentsShouldBe(double expected)
        {
            _myCart.PriceInCents().Should().Be(expected);
        }

        private ShoppingCart _myCart;
        [Fact]
        public void A_ShoppingCart_with_zero_books_is_valued_in_zero_Euros()
        {
            SetUpEmptyCart();
            CartPriceInCentsShouldBe(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void A_ShoppingCart_with_any_one_book_Price_is_8(int bookNumber)
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(bookNumber));
            CartPriceInCentsShouldBe(BookPrice);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Two_of_the_same_book_Price_is_16(int bookNumber)
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(bookNumber));
            _myCart.AddBook(new Book(bookNumber));
            CartPriceInCentsShouldBe(BookPrice*2);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Three_of_the_same_book_Price_is_24(int bookNumber)
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(bookNumber));
            _myCart.AddBook(new Book(bookNumber));
            _myCart.AddBook(new Book(bookNumber));
            CartPriceInCentsShouldBe(BookPrice*3);
        }

        [Fact]
        public void Two_different_books_receive_5_percent_disscount()
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            CartPriceInCentsShouldBe(BookPrice * 2 * .95);
        }

        [Fact]
        public void Two_different_books_twice_receive_5_percent_disscount()
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            CartPriceInCentsShouldBe(BookPrice * 4 * .95);
        }

        [Fact]
        public void Three_books_one_duplicated_receives_5_percent_for_the_pair()
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            CartPriceInCentsShouldBe((BookPrice*2*.95)+800);
        }

        [Fact]
        public void Three_different_books_get_10_percent_disscount()
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            _myCart.AddBook(new Book(3));
            CartPriceInCentsShouldBe(BookPrice * 3 * .90);
        }

        [Fact]
        public void Four_different_books_get_20_percent_disscount()
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            _myCart.AddBook(new Book(3));
            _myCart.AddBook(new Book(4));
            CartPriceInCentsShouldBe(BookPrice*4*.8);
        }

        [Fact]
        public void Four_books_one_duplicated_get_10_percent_disscount_the_first_three()
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            _myCart.AddBook(new Book(3));
            _myCart.AddBook(new Book(1));
            CartPriceInCentsShouldBe((BookPrice*3*.90)+800);
        }

        [Fact]
        public void Five_different_books_receive_25_percent_disscount()
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            _myCart.AddBook(new Book(3));
            _myCart.AddBook(new Book(4));
            _myCart.AddBook(new Book(5));
            CartPriceInCentsShouldBe(BookPrice*5*.75);
        }

        [Fact]
        public void Test_Bag_class()
        {
            var myBooks = new Bag<Book> {new Book(1), new Book(1)};
            myBooks.Count.Should().Be(2);
            myBooks.DistinctItems().Count().Should().Be(1);
            foreach (var book in myBooks)
            {
                book.BookNumber.Should().Be(1);
            }
        }

        [Fact]
        public void
            Eight_books_that_can_be_grouped_as_5_and_3_or_4_and_4_should_be_grouped_as_the_best_disscount_possible()
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            _myCart.AddBook(new Book(2));
            _myCart.AddBook(new Book(3));
            _myCart.AddBook(new Book(3));
            _myCart.AddBook(new Book(4));
            _myCart.AddBook(new Book(5));
            CartPriceInCentsShouldBe(5120);
        }
    }
}
