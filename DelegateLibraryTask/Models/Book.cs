using System;
using Utilities.Enums;
namespace Models
{

    public class Book
    {
        private static int _no;

        public Book(string name, string authorName, double price)
        {
            Name = name;
            AuthorName = authorName;
            Price = price;
            _no++;
            No = _no;
        }

        public int No { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public TypeGenre Genre { get; set; }
        public double Price { get; set; }
    }
}
