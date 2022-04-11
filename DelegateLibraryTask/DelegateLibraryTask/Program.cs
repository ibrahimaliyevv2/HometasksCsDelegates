using System;
using System.Collections.Generic;
using Models;
using Utilities.Enums;

namespace DelegateLibraryTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library1 = new Library();

            Console.WriteLine("Nece kitab elave etmek isteyirsiniz?");
            int countOfBooks = int.Parse(Console.ReadLine());
            int i = 1;

            while (countOfBooks > 0 && i<countOfBooks)
            {
                Console.WriteLine(i + "-ci kitabin adini daxil edin: ");
                string name = Console.ReadLine();

                Console.WriteLine(i + "-ci kitabin muellifini daxil edin: ");
                string authorName = Console.ReadLine();

                Console.WriteLine(i + "-ci kitabin qiymetini daxil edin: ");
                double price = double.Parse(Console.ReadLine());

                Book book = new Book(name, authorName, price);

                Console.WriteLine(i + "-ci kitabin janrini daxil edin:");
                foreach (var item in Enum.GetValues(typeof(TypeGenre)))
                {
                    Console.WriteLine((byte)item + " - " + item);
                }

                Console.WriteLine("Secim edin:");
                string typeStr = Console.ReadLine();
                byte typeByte;

                while (!byte.TryParse(typeStr, out typeByte))
                {
                    Console.WriteLine("Janrin nomresini daxil edin:");
                    typeStr = Console.ReadLine();
                }
                while (!Enum.IsDefined(typeof(TypeGenre), typeByte))
                {
                    Console.WriteLine("Dogru daxil edin");
                    typeStr = Console.ReadLine();
                    while (!byte.TryParse(typeStr, out typeByte))
                    {
                        Console.WriteLine("Eded daxil edin: ");
                        typeStr = Console.ReadLine();
                    }
                    typeByte = Convert.ToByte(typeStr);
                }

                TypeGenre selectedGenre = (TypeGenre)typeByte;

                book.Genre = selectedGenre;

                library1.AddNewBook(book);
                i++;
            }


            foreach (var item in library1.FilterByPrice(10, 20))
            {
                Console.WriteLine($"{item.No} - {item.Name} - {item.AuthorName} - {item.Genre} - {item.Price}");
            }

            foreach (var item in library1.FilterByGenre(TypeGenre.Horror))
            {
                Console.WriteLine($"{item.No} - {item.Name} - {item.AuthorName} - {item.Genre} - {item.Price}");
            }

            Book findedBook = library1.FindBookByNo(2);
            Console.WriteLine(findedBook.Name);
            Console.WriteLine(library1.IsExistByNo(1));

            List<Book> RemovedBooks = library1.RemoveAll(x => x.Price >= 15);

            foreach (var item in RemovedBooks)
            {
                Console.WriteLine($"{item.No} - {item.Name} - {item.AuthorName} - {item.Genre} - {item.Price}");
            }
        }
    }
}
