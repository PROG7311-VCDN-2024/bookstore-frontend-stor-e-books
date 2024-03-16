using Microsoft.Build.Evaluation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stor_E_Books.Models
{
    [Table("Book")]
    public class Book
    {
      
        public int id { get; set; }

        [Required]
        [MaxLength(40)]

        public string? BookName { get; set; }
        [Required]
        public double  Price { get; set; }
        public string  Image { get; set; }
        [Required]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }

        public List<CartDetail> CartDetail { get; set; }
        [NotMapped]
        public string GenreName { get; set; }
    }
}
