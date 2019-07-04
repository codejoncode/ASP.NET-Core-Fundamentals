using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        //this will allow us to use this property on the form so that it updates. 
        [BindProperty(SupportsGet =true)]// model binding  defaults to posts requests  SupportsGet allows it to work on gets. 
        public string SearchTerm { get; set; }

        //Constructors should be named the same as the class  IRestaurantData accessible from the addSingleton logic in Startup.cs
        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            //make a private readonly property
            this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            //model binding will look for something that is named searchTerm

            //gets the value from appsettings.json
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}