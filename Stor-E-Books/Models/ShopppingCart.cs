using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stor_E_Books.Models
{
    [Table("ShoppingCart")]
    public class ShopppingCart
    {
        public int id { get; set; }

        [Required]
      
        public string UserId { get; set; }
        public bool isDeleted { get; set; } = false;



    }
}
