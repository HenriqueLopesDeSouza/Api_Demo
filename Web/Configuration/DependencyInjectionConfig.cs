using Business.Interfaces;
using Business.Interfaces.Repository;
using Business.Interfaces.Service;
using Business.Models;
using Business.Services;
using Data.Context;
using Data.Repository;
using Web.Extensions;

namespace Web.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyContext>();
         
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<INotifier, NotifierService>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            return services;
        }
    }
}
