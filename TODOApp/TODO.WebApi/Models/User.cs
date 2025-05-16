using System.ComponentModel.DataAnnotations;

namespace TODO.WebApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public required string FirstName { get; set; }  // Nombre

        [Required]
        public required string LastName { get; set; }   // Apellido

        [Required]
        [EmailAddress]
        public required string Email { get; set; }      // Correo electrónico

        [Required]
        public required string PasswordHash { get; set; }  // Contraseña (almacenar hasheada)

        // Relación: un usuario tiene muchos libros
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
