using Business.Interfaces.Repository;
using Business.Interfaces.Service;
using Business.Models;
using System.Linq.Expressions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public  async Task<Supplier> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public  async Task<List<Supplier>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task Add(Supplier supplier)
        {
            
            await _repository.Add(supplier);
        }

        public async Task Update(Supplier supplier)
        {

            await _repository.Update(supplier);
        }

        public async Task Remove(Guid id)
        {
          
            await _repository.Remove(id);
        }
    }
}
