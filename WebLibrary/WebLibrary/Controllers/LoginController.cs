using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace WebLibrary.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [Route("insertreader")]
        [HttpPost]
        public IActionResult Post([FromBody]Registration registration)
        {

            return Ok(
                _loginService.InsertReader(registration));

        }
        [Route("login")]
        [HttpPost]
        public IActionResult ReaderLogin([FromBody]Login userLogin)
        {
            return Ok(_loginService.ReaderLogin(userLogin));
        }

    }
}