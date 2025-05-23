﻿using BlogSys.Models;
using BlogSys.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogSys.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly BlogDBContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(BlogDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }

}
