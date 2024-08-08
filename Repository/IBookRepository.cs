using BinarTestMandiri.Models;

namespace BinarTestMandiri.Repository
{
    public interface IBookRepository
    {
        IEnumerable<object> GetAllBooks();

        Book GetBookById(int bookId);
        void InsertBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int bookId);
        void Save();
    }
}
