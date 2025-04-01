using System;
using System.Collections.Generic;

namespace OdataApi.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public virtual Customer? Customer { get; set; }
}
