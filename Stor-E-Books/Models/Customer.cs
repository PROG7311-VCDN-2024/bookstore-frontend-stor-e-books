using System;
using System.Collections.Generic;

namespace Stor_E_Books.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Unsuccessfullogin> Unsuccessfullogins { get; set; } = new List<Unsuccessfullogin>();
}
