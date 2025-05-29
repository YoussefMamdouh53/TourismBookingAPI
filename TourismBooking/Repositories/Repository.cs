using Microsoft.EntityFrameworkCore;
using TourismBooking.Data;

namespace TourismBooking.Repositories
{
    public abstract class Repository<T> where T : class
    {
        protected readonly TourismBookingDbContext DbContext;
        public Repository(TourismBookingDbContext Ctx) {
               DbContext = Ctx;
        }
        public async Task Insert(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }
        public void Update(T entity)
        {
            DbContext.Set<T>().Update(entity);
        }
        public async Task<T?> GetById(int id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await DbContext.Set<T>().ToListAsync();
        }
    }
}
