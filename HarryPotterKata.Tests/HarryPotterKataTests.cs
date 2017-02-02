using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace HarryPotterKata.Tests
{
    public class HarryPotterKataTests
    {
        private void SetUpEmptyCart()
        {
            _myCart = new ShoppingCart();
        }

        private void CartPriceShouldBe(double expected)
        {
            _myCart.PriceInCents().Should().Be(expected);
        }

        private ShoppingCart _myCart;
        [Fact]
        public void A_ShoppingCart_with_zero_books_is_valued_in_zero_Euros()
        {
            SetUpEmptyCart();
            CartPriceShouldBe(0);
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
            CartPriceShouldBe(800);
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
            CartPriceShouldBe(1600);
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
            CartPriceShouldBe(2400);
        }

        [Fact]
        public void Two_different_books_receive_5_percent_disscount()
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            CartPriceShouldBe(800 * 2 * .95);
        }

        [Fact]
        public void Two_different_books_twice_receive_5_percent_disscount()
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            CartPriceShouldBe(800 * 4 * .95);
        }

        [Fact]
        public void Three_books_one_duplicated_receives_5_percent_for_the_pair()
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            CartPriceShouldBe((800*2*.95)+800);
        }

        [Fact]
        public void Three_different_books_get_10_percent_disscount()
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            _myCart.AddBook(new Book(3));
            CartPriceShouldBe(800 * 3 * .90);
        }

        [Fact]
        public void Four_different_books_get_20_percent_disscount()
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            _myCart.AddBook(new Book(3));
            _myCart.AddBook(new Book(4));
            CartPriceShouldBe(800*4*.8);
        }
    }
}
