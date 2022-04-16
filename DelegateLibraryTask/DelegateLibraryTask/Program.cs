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
            Library kitabxana = new Library();

            Console.WriteLine("Nece kitab elave etmek isteyirsiniz?");
            int countOfBooks = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfBooks; i++)
            {
                Console.WriteLine($"{i + 1}-ci kitabin adini daxil edin:");
                string name = Console.ReadLine();
                Console.WriteLine($"{i + 1}-ci kitabin muellifinin adini daxil edin:");
                string authorName = Console.ReadLine();
                Console.WriteLine($"{i + 1}-ci kitabin qiymetini daxil edin:");
                double price = double.Parse(Console.ReadLine());
                foreach (var item in Enum.GetValues(typeof(TypeGenre)))
                {
                    Console.WriteLine($"{(byte)item} - {item}");
                }
                Console.WriteLine("Zehmet olmasa secim edin:");
                string choose = Console.ReadLine();
                byte choosenByte;

                while (!byte.TryParse(choose, out choosenByte))
                {
                    Console.WriteLine("Yalniz eded daxil edin:");
                    choose = Console.ReadLine();
                }

                while (!Enum.IsDefined(typeof(TypeGenre), choosenByte))
                {
                    Console.WriteLine("Duzgun secim edin:");
                    choose = Console.ReadLine();

                    while (!byte.TryParse(choose, out choosenByte))
                    {
                        Console.WriteLine("Yalniz eded daxil edin:");
                        choose = Console.ReadLine();
                    }
                    choosenByte = Convert.ToByte(choose);
                }

                TypeGenre selectedGenre = (TypeGenre)choosenByte;

                Book book1 = new Book
                {
                    Name = name,
                    AuthorName = authorName,
                    Price = price,
                    Genre = selectedGenre
                };

                kitabxana.Books.Add(book1);
            }

            Console.WriteLine("Filter By price");
            foreach (var item in kitabxana.FilterByPrice(0, 50))
            {
                Console.WriteLine($"{item.Name} {item.AuthorName} {item.Price} {item.Genre}");
            }

            Console.WriteLine("Filter By genre");
            foreach (var item in kitabxana.FilterByGenre(TypeGenre.Horror))
            {
                Console.WriteLine($"{item.Name} {item.AuthorName} {item.Price} {item.Genre}");
            }

            Console.WriteLine("Find Book By No");
            Console.WriteLine(kitabxana.FindBookByNo(1).Name);

            Console.WriteLine("Is exist Book By No");
            Console.WriteLine(kitabxana.isExistBookByNo(2));

            Console.WriteLine("Remove All");
            foreach (var item in kitabxana.RemoveAll(x => x.Price > 20))
            {
                Console.WriteLine($"{item.Name} {item.AuthorName} {item.Price} {item.Genre}");
            }
        }
    }
}
