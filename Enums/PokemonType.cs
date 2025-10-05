namespace MVCApp.Enums;

[Flags]
public enum PokemonType
{
    Normal = 1 << 0,
    Bug = 1 << 1,
    Dragon = 1 << 2,
    Electric = 1 << 3,
    Fighting = 1 << 4,
    Fire = 1 << 5,
    Flying = 1 << 6,
    Ghost = 1 << 7,
    Grass = 1 << 8,
    Ground = 1 << 9,
    Ice = 1 << 10,
    Poison = 1 << 11,
    Psychic = 1 << 12,
    Rock = 1 << 13,
    Water = 1 << 14,
}
