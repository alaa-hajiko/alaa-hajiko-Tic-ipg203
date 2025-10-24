using System;

namespace LibraryManagementSystem
{
    public interface IBook
    {
        string Id { get; }
        string Title { get; }
        string Author { get; }
        int Year { get; }
        bool IsAvailable { get; }

        void DisplayInfo();
        void Borrow(string borrowerId);
        void Return();
    }
    public delegate void BookEventHandler(object sender, BookEventArgs e);
    public class BookEventArgs : EventArgs
    {
        public IBook Book { get; }
        public string BorrowerId { get; }
        public DateTime EventTime { get; }

        public BookEventArgs(IBook book, string borrowerId, DateTime eventTime)
        {
            Book = book;
            BorrowerId = borrowerId;
            EventTime = eventTime;
        }
    }
}