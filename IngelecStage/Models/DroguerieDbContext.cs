

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngelecDroguerries.Models
{
    public class DroguerieDbContext : DbContext
    {
        public DroguerieDbContext(DbContextOptions<DroguerieDbContext> options) : base(options)
        {

        }

        public DbSet<Destributeur> Destributeurs{ get; set; }
        public DbSet<Drouguerrie> Droguerries { get; set; }
       
    }
}
