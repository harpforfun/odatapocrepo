using System;
using System.Collections.Generic;

namespace OdataApi.Model;

public partial class Order
{
    public int id { get; set; }

    public int? customer_id { get; set; }

    public DateOnly? order_date { get; set; }

    public virtual Customer? customer { get; set; }
}
