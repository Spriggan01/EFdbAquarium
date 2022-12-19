using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EFdbAquarium.Models
{
    public class Shrimp
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Length { get; set; }
        public double Price { get; set; }
        public int? FoodId { get; set; }
        public Food? Food { get; set; }
    }
}
