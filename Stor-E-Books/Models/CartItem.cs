using System;
using System.Collections.Generic;

namespace Stor_E_Books.Models;

public partial class CartItem
{
    public int CartItemId { get; set; }

    public int? CartId { get; set; }

    public int? BookId { get; set; }

    public virtual Item? Book { get; set; }

    public virtual Cart? Cart { get; set; }
}
