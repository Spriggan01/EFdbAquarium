namespace EFdbAquarium.Models
{
    public class LandscapeSortViewModel
    {
        public LandscapeSortState CategoryNameSort { get; private set; }
        public LandscapeSortState NameOfThePlantSort { get; private set; }
        public LandscapeSortState PlantPriceSort { get; private set; }
        public LandscapeSortState SoilTypeSort { get; private set; }
        public LandscapeSortState SoilPriceSort { get; private set; }
        public LandscapeSortState DecorationIdSort { get; private set; }
        public LandscapeSortState Current { get; private set; }

        public LandscapeSortViewModel(LandscapeSortState sortOrder)
        {
            CategoryNameSort = sortOrder == LandscapeSortState.CategoryNameAsc ? LandscapeSortState.CategoryNameDesc : LandscapeSortState.CategoryNameAsc;
            NameOfThePlantSort = sortOrder == LandscapeSortState.NameOfThePlantAsc ? LandscapeSortState.NameOfThePlantDesc : LandscapeSortState.NameOfThePlantAsc;
            PlantPriceSort = sortOrder == LandscapeSortState.PlantPriceAsc ? LandscapeSortState.PlantPriceDesc : LandscapeSortState.PlantPriceAsc;
            SoilTypeSort = sortOrder == LandscapeSortState.SoilTypeAsc ? LandscapeSortState.SoilTypeDesc : LandscapeSortState.SoilTypeAsc;
            SoilPriceSort = sortOrder == LandscapeSortState.SoilPriceAsc ? LandscapeSortState.SoilPriceDesc : LandscapeSortState.SoilPriceAsc;
            DecorationIdSort = sortOrder == LandscapeSortState.DecorationIdAsc ? LandscapeSortState.DecorationIdDesc : LandscapeSortState.DecorationIdAsc;
            Current = sortOrder;
        }
    }
}
