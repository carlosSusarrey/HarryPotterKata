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
        [Fact]
        public void A_ShoppingCart_with_zero_books_is_valued_in_zero_Euros()
        {
            var myCart = new ShoppingCart();
            myCart.Price().Should().Be(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void A_ShoppingCart_with_any_one_book_Price_is_8(int bookNumber)
        {
            var myCart = new ShoppingCart(new Book(bookNumber));
            myCart.Price().Should().Be(8);
        }

        [Fact]
        public void Two_of_the_same_book_Price_is_16()
        {
            var myCart = new ShoppingCart(new List<Book> {new Book(1), new Book(1)});
            myCart.Price().Should().Be(16);
        }

    }
}
