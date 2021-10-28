using Hello_World_with_DotNetCore.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web; //ben ekledim

namespace Hello_World_with_DotNetCore.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet] //veri geldiğinde çalışsın
        public IActionResult Index()
        {
            var obj = new AppMessage() 
            {
               Message = "Hello World!"
            };
            
            return View(obj);
        }
        [HttpPost] //veri işlemek için çalışsın
        public IActionResult Index(AppMessage obj)
        {
            ViewBag.Message = "Message has been changed";
            return View(obj);
        }
    }
}
