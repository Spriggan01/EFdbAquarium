using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EFdbAquarium.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Food> foods, int? food, string name)
        {
            foods.Insert(0, new Food { Name = "Всі", Id = 0 });
            Foods = new SelectList(foods, "Id", "Name", food);
            SelectedFood = food;
            SelectedName = name;
        }
        public SelectList Foods { get; private set; }
        public int? SelectedFood { get; private set; }
        public string SelectedName { get; private set; }
    }
}
