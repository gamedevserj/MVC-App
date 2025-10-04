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
                }
            );
            context.SaveChanges();
        }
    }
}
