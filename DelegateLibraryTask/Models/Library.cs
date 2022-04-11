using System;
using System.Collections.Generic;
using Utilities.Enums;

namespace Models
{
    public class Library
    {
        List<Book> Books = new List<Book>();

        public List<Book> FilterByPrice(double min, double max)
        {
            List<Book> BooksForPrice = new List<Book>();

            foreach (Book book in Books)
            {
                if (book.Price>min && book.Price<max)
                {
                    BooksForPrice.Add(book);
                }
            }
            return BooksForPrice;    
        }

        public List<Book> FilterByGenre(TypeGenre genre)
        {
            List<Book> BooksForGenre = new List<Book>();

            foreach (Book book in Books)
            {
                if (book.Genre == genre)
                {
                    BooksForGenre.Add(book);
                }
            }
            return BooksForGenre;
        }

        public Book FindBookByNo(int no)
        {
            foreach (Book book in Books)
            {
                if (book.No == no)
                {
                    return book;
                }
            }
            return null;
        }

        public bool IsExistByNo(int no)
        {
            foreach (Book book in Books)
            {
                if (book.No == no)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Book> RemoveAll(Predicate<Book> predicate)
        {
            List<Book> NotRemovedBooks = new List<Book>();

            foreach (Book book in Books)
            {
                if (!(predicate(book)))
                {
                    NotRemovedBooks.Add(book);
                }
            }
            return NotRemovedBooks;
        }

        public void AddNewBook(Book book)
        {
            Books.Add(book);
        }
    }
}
