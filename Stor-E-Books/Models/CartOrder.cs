using System;
using System.Collections.Generic;

namespace Stor_E_Books.Models;

public partial class CartOrder
{
    public int CartOrderId { get; set; }

    public int? CartId { get; set; }

    public int? OrderId { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Order? Order { get; set; }
}
