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

    [Range(0, 1000, ErrorMessage = "Please enter value between 0 and 1000")]
    public int Health { get; set; }

    [Range(0, 1000, ErrorMessage = "Please enter value between 0 and 1000")]
    public int Attack { get; set; }

    [Range(0, 1000, ErrorMessage = "Please enter value between 0 and 1000")]
    public int Defense { get; set; }

    [Range(0, 1000, ErrorMessage = "Please enter value between 0 and 1000")]
    public int Speed { get; set; }
}
