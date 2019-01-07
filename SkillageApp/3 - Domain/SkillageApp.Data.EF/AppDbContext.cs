using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillageApp.Data.Entities;
using SkillageApp.Data.Interfaces;

namespace SkillageApp.Data.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("SkillageAppConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            #if DEBUG
            this.Database.Log = (s) =>
                        {
                            Debug.WriteLine(s);
                        };
            #endif
        }

        public DbSet<StockSymbol> StockSymbols { get; set; }
        public DbSet<DailyPrices> DailyPriceses { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<VWDailyPrices> VWDailyPrices { get; set; }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            foreach (DbEntityEntry item in modified)
            {
                var changedOrAddedItem = item.Entity as IDateTracking;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.DateCreated = DateTime.Now;
                    }
                    changedOrAddedItem.DateModified = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

    }
}
