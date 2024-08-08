using BinarTestMandiri.DBContexts;
using BinarTestMandiri.Models;
using BinarTestMandiri.Repository;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BinarTestMandiri.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _dbContext;

        public BookRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteBook(int bookId)
        {
            var book = _dbContext.Books.Find(bookId);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                Save();
            }
        }

        public IEnumerable<object> GetAllBooks()
        {
            var categories = _dbContext.Categories.ToList();
            var books = _dbContext.Books.ToList();
            var query = from book in books
                    join category in categories
                    on book.CategoryId equals category.Id
                    select new
                    {
                        ID = book.Id,
                        Book = book.Title,
                        Category = category.Name,
                        Price = book.Price.ToString("N0"),
                    };

            return query.ToList();
        }

        public Book GetBookById(int bookId)
        {
            return _dbContext.Books.Find(bookId);
        }

        public void InsertBook(Book book)
        {
            var books = _dbContext.Books.Find(book.Id);
            if (books == null)
            {
                _dbContext.Add(book);
                Save();
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            if (book.Id > 0)
            {
                var books = _dbContext.Books.Find(book.Id);
                if (books != null)
                {
                    _dbContext.Entry(book).State = EntityState.Modified;
                    Save();
                }
            }
        }
    }
}
