using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace WebLibrary.Controllers
{
    //[Route("[controller]")]

    public class LibraryController : Controller
    {
        private readonly IBookService _service;
        public LibraryController(IBookService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("library/getbooks")]
        public IActionResult Index()
        {
            return Ok(
                _service.GetAll()
                );
        }
        [HttpGet("{id}")]
        //[Route("[controller]/details/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _service.Getid(id)
                );
        }
        [HttpPost]
        //[Route("[controller]/create")]
        public IActionResult Post([FromBody]Book model)
        {

            return Ok(
                _service.Add(model));

        }


        [HttpPut]
        //[Route("[controller]/edit")]
        public IActionResult Put([FromBody]Book model)
        {
            return Ok(
                _service.Update(model));
        }


        [HttpDelete("{id}")]
        //[Route("[contoller]/delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _service.Delete(id));
        }
    }
}