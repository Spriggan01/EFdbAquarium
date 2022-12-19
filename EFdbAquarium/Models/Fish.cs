namespace EFdbAquarium.Models
{
    public class Fish
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int FoodId { get; set; }
        public Food? Food { get; set; }
    }
}
