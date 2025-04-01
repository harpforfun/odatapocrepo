using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdataApi.Model;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace OdataApi.Controllers
{
    public class CustomerController : ODataController
    {
        private readonly OtipContext _context;

        public CustomerController(OtipContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return Ok(_context.Customers);
        }

        [EnableQuery]
        public ActionResult<Customer> Get([FromRoute] int key)
        {
            var item = _context.Customers.SingleOrDefault(d => d.id.Equals(key));

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}
