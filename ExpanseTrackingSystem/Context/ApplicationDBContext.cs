using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpanseTrackingSystem.Context
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext( DbContextOptions options) :base (options)
        {

        }
        public DbSet<ExpanseCategory> ExpanseCategories { get; set; }
        public DbSet<Expanse> Expanses { get; set; }

    }
}
