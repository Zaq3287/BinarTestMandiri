using BinarTestMandiri.DBContexts;
using BinarTestMandiri.Models;
using Microsoft.EntityFrameworkCore;

namespace BinarTestMandiri.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly LibraryContext _dbContext;

        public TransactionRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteTransaction(int transactionId)
        {
            var transaction = _dbContext.Transactions.Find(transactionId);
            if (transaction != null)
            {
                _dbContext.Transactions.Remove(transaction);
                Save();
            }
        }

        public IEnumerable<object> GetAllTransactions()
        {
            var users = _dbContext.Users.ToList();
            var books = _dbContext.Books.ToList();
            var transactions = _dbContext.Transactions.ToList();
            var query = from transaction in transactions
                        join user in users
                        on transaction.UserId equals user.Id
                        join book in books
                        on transaction.BookId equals book.Id
                        select new
                        {
                            ID = transaction.Id,
                            Username = user.Username,
                            Book = book.Title,
                            Price = book.Price.ToString("N0"),
                        };

            return query.ToList();
        }

        public Transaction GetTransactionById(int transactionId)
        {
            return _dbContext.Transactions.Find(transactionId);
        }

        public void InsertTransaction(Transaction transaction)
        {
            var transactions = _dbContext.Transactions.Find(transaction.Id);
            if (transactions == null)
            {
                _dbContext.Add(transaction);
                Save();
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateTransaction(Transaction transaction)
        {
            if (transaction.Id > 0)
            {
                var transactions = _dbContext.Transactions.Find(transaction.Id);
                if (transactions != null)
                {
                    _dbContext.Entry(transaction).State = EntityState.Modified;
                    Save();
                }
            }
        }
    }
}
