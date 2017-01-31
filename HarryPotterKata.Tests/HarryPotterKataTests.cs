using System;
using System.Collections.Generic;
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
    }
}
