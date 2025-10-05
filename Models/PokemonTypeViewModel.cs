using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCApp.Models;

public class PokemonTypeViewModel
{
    public Pokemon? Pokemon { get; set; }
    public SelectList? Types { get; set; }
}
