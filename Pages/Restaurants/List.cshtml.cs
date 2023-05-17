using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.DataAccessLayer;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            RestaurantData = restaurantData;
        }

        public IRestaurantData RestaurantData { get; }

        public void OnGet()
        {
            Restaurants = RestaurantData.GetAll();
        }
    }
}
