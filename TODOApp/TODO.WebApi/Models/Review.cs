using System.ComponentModel.DataAnnotations;

namespace TODO.WebApi.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }  // Calificación 1-5 estrellas

        public string Comment { get; set; } // Reseña escrita (opcional)

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // FK a Book
        public int BookId { get; set; }
        public Book? Book { get; set; }

        // FK a User que hizo la reseña
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
