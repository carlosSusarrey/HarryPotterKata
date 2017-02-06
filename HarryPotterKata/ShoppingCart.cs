using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Wintellect.PowerCollections;

namespace HarryPotterKata
{
    public class ShoppingCart
    {
        private readonly Bag<Book> _books = new Bag<Book>();
        private const int BookPrice = 800;
        private readonly Dictionary<int, double> discountsDictionary = new Dictionary<int, double>
        {
            {1, 0 },
            {2, .05 },
            {3, 0.1 },
            {4, 0.20 },
            {5, 0.25 }
        };

        public double PriceInCents()
        {
            var convenientDisscounts = GetMostConvenientSetsOfBooks(_books);

            return convenientDisscounts.Select((disscountCount, i) => BookPrice * (i + 1) * disscountCount * (1 - discountsDictionary[i + 1])).Sum();
        }

        private static int[] GetMostConvenientSetsOfBooks(Bag<Book> books)
        {
            var discountArray = new[] {0,0,0,0,0};
            while (GetNumberOfBooks(books) > 0)
            {
                discountArray[books.DistinctItems().Count() -1] += 1;
                RemoveOneOfEachBook(books);
            }
            while (discountArray[4] > 0 && discountArray[2] > 0)
            {
                discountArray[4]--;
                discountArray[2]--;
                discountArray[3] += 2;
            }
            return discountArray;
        }

        private static void RemoveOneOfEachBook(ICollection<Book> remainingBooks)
        {
            var auxiliaryBagOfBooks = new Bag<Book>(remainingBooks);
            foreach (var book in auxiliaryBagOfBooks.DistinctItems())
            {
                remainingBooks.Remove(book);
            }
        }

        private static int GetNumberOfBooks(ICollection books)
        {
            return books.Count;
        }
        

        public void AddBook(Book book)
        {
            _books.Add(book);    
        }
    }
}