using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Stor_E_Books.Models
{
    [Table("Genre")]
    public class Genre
    {
      
    
            public int id { get; set; }

            [Required]
            [MaxLength(40)]

            public string GenreName { get; set; }

            public List<Book> Books { get; set; }
        
    }
}

