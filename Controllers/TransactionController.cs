using BinarTestMandiri.Models;
using BinarTestMandiri.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BinarTestMandiri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var transactions = _transactionRepository.GetAllTransactions();
            return new OkObjectResult(transactions);
        }

        [HttpGet("{id}", Name = "GetTrans")]
        public IActionResult Get(int id)
        {
            var transaction = _transactionRepository.GetTransactionById(id);
            return new OkObjectResult(transaction);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Models.Transaction transaction)
        {
            using (var scope = new TransactionScope())
            {
                _transactionRepository.InsertTransaction(transaction);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = transaction.Id }, transaction);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Models.Transaction transaction)
        {
            if (transaction != null)
            {
                using (var scope = new TransactionScope())
                {
                    _transactionRepository.UpdateTransaction(transaction);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _transactionRepository.DeleteTransaction(id);
            return new OkResult();
        }
    }
}
