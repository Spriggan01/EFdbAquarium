using EFdbAquarium.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EFdbAquarium.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
        // Index and Pricacy pages
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        // Show Aquariums
        /*
        public async Task<IActionResult> Aquariums()
        {
            return View(await db.Aquariums.ToListAsync());
        }
        */
        // Show Fishes
        /*
        public async Task<IActionResult> Fishes()
        {
            return View(await db.Fishes.ToListAsync());
        }
        */
        // Show Shrimps
        /*
        public async Task<IActionResult> Shrimps()
        {
            return View(await db.Shrimps.ToListAsync());
        }*/
        // Create Aquarium
        public IActionResult CreateAq()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAq(Aquarium aquarium)
        {
            db.Aquariums.Add(aquarium);
            await db.SaveChangesAsync();
            return RedirectToAction("AquariumsPage");
        }
        // Aquarium Filter
        public ActionResult AquariumsPage(int? light, string? shape)
        {
            IQueryable<Aquarium> aquariums = db.Aquariums.Include(p => p.Light);
            if (light != null && light != 0)
            {
                aquariums = aquariums.Where(p => p.LightId == light);
            }
            if (!string.IsNullOrEmpty(shape))
            {
                aquariums = aquariums.Where(p => p.Shape!.Contains(shape));
            }

            List<Light> lights = db.Lights.ToList();
            lights.Insert(0, new Light { TypeOfLight = "Всі", Id = 0 });

            AquariumListViewModel viewModel = new AquariumListViewModel
            {
                Aquariums = aquariums.ToList(),
                Lights = new SelectList(lights, "Id", "TypeOfLight", light),
                Shape = shape
            };
            return View(viewModel);
        }
        // Show Details about Aquarium
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                List<Rack> racks = db.Racks.ToList();
                List<Light> lights = db.Lights.ToList();
                List<Decoration> decorations = db.Decorations.ToList();

                Aquarium aquarium = await db.Aquariums.FirstOrDefaultAsync(p => p.Id == id);
                if (aquarium != null)
                    return View(aquarium);
            }
            return NotFound();
        }
        // Edit Aquarium
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Aquarium aquarium = await db.Aquariums.FirstOrDefaultAsync(p => p.Id == id);
                if (aquarium != null)
                    return View(aquarium);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Aquarium aquarium)
        {
            db.Aquariums.Update(aquarium);
            await db.SaveChangesAsync();
            return RedirectToAction("AquariumsPage");
        }
        // Delete Aquarium
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Aquarium aquarium = await db.Aquariums.FirstOrDefaultAsync(p => p.Id == id);
                if (aquarium != null)
                    return View(aquarium);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Aquarium aquarium = await db.Aquariums.FirstOrDefaultAsync(p => p.Id == id);
                if (aquarium != null)
                {
                    db.Aquariums.Remove(aquarium);
                    await db.SaveChangesAsync();
                    return RedirectToAction("AquariumsPage");
                }
            }
            return NotFound();
        }
        // Fishes
        public async Task<IActionResult> FishesPage(int? food, string name, int page = 1,
            FishSortState sortOrder = FishSortState.NameAsc)
        {
            int pageSize = 10;

            // Filter
            IQueryable<Fish> fishes = db.Fishes.Include(x => x.Food);

            if (food != null && food != 0)
            {
                fishes = fishes.Where(p => p.FoodId == food);
            }
            if (!String.IsNullOrEmpty(name))
            {
                fishes = fishes.Where(p => p.Name.Contains(name));
            }

            // Sort
            switch (sortOrder)
            {
                case FishSortState.SpeciesDesc:
                    fishes = fishes.OrderByDescending(s => s.Species);
                    break;
                case FishSortState.NameDesc:
                    fishes = fishes.OrderByDescending(s => s.Name);
                    break;
                case FishSortState.PriceAsc:
                    fishes = fishes.OrderBy(s => s.Price);
                    break;
                case FishSortState.PriceDesc:
                    fishes = fishes.OrderByDescending(s => s.Price);
                    break;
                case FishSortState.FoodIdAsc:
                    fishes = fishes.OrderBy(s => s.Food.Name);
                    break;
                case FishSortState.FoodIdDesc:
                    fishes = fishes.OrderByDescending(s => s.Food.Name);
                    break;
                default:
                    fishes = fishes.OrderBy(s => s.Name);
                    break;
            }

            // Pagination
            var count = await fishes.CountAsync();
            var items = await fishes.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // View Model
            FishViewModel viewModel = new FishViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new FishSortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Foods.ToList(), food, name),
                Fishes = items
            };
            return View(viewModel);
        }
        // Create Fish
        public IActionResult CreateFish()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFish(Fish fish)
        {
            db.Fishes.Add(fish);
            await db.SaveChangesAsync();
            return RedirectToAction("FishesPage");
        }
        // Shrimps
        public async Task<IActionResult> ShrimpsPage(int? food, string name, int page = 1,
            ShrimpSortState sortOrder = ShrimpSortState.TypeAsc)
        {
            int pageSize = 10;

            // Filter
            IQueryable<Shrimp> shrimps = db.Shrimps.Include(x => x.Food);

            if (food != null && food != 0)
            {
                shrimps = shrimps.Where(p => p.FoodId == food);
            }
            if (!String.IsNullOrEmpty(name))
            {
                shrimps = shrimps.Where(p => p.Type.Contains(name));
            }

            // Sort
            switch (sortOrder)
            {
                case ShrimpSortState.TypeDesc:
                    shrimps = shrimps.OrderByDescending(s => s.Type);
                    break;
                case ShrimpSortState.LengthDesc:
                    shrimps = shrimps.OrderByDescending(s => s.Length);
                    break;
                case ShrimpSortState.PriceAsc:
                    shrimps = shrimps.OrderBy(s => s.Price);
                    break;
                case ShrimpSortState.PriceDesc:
                    shrimps = shrimps.OrderByDescending(s => s.Price);
                    break;
                case ShrimpSortState.FoodIdAsc:
                    shrimps = shrimps.OrderBy(s => s.Food.Name);
                    break;
                case ShrimpSortState.FoodIdDesc:
                    shrimps = shrimps.OrderByDescending(s => s.Food.Name);
                    break;
                default:
                    shrimps = shrimps.OrderBy(s => s.Type);
                    break;
            }

            // Pagination
            var count = await shrimps.CountAsync();
            var items = await shrimps.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // View Model
            ShrimpViewModel viewModel = new ShrimpViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new ShrimpSortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Foods.ToList(), food, name),
                Shrimps = items
            };
            return View(viewModel);
        }
        // Create Shrimp
        public IActionResult CreateShrimp()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateShrimp(Shrimp shrimp)
        {
            db.Shrimps.Add(shrimp);
            await db.SaveChangesAsync();
            return RedirectToAction("ShrimpsPage");
        }
        // Landscape
        public async Task<IActionResult> LandscapesPage(int? decoration, string name, int page = 1,
            LandscapeSortState sortOrder = LandscapeSortState.CategoryNameAsc)
        {
            int pageSize = 10;

            // Filter
            IQueryable<Landscape> landscapes = db.Landscapes.Include(x => x.Decoration);

            if (decoration != null && decoration != 0)
            {
                landscapes = landscapes.Where(p => p.DecorationId == decoration);
            }
            if (!String.IsNullOrEmpty(name))
            {
                landscapes = landscapes.Where(p => p.CategoryName.Contains(name));
            }

            // Sort
            switch (sortOrder)
            {
                case LandscapeSortState.CategoryNameDesc:
                    landscapes = landscapes.OrderByDescending(s => s.CategoryName);
                    break;
                case LandscapeSortState.NameOfThePlantDesc:
                    landscapes = landscapes.OrderByDescending(s => s.NameOfThePlant);
                    break;
                case LandscapeSortState.PlantPriceAsc:
                    landscapes = landscapes.OrderBy(s => s.PlantPrice);
                    break;
                case LandscapeSortState.PlantPriceDesc:
                    landscapes = landscapes.OrderByDescending(s => s.PlantPrice);
                    break;
                case LandscapeSortState.SoilTypeDesc:
                    landscapes = landscapes.OrderByDescending(s => s.SoilType);
                    break;
                case LandscapeSortState.SoilPriceAsc:
                    landscapes = landscapes.OrderBy(s => s.SoilPrice);
                    break;
                case LandscapeSortState.SoilPriceDesc:
                    landscapes = landscapes.OrderByDescending(s => s.SoilPrice);
                    break;
                case LandscapeSortState.DecorationIdAsc:
                    landscapes = landscapes.OrderBy(s => s.Decoration.DriftwoodSize);
                    break;
                case LandscapeSortState.DecorationIdDesc:
                    landscapes = landscapes.OrderByDescending(s => s.Decoration.DriftwoodSize);
                    break;
                default:
                    landscapes = landscapes.OrderBy(s => s.CategoryName);
                    break;
            }

            // Pagination
            var count = await landscapes.CountAsync();
            var items = await landscapes.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // View Model
            LandscapeViewModel viewModel = new LandscapeViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                LandscapeSortViewModel = new LandscapeSortViewModel(sortOrder),
                LandscapeFilterViewModel = new LandscapeFilterViewModel(db.Decorations.ToList(), decoration, name),
                Landscapes = items
            };
            return View(viewModel);
        }
        // Create Landscape
        public IActionResult CreateLandscape()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLandscape(Landscape land)
        {
            db.Landscapes.Add(land);
            await db.SaveChangesAsync();
            return RedirectToAction("LandscapesPage");
        }
        // ErrorViewModel
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}