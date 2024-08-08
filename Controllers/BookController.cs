using BinarTestMandiri.Models;
using BinarTestMandiri.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BinarTestMandiri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var books = _bookRepository.GetAllBooks();
            return new OkObjectResult(books);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var book = _bookRepository.GetBookById(id);
            return new OkObjectResult(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            using (var scope = new TransactionScope())
            {
                _bookRepository.InsertBook(book);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book != null)
            {
                using (var scope = new TransactionScope())
                {
                    _bookRepository.UpdateBook(book);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookRepository.DeleteBook(id);
            return new OkResult();
        }
    }
}
