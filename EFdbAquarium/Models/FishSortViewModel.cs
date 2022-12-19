namespace EFdbAquarium.Models
{
    public class FishSortViewModel
    {
        public FishSortState SpeciesSort { get; private set; }
        public FishSortState NameSort { get; private set; }
        public FishSortState PriceSort { get; private set; }
        public FishSortState FoodIdSort { get; private set; }
        public FishSortState Current { get; private set; }

        public FishSortViewModel(FishSortState sortOrder)
        {
            SpeciesSort = sortOrder == FishSortState.SpeciesAsc ? FishSortState.SpeciesDesc : FishSortState.SpeciesAsc;
            NameSort = sortOrder == FishSortState.NameAsc ? FishSortState.NameDesc : FishSortState.NameAsc;
            PriceSort = sortOrder == FishSortState.PriceAsc ? FishSortState.PriceDesc : FishSortState.PriceAsc;
            FoodIdSort = sortOrder == FishSortState.FoodIdAsc ? FishSortState.FoodIdDesc : FishSortState.FoodIdAsc;
            Current = sortOrder;
        }
    }
}
