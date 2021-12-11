using Microsoft.EntityFrameworkCore;
using System;
using VisitWithUs.Entities;

namespace VisitWithUs.DataAccess
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=DESKTOP-CSD22RP; database=Visit_With_Us; uid=sa; pwd=Mssql12345");
        }
        public DbSet<Place> places { get; set; }
    }
}
