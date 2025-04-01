using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdataApi.Model;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Formatter;
using Newtonsoft.Json.Linq;

namespace OdataApi.Controllers
{
    public class OrderController : ODataController
    {
        private readonly OtipContext _context;

        public OrderController(OtipContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return Ok(_context.Orders);
        }

        [EnableQuery]
        public ActionResult<Customer> Get([FromRoute] int key)
        {
            var item = _context.Orders.SingleOrDefault(d => d.id.Equals(key));

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        //[EnableQuery]
        //[HttpGet("odata/GetOrdersByCustomer/{id}")]
        //public ActionResult<IEnumerable<OrderOnly>> GetOrdersByCustomer([FromRoute] int id)
        //{
            
        //    var items = _context.GetOrdersByCustomerId(id);
        //    if (items == null)
        //    {
        //        return NotFound();
        //    }
        //    return items;
        //}
    }
}
