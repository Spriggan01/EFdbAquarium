namespace EFdbAquarium.Models
{
    public class Light
    {
        public int Id { get; set; }
        public string? TypeOfLight { get; set; }
        List<Aquarium> Aquariums { get; set; }
    }
}
