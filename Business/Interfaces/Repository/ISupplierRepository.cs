using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    public interface ISupplierRepository 
    {
        Task Add(Supplier entity);
        Task<Supplier> GetById(Guid id);
        Task<List<Supplier>> GetAll();
        Task Update(Supplier entity);
        Task Remove(Guid id);
        Task<int> SaveChanges();
    }
}
