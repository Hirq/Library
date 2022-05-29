using Library.Data.Models.Enum;

namespace Library.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public RestaurationType RestaurantType { get; set; }
    }
}
