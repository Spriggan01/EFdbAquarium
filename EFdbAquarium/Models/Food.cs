namespace EFdbAquarium.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Shrimp> Shrimps { get; set; } = new();
        public List<Fish> Fishes { get; set; }
        public Food()
        {
            Fishes = new List<Fish>();
        }
    }
}
