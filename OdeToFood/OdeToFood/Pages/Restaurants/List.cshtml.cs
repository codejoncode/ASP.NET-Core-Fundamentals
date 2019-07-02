using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;

        public string Message { get; set; }

        //Constructors should be named the same as the class 
        public ListModel(IConfiguration config)
        {
            //make a private readonly property
            this.config = config; 

        }
        public void OnGet()
        {
            //gets the value from appsettings.json
            Message = config["Message"];
        }
    }
}