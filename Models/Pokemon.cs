using MVCApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace MVCApp.Models;

public class Pokemon
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public PokemonType Type { get; set; }

    public int Health { get; set; }

    public int Attack { get; set; }

    public int Defense { get; set; }

    public int Speed { get; set; }
}
