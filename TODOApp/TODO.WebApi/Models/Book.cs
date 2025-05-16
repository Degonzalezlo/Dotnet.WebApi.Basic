using System.ComponentModel.DataAnnotations;


namespace TODO.WebApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }       // Título

        [Required]
        public string Author { get; set; }      // Autor

        public int? PublicationYear { get; set; }  // Año de publicación (opcional)

        public string CoverImageUrl { get; set; }  // URL imagen portada (opcional)

        // FK a User que posee el libro
        public int UserId { get; set; }
        public User User { get; set; }

        // Relación: un libro puede tener muchas reseñas
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
