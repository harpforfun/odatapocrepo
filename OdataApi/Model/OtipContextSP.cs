using Microsoft.EntityFrameworkCore;

namespace OdataApi.Model
{
    public partial class OtipContext : DbContext
    {
        public List<OrderOnly> GetOrdersByCustomerId(int customerId)
        {
            var orders = Orders.FromSqlInterpolated($"EXEC GetOrdersByCustomerId {customerId}").ToList();
            List<OrderOnly> oo = new List<OrderOnly>();
            foreach (var o in orders)
            {
                oo.Add(new OrderOnly
                {
                    id = o.id, customer_id = o.customer_id, order_date = o.order_date
                });
            }
            return oo;
        }
    }
}
