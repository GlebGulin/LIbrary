using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebLibrary.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("order/gettaken")]
        public IActionResult Index()
        {
            return Ok(
               _service.GetAllOrder()
               );
        }
    }
}