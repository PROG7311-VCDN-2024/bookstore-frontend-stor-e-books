using System;
using System.Collections.Generic;

namespace Stor_E_Books.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public decimal OrderPriceTotal { get; set; }

    public DateOnly Date { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public int OrderQuantity { get; set; }

    public int? BookId { get; set; }

    public int? CustomerId { get; set; }

    public virtual Item? Book { get; set; }

    public virtual ICollection<CartOrder> CartOrders { get; set; } = new List<CartOrder>();

    public virtual Customer? Customer { get; set; }
}
