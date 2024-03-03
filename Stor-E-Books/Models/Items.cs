using System.ComponentModel.DataAnnotations;

namespace Stor_E_Books.Models
{
    public class Items
    {
        public Items(int bookID, string bookName, string author, string genre, int price)
        {
            BookID = bookID;
            BookName = bookName;
            Author = author;
            Genre = genre;
            this.price = price;
        }

        [Key]

        public int BookID { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int price { get; set; }
    }
}
