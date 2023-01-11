using AutoMapper;
using Business.Models;
using Web.ViewModels;

namespace Web.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            
            CreateMap<Supplier, SupplierViewModelUpdate>().ReverseMap();

            CreateMap<Supplier, SupplierViewModel>().ReverseMap();
        }
    }
}
