using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Service
{
    public interface ISupplierService
    {
        public  Task Add(Supplier supplier);
        public Task Update(Supplier supplier);
        public Task Remove(Guid id);
        public Task<Supplier> GetById(Guid id);
        public Task<List<Supplier>> GetAll();
    }
}
