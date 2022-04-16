using System;
using System.Collections.Generic;
using Utilities.Enums;

namespace Models
{
    public class Library
    {
        public List<Book> Books = new List<Book>();

        public List<Book> FilterByPrice(double min, double max)
        {
            return Books.FindAll(b => b.Price > min && b.Price < max);
        }

        public List<Book> FilterByGenre(TypeGenre genre)
        {
            return Books.FindAll(b => b.Genre == genre);
        }

        public Book FindBookByNo(int no)
        {
            return Books.Find(b => b.No == no);
            //return null;
        }

        public bool isExistBookByNo(int no)
        {
            return Books.Exists(b => b.No == no);
        }

        public List<Book> RemoveAll(Predicate<Book> predicate)
        {
            List<Book> NewBooks = new List<Book>();
            foreach (Book book in Books)
            {
                if (!predicate(book))
                {
                    NewBooks.Add(book);
                }
            }
            return NewBooks;
        }
    }
}
