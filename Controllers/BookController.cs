using Microsoft.AspNetCore.Mvc;
using LearningController2.Model;

namespace LearningController2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private static List<Book> _book = new List<Book>();

        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            return Ok(_book);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id)
        {
            var result = _book.FirstOrDefault(p => p.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            else return Ok(result);
        }

        [HttpPost]
        public ActionResult<Book> Create(Book book)
        {
            _book.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            var result = _book.FirstOrDefault(p => p.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                _book.Remove(result);
                return Ok(result);
            }
        }
    }
}
