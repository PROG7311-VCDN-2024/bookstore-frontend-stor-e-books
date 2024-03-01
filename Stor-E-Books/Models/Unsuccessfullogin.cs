using System;
using System.Collections.Generic;

namespace Stor_E_Books.Models;

public partial class Unsuccessfullogin
{
    public int UnsuccessfulLoginId { get; set; }

    public DateOnly AttemptedDateTime { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }
}
