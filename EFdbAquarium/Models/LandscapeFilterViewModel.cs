using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFdbAquarium.Models
{
    public class LandscapeFilterViewModel
    {
        public LandscapeFilterViewModel(List<Decoration> decorations, int? decoration, string name)
        {
            decorations.Insert(0, new Decoration { DriftwoodSize = "Всі", Id = 0 });
            Decorations = new SelectList(decorations, "Id", "DriftwoodSize", decoration);
            SelectedDecoration = decoration;
            SelectedName = name;
        }
        public SelectList Decorations { get; private set; }
        public int? SelectedDecoration { get; private set; }
        public string SelectedName { get; private set; }
    }
}
