namespace LibraryManagementSystem
{
    public class Library
    {
        private List<AbstractBook> _books;
        private List<string> _activityLog;

        public string Name { get; set; }
        public string Location { get; set; }
        public static int TotalLibraries { get; private set; }

        public Library(string name = "Main Library", string location = "Campus")
        {
            Name = name;
            Location = location;
            _books = new List<AbstractBook>();
            _activityLog = new List<string>();
            TotalLibraries++;
        }
        public IReadOnlyList<AbstractBook> Books => _books.AsReadOnly();

        public void AddBook(AbstractBook book)
        {
            _books.Add(book);

        
            book.BookBorrowed += OnBookBorrowed;
            book.BookReturned += OnBookReturned;

            LogActivity($"Added: {book.Title} ({book.GetBookType()})");
        }


        public void DisplayAllBooks()
        {
            Console.WriteLine($"\n📚 All Books in {Name}:");
            foreach (var book in _books)
            {
                book.DisplayInfo(); 
             
            }
        }

        public List<AbstractBook> SearchBooks(string keyword)
        {
            return _books.Where(book =>
                book.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                book.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                book.GetBookType().Contains(keyword, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

 
        private void OnBookBorrowed(object sender, BookEventArgs e)
        {
            string message = $"Borrowed: {e.Book.Title} by {e.BorrowerId}";
            LogActivity(message);
            Console.WriteLine($"EVENT: {message}");
        }

        private void OnBookReturned(object sender, BookEventArgs e)
        {
            string message = $"Returned: {e.Book.Title}";
            LogActivity(message);
            Console.WriteLine($"EVENT: {message}");
        }

        private void LogActivity(string activity)
        {
            _activityLog.Add($"{DateTime.Now:HH:mm:ss} - {activity}");
        }

        public void DisplayStats()
        {
Console.WriteLine($" Library Statistics:");
 Console.WriteLine($" Books: {_books.Count}");
         Console.WriteLine($"Novels: {_books.OfType<Novel>().Count()}");
            Console.WriteLine($" Textbooks: {_books.OfType<Textbook>().Count()}");
   Console.WriteLine($" Research Papers: {_books.OfType<ResearchPaper>().Count()}");
            Console.WriteLine($" Available: {_books.Count(b => b.IsAvailable)}");
            Console.WriteLine($"Borrowed: {_books.Count(b => !b.IsAvailable)}");
        }
    }
}