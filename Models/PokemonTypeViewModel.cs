using Microsoft.AspNetCore.Mvc.Rendering;
using MVCApp.Enums;

namespace MVCApp.Models;

public class PokemonTypeViewModel
{

    public Pokemon? Pokemon { get; set; }
    public SelectList? Types { get; set; }
    public PokemonType? Selected { get; set; }
}
