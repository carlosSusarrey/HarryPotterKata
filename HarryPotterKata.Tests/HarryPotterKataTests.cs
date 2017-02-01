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
        public void A_Shopping_cart_with_zero_books_is_valued_in_zero_Euros()
        {
            var myCart = new ShoppingCart();
            myCart.Price().Should().Be(0);
        }

        [Fact]
        public void A_shopping_cart_with_any_one_book_Price_is_8()
        {
            var myCart = new ShoppingCart(new Book(1));
            myCart.Price().Should().Be(8);
        }

    }
}
