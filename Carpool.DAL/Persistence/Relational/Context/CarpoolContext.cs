using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.DAL.Persistence.Relational.Context
{
    public class CarpoolContext : DbContext
    {
        public CarpoolContext(DbContextOptions<CarpoolContext> options) : base(options)
        {

        }

        //public DbSet<>

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration();
        }
    }
}
