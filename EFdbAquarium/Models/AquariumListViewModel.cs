using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFdbAquarium.Models
{
    public class AquariumListViewModel
    {
        public IEnumerable<Aquarium> Aquariums { get; set; } = new List<Aquarium>();
        public SelectList Lights { get; set; } = new SelectList(new List<Light>(), "Id", "TypeOfLight");
        public string? Shape { get; set; }
    }
}
