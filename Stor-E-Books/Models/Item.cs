using System;
using System.Collections.Generic;

namespace Stor_E_Books.Models;

public partial class Item
{
    public int BookId { get; set; }

    public string BookName { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
