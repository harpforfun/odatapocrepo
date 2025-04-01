using System;
using System.Collections.Generic;

namespace OdataApi.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
