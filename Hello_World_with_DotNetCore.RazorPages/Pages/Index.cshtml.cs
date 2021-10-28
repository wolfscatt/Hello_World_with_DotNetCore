using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_with_DotNetCore.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hello_World_with_DotNetCore.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public AppMessage  Heading { get; set; }
        public string SubHeading { get; set; }
        public void OnGet()
        {
            Heading = new AppMessage()
            { 
                Message="Hello World"
            
            };
        }
        public void OnPost()
        {
            this.SubHeading = "Message Has Been Changed...";
        
        }
    }
}
