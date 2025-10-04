using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCApp.Models;

namespace MVCApp.Data
{
    public class MVCPokemonContext : DbContext
    {
        public MVCPokemonContext (DbContextOptions<MVCPokemonContext> options)
            : base(options)
        {
        }

        public DbSet<MVCApp.Models.Pokemon> Pokemon { get; set; } = default!;
    }
}
