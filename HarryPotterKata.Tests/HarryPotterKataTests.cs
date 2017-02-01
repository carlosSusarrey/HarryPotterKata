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
            _myCart.Price().Should().Be(expected);
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
            CartPriceShouldBe(8);
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
            CartPriceShouldBe(16);
        }

        [Fact]
        public void Two_different_books_receive_5_percent_discount()
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            CartPriceShouldBe(8 * 2 * .95);
        }

        [Fact]
        public void Two_different_books_twice_receive_5_percent_discount()
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            CartPriceShouldBe(8 * 4 * .95);
        }

        [Fact]
        public void Three_books_one_duplicated_receives_5_percent_discount()
        {
            SetUpEmptyCart();
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(1));
            _myCart.AddBook(new Book(2));
            CartPriceShouldBe((8*2*.95)+8);
        }
    }
}
