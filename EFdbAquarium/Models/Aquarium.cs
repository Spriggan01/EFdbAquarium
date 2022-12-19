namespace EFdbAquarium.Models
{
    public class Aquarium
    {
        public int Id { get; set; }
        public string Shape { get; set; }
        public double Volume { get; set; }
        public string Filter { get; set; }
        public string Compressor { get; set; }
        public double Price { get; set; }
        public int? LightId { get; set; }
        public Light? Light { get; set; }
        public int? RackId { get; set; }
        public Rack? Rack { get; set; }
        public int? DecorationId { get; set; }
        public Decoration? Decoration { get; set; }
    }
}
