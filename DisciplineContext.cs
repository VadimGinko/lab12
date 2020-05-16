using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class DisciplineContext : DbContext
    {
        public DisciplineContext()
            : base("DbConnection")
        { }

        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Lector> Lectors { get; set; }
    }
}
