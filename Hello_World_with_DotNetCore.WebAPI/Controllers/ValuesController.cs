using Hello_World_with_DotNetCore.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hello_World_with_DotNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public List<AppMessage> Get()
        {
            var message = new List<AppMessage>()
            { 
              new AppMessage(){Message="Hello WORLD" },
              new AppMessage(){Message="Hello MVC" },
              new AppMessage(){Message="Hello Razor Pages" },
              new AppMessage(){Message="Hello WebAPIs" }
            };
            return message;
        }
            
    }
}
