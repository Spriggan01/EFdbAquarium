namespace EFdbAquarium.Models
{
    public class ShrimpSortViewModel
    {
        public ShrimpSortState TypeSort { get; private set; }
        public ShrimpSortState LengthSort { get; private set; }
        public ShrimpSortState PriceSort { get; private set; }
        public ShrimpSortState FoodIdSort { get; private set; }
        public ShrimpSortState Current { get; private set; }

        public ShrimpSortViewModel(ShrimpSortState sortOrder)
        {
            TypeSort = sortOrder == ShrimpSortState.TypeAsc ? ShrimpSortState.TypeDesc : ShrimpSortState.TypeAsc;
            LengthSort = sortOrder == ShrimpSortState.LengthAsc ? ShrimpSortState.LengthDesc : ShrimpSortState.LengthAsc;
            PriceSort = sortOrder == ShrimpSortState.PriceAsc ? ShrimpSortState.PriceDesc : ShrimpSortState.PriceAsc;
            FoodIdSort = sortOrder == ShrimpSortState.FoodIdAsc ? ShrimpSortState.FoodIdDesc : ShrimpSortState.FoodIdAsc;
            Current = sortOrder;
        }
    }
}
