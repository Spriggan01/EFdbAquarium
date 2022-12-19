namespace EFdbAquarium.Models
{
    public class Decoration
    {
        public int Id { get; set; }
        public string? TypeOfDriftwood { get; set; }
        public string? DriftwoodSize { get; set; }
        public List<Landscape> Landscapes { get; set; } = new();
        List<Aquarium> Aquariums { get; set; }
    }
}
