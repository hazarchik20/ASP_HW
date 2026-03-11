using BookShop.FakeStorage.Models;

namespace BookShop.FakeStorage
{
    public class FakeBookStorage
    {
        private readonly List<Book> _books;
       
        public FakeBookStorage()
        {
            _books = new List<Book>
            {
                new Book
                {
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    Price = 10.99m,
                    ImageUrl = "https://covers.openlibrary.org/b/id/7222246-L.jpg"
                },
                new Book
                {
                    Title = "Sapiens: A Brief History of Humankind",
                    Author = "Yuval Noah Harari",
                    Price = 14.99m,
                    ImageUrl = "https://covers.openlibrary.org/b/id/8370226-L.jpg"
                },
                new Book
                {
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Price = 9.99m,
                    ImageUrl = "https://covers.openlibrary.org/b/id/8228691-L.jpg"
                },
                new Book
                {
                    Title = "Educated",
                    Author = "Tara Westover",
                    Price = 12.99m,
                    ImageUrl = "https://covers.openlibrary.org/b/id/9259251-L.jpg"
                }
            };
        }
        public List<Book> GetBooks(int limit, int offset)
        {
            return _books.Skip(offset).Take(limit).ToList();

        }
        public Book GetBookByTitle(string title)
        {
            return _books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
        public Book GetBookById(int id)
        {
            return _books[id];
        }
        public void AddBook(Book book)
        {
            _books.Add(book);
        }
        public void RemoveBook(string title)
        {
            var book = GetBookByTitle(title);
            if (book != null)
            {
                _books.Remove(book);
            }
        }
        public void UpdateBook(int id, Book updatedBook)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Price = updatedBook.Price;
                book.ImageUrl = updatedBook.ImageUrl;
            }
        }
    }
}
