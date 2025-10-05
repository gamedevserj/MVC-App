using MVCApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace MVCApp.Models;

public class Pokemon
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required(ErrorMessage = "Select at least one type")]
    public PokemonType? Type { get; set; }

    [Range(0, 1000, ErrorMessage = "Please enter value between 0 and 1000")]
    public int Health { get; set; }

    [Range(0, 1000, ErrorMessage = "Please enter value between 0 and 1000")]
    public int Attack { get; set; }

    [Range(0, 1000, ErrorMessage = "Please enter value between 0 and 1000")]
    public int Defense { get; set; }

    [Range(0, 1000, ErrorMessage = "Please enter value between 0 and 1000")]
    public int Speed { get; set; }

    public static string GetBadgeColor(PokemonType type)
    {
        return type switch
        {
            PokemonType.Normal => "#aaaa99",
            PokemonType.Bug => "#aabb22",
            PokemonType.Dragon => "#7766ee",
            PokemonType.Electric => "#ffcc33",
            PokemonType.Fighting => "#bb5544",
            PokemonType.Fire => "#ff4422",
            PokemonType.Flying => "#8899ff",
            PokemonType.Ghost => "#6666bb",
            PokemonType.Grass => "#77cc55",
            PokemonType.Ground => "#ddbb55",
            PokemonType.Ice => "#66ccff",
            PokemonType.Poison => "#aa5599",
            PokemonType.Psychic => "#ff5599",
            PokemonType.Rock => "#bbaa66",
            PokemonType.Water => "#3399ff",
            _ => "white",
        };
    }

    public static PokemonType[] GetDistinctTypes(PokemonType? type)
    {
        return [.. Enum.GetValues<PokemonType>()
            .Where(x => (type & x) > 0)
            .Select(x => x)];
    }
}
