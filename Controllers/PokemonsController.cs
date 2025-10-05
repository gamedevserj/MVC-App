using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCApp.Data;
using MVCApp.Enums;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class PokemonsController : Controller
    {
        private readonly MVCPokemonContext _context;

        public PokemonsController(MVCPokemonContext context)
        {
            _context = context;
        }

        // GET: Pokemons
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.TypeSortParam = sortOrder == "type" ? "type_desc" : "type";
            ViewBag.HealthSortParam = sortOrder == "health" ? "health_desc" : "health";
            ViewBag.AttackSortParam = sortOrder == "attack" ? "attack_desc" : "attack";
            ViewBag.DefenseSortParam = sortOrder == "defense" ? "defense_desc" : "defense";
            ViewBag.SpeedSortParam = sortOrder == "speed" ? "speed_desc" : "speed";

            var pokemons = from pokemon in _context.Pokemon
                           select pokemon;

            switch (sortOrder)
            {
                case "name_desc": 
                    pokemons = pokemons.OrderByDescending(p => p.Name);
                    ViewBag.CurrentSortOrder = "";
                    break;
                case "type":
                    pokemons = pokemons.OrderBy(p => p.Type);
                    ViewBag.CurrentSortOrder = "type_desc";
                    break;
                case "type_desc":
                    pokemons = pokemons.OrderByDescending(p => p.Type);
                    ViewBag.CurrentSortOrder = "type";
                    break;
                case "health":
                    pokemons = pokemons.OrderBy(p => p.Health);
                    ViewBag.CurrentSortOrder = "health_desc";
                    break;
                case "health_desc":
                    pokemons = pokemons.OrderByDescending(p => p.Health);
                    ViewBag.CurrentSortOrder = "health";
                    break;
                case "attack":
                    pokemons = pokemons.OrderBy(p => p.Attack);
                    ViewBag.CurrentSortOrder = "attack_desc";
                    break;
                case "attack_desc":
                    pokemons = pokemons.OrderByDescending(p => p.Attack);
                    ViewBag.CurrentSortOrder = "attack";
                    break;
                case "defense":
                    pokemons = pokemons.OrderBy(p => p.Defense);
                    ViewBag.CurrentSortOrder = "defense_desc";
                    break;
                case "defense_desc":
                    pokemons = pokemons.OrderByDescending(p => p.Defense);
                    ViewBag.CurrentSortOrder = "defense";
                    break;
                case "speed":
                    pokemons = pokemons.OrderBy(p => p.Speed);
                    ViewBag.CurrentSortOrder = "speed_desc";
                    break;
                case "speed_desc":
                    pokemons = pokemons.OrderByDescending(p => p.Speed);
                    ViewBag.CurrentSortOrder = "speed";
                    break;
                default:
                    pokemons = pokemons.OrderBy(p => p.Name);
                    ViewBag.CurrentSortOrder = "name_desc";
                    break;
            }

            return View(await pokemons.ToListAsync());
        }

        // GET: Pokemons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        // GET: Pokemons/Create
        public IActionResult Create()
        {
            var types = new SelectList(Enum.GetValues<PokemonType>());

            var viewModel = new PokemonTypeViewModel
            {
                Pokemon = new Pokemon(),
                Types = types,
            };

            return View(viewModel);
        }

        // POST: Pokemons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Health,Attack,Defense,Speed")] Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokemon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var types = new SelectList(Enum.GetValues<PokemonType>());

            var viewModel = new PokemonTypeViewModel
            {
                Pokemon = pokemon,
                Types = types,
            };

            return View(viewModel);
        }

        // GET: Pokemons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemon.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            return View(pokemon);
        }

        // POST: Pokemons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Health,Attack,Defense,Speed")] Pokemon pokemon)
        {
            if (id != pokemon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokemon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokemonExists(pokemon.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pokemon);
        }

        // GET: Pokemons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        // POST: Pokemons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokemon = await _context.Pokemon.FindAsync(id);
            if (pokemon != null)
            {
                _context.Pokemon.Remove(pokemon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokemonExists(int id)
        {
            return _context.Pokemon.Any(e => e.Id == id);
        }
    }
}
