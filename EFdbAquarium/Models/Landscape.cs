namespace EFdbAquarium.Models
{
    public class Landscape
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? NameOfThePlant { get; set; }
        public double PlantPrice { get; set; }
        public string? SoilType { get; set; }
        public double SoilPrice { get; set; }
        public int? DecorationId { get; set; }
        public Decoration? Decoration { get; set; }
    }
}
