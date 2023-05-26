using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.DataAccessLayer;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }     

        public ListModel(IRestaurantData restaurantData)
        {
            RestaurantData = restaurantData;
        }

        public IRestaurantData RestaurantData { get; }

        public void OnGet(string searchTerm)
        {
            Restaurants = RestaurantData.GetRestaurantByName(SearchTerm);
        }
    }
}
