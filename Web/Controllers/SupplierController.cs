using AutoMapper;
using Business.Interfaces;
using Business.Interfaces.Repository;
using Business.Interfaces.Service;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Extensions;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    public class SupplierController : MainController
    {


        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SupplierController(INotifier notifier,
                                  ISupplierService supplierService,
                                  IUser user,
                                  IMapper mapper) : base(notifier, user)
        {
            _mapper = mapper;
            _supplierService = supplierService;
        }

        [HttpGet] 
        [Route("GetAll")]
        public async Task<IEnumerable<SupplierViewModelUpdate>> GetAll()
        { 
            return _mapper.Map<IEnumerable<SupplierViewModelUpdate>>(await _supplierService.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SupplierViewModelUpdate>> GetById(Guid id)
        {
            var supplier = _mapper.Map<SupplierViewModelUpdate>(await _supplierService.GetById(id));

            
            if (supplier == null) return NotFound();

            return supplier;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<SupplierViewModel>> Add(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _supplierService.Add(_mapper.Map<Supplier>(supplierViewModel));

            return CustomResponse(supplierViewModel);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<SupplierViewModel>> Update(Guid id, SupplierViewModelUpdate supplierViewModel)
        {
            if (id != supplierViewModel.Id)
            {
                NotifierErro("The informed id is not the same as the one passed in the query");
                return CustomResponse(supplierViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _supplierService.Update(_mapper.Map<Supplier>(supplierViewModel));

            return Ok(supplierViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> Excluir(Guid id)
        {
            await _supplierService.Remove(id);

            return Ok();
        }
      
    }
}
