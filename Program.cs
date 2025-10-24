
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LIBRARY MANAGEMENT SYSTEM ");
            Console.WriteLine("OOP Principles Demonstration:");

            Library library = new Library("University Library", "Main Campus");

            IBook novel = new Novel("NOV001", "The Days", "Taha Hussein", 1929, "Autobiography");
              IBook textbook = new Textbook("TXT001", "Introduction to OOP", "DrAhmed", 2023, "Computer Science");
            IBook research = new ResearchPaper("RES001", "AI in Education", "DrFatima", 2024, "Tech Conference");

        
            library.AddBook((AbstractBook)novel);
            library.AddBook((AbstractBook)textbook);
            library.AddBook((AbstractBook)research);

            
            Console.WriteLine("1. POLYMORPHISM - Display All Books:");
            Console.WriteLine("________________________");
              library.DisplayAllBooks();


            Console.WriteLine("\n2. ENCAPSULATION & EVENTS - Borrow/Return:");
            novel.Borrow("STU001");
            textbook.Borrow("STU002");
            novel.Return();

           
            Console.WriteLine(" STATIC MEMBERS Statistics:");
          Console.WriteLine($"Total books created: {AbstractBook.TotalBooksCreated}");
            Console.WriteLine($"Is valid title 'C#': {Validator.IsValidTitle("C#")}");

            
              Console.WriteLine(" SEARCH WITH POLYMORPHISM:");
            var results = library.SearchBooks("Education");
            Console.WriteLine($"Found {results.Count} books");
            Console.ReadLine();
        }
    }


    public static class Validator
    {
        public static bool IsValidTitle(string title)
        {
            return !string.IsNullOrWhiteSpace(title) && title.Length >= 2;
        }

        public static bool IsValidAuthor(string author)
        {
            return !string.IsNullOrWhiteSpace(author) && author.Length >= 3;
        }

        public static bool IsValidYear(int year)
        {
            return year >= 1000 && year <= DateTime.Now.Year + 1;
        }
    }
}