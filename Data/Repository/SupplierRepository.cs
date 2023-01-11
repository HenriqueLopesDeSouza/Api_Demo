using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public  class SupplierRepository : ISupplierRepository
    {
        protected readonly MyContext Db;
        protected readonly DbSet<Supplier> DbSet;

        public SupplierRepository(MyContext context) 
        {
            Db = context;
            DbSet = context.Set<Supplier>();
        }

        public virtual async Task<Supplier> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<Supplier>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Add(Supplier entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(Supplier entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remove(Guid id)
        {
            DbSet.Remove(new Supplier { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
