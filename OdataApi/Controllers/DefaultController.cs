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
    [Route("odata")]
    public class DefaultController : ODataController
    {
        private readonly OtipContext _context;

        public DefaultController(OtipContext context)
        {
            _context = context;
        }
        [EnableQuery]
        [HttpGet("GetOrdersByCustomer(customerId={id})")]
        public IActionResult GetOrdersByCustomer(int id)
        {
            
            var items = _context.GetOrdersByCustomerId(id);
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }
    }
}
