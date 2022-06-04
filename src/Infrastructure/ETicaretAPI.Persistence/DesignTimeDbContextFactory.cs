using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ETicaretAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETicaretAPIDbContext>
    {
        //Bu class'in olusturulma nedeni; eger projemizdeki migration islemlerini entity framework cli (powershell vb.) kullanarak yapmak ve hata almak istemezsek diye olusturuyoruz.

        #region Implementation of IDesignTimeDbContextFactory<out ETicaretAPIDbContext>

        public ETicaretAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ETicaretAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }

        #endregion
    }
}
