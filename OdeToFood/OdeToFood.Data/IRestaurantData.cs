using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        //see the  OdeToFood.Data.csproj file on how to reference the Restaurant from OdeToFood.Core
        //unable to reference Restaurant unless the Restaurant class is marked public 
        /*Experienced  error  Restaurant inaccessible due to protection level error 
          classes are private by default. Without explicitly calling public it is inaccessible.  
        */
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Scott's Pizza", Location= "Maryland", Cuisine=CuisineType.Italian},
                new Restaurant {Id = 1, Name = "Cinnamon Club", Location= "London", Cuisine=CuisineType.Italian},
                new Restaurant {Id = 1, Name = "La Costa", Location= "Califorina", Cuisine=CuisineType.Mexican}
            };
        }
        //  name is a optional parmater 
        public IEnumerable<Restaurant> GetRestaurantsByName( string name = null)
        {
            //linq query  using System.Linq required 
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
