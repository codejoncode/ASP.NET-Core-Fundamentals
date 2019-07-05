using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        
        [BindProperty] 
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            Restaurant = restaurantData.GetById(restaurantId);//will return a restaurant or null if not found
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost ()
        {
            //This is from all the valicators [Required] in Restaurant.cs file Errors  and AttemptedValue
            //ModelState["Location"].Errors
            if(ModelState.IsValid)
            {
                restaurantData.Update(Restaurant);
                restaurantData.Commit();

                //you never want a resubmission 
                return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id});
                //pass the id to the Detail page which is needed after get to the page a get request is made 
                //pattern post get redirect pattern
            }

            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();//asp core is stateless without this on post it will not populate
            
            return Page();
        }
    }
}