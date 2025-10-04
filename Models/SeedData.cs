using Microsoft.EntityFrameworkCore;
using MVCApp.Data;

namespace MVCApp.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MVCPokemonContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MVCPokemonContext>>()))
        {
            // Look for any movies.
            if (context.Pokemon.Any())
            {
                return;   // DB has been seeded
            }
            context.Pokemon.AddRange(
                new Pokemon
                {
                    Name = "Bulbasaur",
                    Type = Enums.PokemonType.Grass | Enums.PokemonType.Poison,
                    Health = 45,
                    Attack = 49,
                    Defense = 49,
                    Speed = 45,
                },
                new Pokemon
                {
                    Name = "Ivysaur",
                    Type = Enums.PokemonType.Grass | Enums.PokemonType.Poison,
                    Health = 60,
                    Attack = 62,
                    Defense = 63,
                    Speed = 60,
                },
                new Pokemon
                {
                    Name = "Venusaur",
                    Type = Enums.PokemonType.Grass | Enums.PokemonType.Poison,
                    Health = 80,
                    Attack = 82,
                    Defense = 83,
                    Speed = 80,
                },
                new Pokemon
                {
                    Name = "Charmander",
                    Type = Enums.PokemonType.Fire,
                    Health = 39,
                    Attack = 52,
                    Defense = 43,
                    Speed = 65,
                },
                new Pokemon
                {
                    Name = "Charmeleon",
                    Type = Enums.PokemonType.Fire,
                    Health = 58,
                    Attack = 64,
                    Defense = 58,
                    Speed = 80,
                },
                new Pokemon
                {
                    Name = "Charizard",
                    Type = Enums.PokemonType.Fire | Enums.PokemonType.Flying,
                    Health = 78,
                    Attack = 84,
                    Defense = 78,
                    Speed = 100,
                },
                new Pokemon
                {
                    Name = "Squirtle",
                    Type = Enums.PokemonType.Water,
                    Health = 44,
                    Attack = 48,
                    Defense = 65,
                    Speed = 43,
                },
                new Pokemon
                {
                    Name = "Wartortle",
                    Type = Enums.PokemonType.Water,
                    Health = 59,
                    Attack = 63,
                    Defense = 80,
                    Speed = 58,
                },
                new Pokemon
                {
                    Name = "Blastoise",
                    Type = Enums.PokemonType.Water,
                    Health = 79,
                    Attack = 83,
                    Defense = 100,
                    Speed = 78,
                },
                new Pokemon
                {
                    Name = "Pikachu",
                    Type = Enums.PokemonType.Electric,
                    Health = 35,
                    Attack = 55,
                    Defense = 40,
                    Speed = 90,
                }
            );
            context.SaveChanges();
        }
    }
}
