using System;
using System.Collections.Generic;

namespace Stor_E_Books.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public decimal CartPriceTotal { get; set; }

    public int CartQuantity { get; set; }

    public int? BookId { get; set; }

    public virtual Item? Book { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual ICollection<CartOrder> CartOrders { get; set; } = new List<CartOrder>();
}
