using ETicaretAPI.Application.Abstracts.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ETicaretAPI.Persistence.Concrete.Repositories
{
    public class GenericReadRepository<T> : IGenericReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public GenericReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }


        public DbSet<T> Table => _context.Set<T>();


        public IQueryable<T> GetAll(bool tracking = true)
        {
            //=> Table;

            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }


        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            // => Table.Where(method);

            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }


        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            // return await Table.FirstOrDefaultAsync(method);

            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsQueryable();

            return await query.FirstOrDefaultAsync(method);
        }


        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            // => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id)); //Kullanilan ORM find metodunu desteklemezse, Marker Pattern uygulanabilinir.

            //    => await Table.FindAsync(Guid.Parse(id));

            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();

            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id)); //IQueryable de calisildigi icin FindAsync metodu bulunmamaktadir. Bu yüzden burada id üzerinden Marker Pattern kullaniyoruz.

        }
    }
}
