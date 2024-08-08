using BinarTestMandiri.Models;

namespace BinarTestMandiri.Repository
{
    public interface ITransactionRepository
    {
        IEnumerable<object> GetAllTransactions();

        Transaction GetTransactionById(int transactionId);
        void InsertTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(int transactionId);
        void Save();
    }
}
