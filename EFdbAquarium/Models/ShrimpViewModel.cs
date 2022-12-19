namespace EFdbAquarium.Models
{
    public class ShrimpViewModel
    {
        public IEnumerable<Shrimp> Shrimps { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public ShrimpSortViewModel SortViewModel { get; set; }
    }
}
