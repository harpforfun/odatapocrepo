using System;
using System.Collections.Generic;

namespace OdataApi.Model;

public partial class OrderOnly
{
    public int id { get; set; }

    public int? customer_id { get; set; }

    public DateOnly? order_date { get; set; }
}
