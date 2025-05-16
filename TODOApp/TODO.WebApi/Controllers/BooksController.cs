using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TODO.WebApi.Models;

namespace TODO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly TODOAppDbContext _context;

        public BooksController(TODOAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Books?userId=1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks([FromQuery] int userId)
        {
            var books = await _context.Books
                .Where(b => b.UserId == userId)
                .ToListAsync();

            return books.Select(b => new BookDto(b)).ToList();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            return new BookDto(book);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<BookDto>> PostBook(BookCreateDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                PublicationYear = dto.PublicationYear,
                CoverImageUrl = dto.CoverImageUrl,
                UserId = dto.UserId
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, new BookDto(book));
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.PublicationYear = dto.PublicationYear;
            book.CoverImageUrl = dto.CoverImageUrl;

            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    // DTOs para Books
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int? PublicationYear { get; set; }
        public string? CoverImageUrl { get; set; }
        public int UserId { get; set; }

        public BookDto(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            PublicationYear = book.PublicationYear;
            CoverImageUrl = book.CoverImageUrl;
            UserId = book.UserId;
        }
    }

    public class BookCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int? PublicationYear { get; set; }
        public string? CoverImageUrl { get; set; }
        public int UserId { get; set; }
    }

    public class BookUpdateDto : BookCreateDto
    {
        public int Id { get; set; }
    }
}
