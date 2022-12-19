namespace EFdbAquarium.Models
{
    public class FishViewModel
    {
        public IEnumerable<Fish> Fishes { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public FishSortViewModel SortViewModel { get; set; }
    }
}
