
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public abstract class AbstractBook : IBook
    {
        private string _id;
        private string _title;
        private string _author;
        private int _year;
        private bool _isAvailable;
        public string Id { get => _id; private set => _id = value; }
        public string Title { get => _title; set => _title = value; }
        public string Author { get => _author; set => _author = value; }
        public int Year { get => _year; set => _year = value; }
        public bool IsAvailable { get => _isAvailable; protected set => _isAvailable = value; }
        public static int TotalBooksCreated { get; private set; }
        protected AbstractBook(string id, string title, string author, int year)
        {
            Id = id;
            Title = title;
            Author = author;
            Year = year;
            IsAvailable = true;
            TotalBooksCreated++;
        }
        public abstract string GetBookType();
        public abstract void DisplayInfo();
        public virtual void Borrow(string borrowerId)
        {
            if (!IsAvailable)
                throw new InvalidOperationException("Book is not available");

            IsAvailable = false;
            OnBookBorrowed(new BookEventArgs(this, borrowerId, DateTime.Now));
        }

        public virtual void Return()
        {
            IsAvailable = true;
            OnBookReturned(new BookEventArgs(this, "", DateTime.Now));
        }


        public event BookEventHandler BookBorrowed;
        public event BookEventHandler BookReturned;

        protected virtual void OnBookBorrowed(BookEventArgs e)
        {
            BookBorrowed?.Invoke(this, e);
        }

        protected virtual void OnBookReturned(BookEventArgs e)
        {
            BookReturned?.Invoke(this, e);
        }
    }

    public class Novel : AbstractBook
    {
        public string Genre { get; set; }

        public Novel(string id, string title, string author, int year, string genre)
            : base(id, title, author, year)
        {
            Genre = genre;
        }
        public override string GetBookType() => "Novel";

        public override void DisplayInfo()
        {
           Console.WriteLine($" NOVEL: {Title}");
            Console.WriteLine($" Author: {Author}");
            Console.WriteLine($" Year: {Year}");
       Console.WriteLine($"   Genre: {Genre}");
            Console.WriteLine($"  Status: {(IsAvailable ? "Available" : "Borrowed")}");
        }
    }

    public class Textbook : AbstractBook
    {
        public string Subject { get; set; }

        public Textbook(string id, string title, string author, int year, string subject)
            : base(id, title, author, year)
        {
            Subject = subject;
        }
        public override string GetBookType() => "Textbook";

        public override void DisplayInfo()
        {
            Console.WriteLine($"TEXTBOOK: {Title}");
            Console.WriteLine($"  Author: {Author}");
           Console.WriteLine($" Year: {Year}");
            Console.WriteLine($"  Subject: {Subject}");
          Console.WriteLine($"   Status: {(IsAvailable ? "Available" : "Borrowed")}");
        }
        public override void Return()
        {
            base.Return();
            Console.WriteLine($"  Thank you for returning textbook: {Title}");
        }
    }


    public class ResearchPaper : AbstractBook
    {
        public string Conference { get; set; }

        public ResearchPaper(string id, string title, string author, int year, string conference)
            : base(id, title, author, year)
        {
            Conference = conference;
        }
        public override string GetBookType() => "Research Paper";
        public override void DisplayInfo()
        {
            Console.WriteLine($"RESEARCH: {Title}");
            Console.WriteLine($"   Author: {Author}");
            Console.WriteLine($" Year: {Year}");
            Console.WriteLine($"   Conference: {Conference}");
            Console.WriteLine($"Status: {(IsAvailable ? "Available" : "Borrowed")}");
        }
    }
}
