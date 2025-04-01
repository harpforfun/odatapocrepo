using System;
using System.Collections.Generic;

namespace OdataApi.Model;

public partial class Customer
{
    public int id { get; set; }

    public string? name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
