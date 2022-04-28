using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulerWithDb.Entities;

namespace SchedulerWithDb
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<ScheduleTask> ScheduleTasks { get; set; } = null!;

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= ScheduleDataBase.db");
        }
        
    }
}
