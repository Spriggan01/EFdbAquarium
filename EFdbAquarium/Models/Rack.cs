namespace EFdbAquarium.Models
{
    public class Rack
    {
        public int Id { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        List<Aquarium> Aquariums { get; set; }
    }
}
