using ETicaretAPI.Application.Abstract.Repositories;
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


        public IQueryable<T> GetAll()
            => Table;

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
            => Table.Where(method);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
            => await Table.FirstOrDefaultAsync(method);

        public async Task<T> GetByIdAsyn(string id)
            // => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id)); //Kullanilan ORM find metodunu desteklemezse, Marker Pattern uygulanabilinir.
            => await Table.FindAsync(Guid.Parse(id));
    }
}
