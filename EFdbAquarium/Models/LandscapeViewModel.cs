namespace EFdbAquarium.Models
{
    public class LandscapeViewModel
    {
        public IEnumerable<Landscape> Landscapes { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public LandscapeFilterViewModel LandscapeFilterViewModel { get; set; }
        public LandscapeSortViewModel LandscapeSortViewModel { get; set; }
    }
}
