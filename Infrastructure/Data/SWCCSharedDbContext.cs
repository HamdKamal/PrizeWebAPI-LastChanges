using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SWCCSharedDbContext : DbContext
    {
        public SWCCSharedDbContext(DbContextOptions<SWCCSharedDbContext> options)
              : base(options)
        {
        }

        public virtual DbSet<VEmployeeRecordAll> VEmployeeRecordAll { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SWCCSharedDbContext).Assembly);
        }      


    }

}
