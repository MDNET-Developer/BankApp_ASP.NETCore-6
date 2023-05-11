using BankAppIdentityProject.DataAccessLayer.Abstract;
using BankAppIdentityProject.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppIdentityProject.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T t)
        {
            await _dbSet.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public void Delete(T t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T t)
        {
            _dbSet.Update(t);
            _context.SaveChanges();
        }
    }
}
