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
    public class ReviewsController : ControllerBase
    {
        private readonly TODOAppDbContext _context;

        public ReviewsController(TODOAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Reviews?bookId=1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviews([FromQuery] int bookId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.BookId == bookId)
                .Include(r => r.User)
                .ToListAsync();

            return reviews.Select(r => new ReviewDto(r)).ToList();
        }

        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<ReviewDto>> PostReview(ReviewCreateDto dto)
        {
            var review = new Review
            {
                BookId = dto.BookId,
                UserId = dto.UserId,
                Rating = dto.Rating,
                Comment = dto.Comment
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReviews), new { bookId = dto.BookId }, new ReviewDto(review));
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, ReviewUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var review = await _context.Reviews.FindAsync(id);
            if (review == null) return NotFound();

            review.Rating = dto.Rating;
            review.Comment = dto.Comment;

            _context.Entry(review).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null) return NotFound();

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    // DTOs para Reviews
    public class ReviewDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public ReviewDto(Review review)
        {
            Id = review.Id;
            Rating = review.Rating;
            Comment = review.Comment;
            CreatedAt = review.CreatedAt;
            BookId = review.BookId;
            UserId = review.UserId;
            UserName = review.User?.FirstName + " " + review.User?.LastName ?? "Desconocido";
        }
    }

    public class ReviewCreateDto
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }

    public class ReviewUpdateDto : ReviewCreateDto
    {
        public int Id { get; set; }
    }
}

