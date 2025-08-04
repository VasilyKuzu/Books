using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Books.Model;
using Books.Data;

namespace Books.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            else return Ok(book);
        }

        [HttpGet("after/{year}")]
        public async Task<ActionResult<List<Book>>> GetAllAfterYear(int year)
        {
            var books = await _context.Books.Where(b => b.Year > year).ToListAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return Ok(book);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Update(int id, Book updatedBook)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Year = updatedBook.Year;


            await _context.SaveChangesAsync();
            return Ok(book);
        }
    }
}
