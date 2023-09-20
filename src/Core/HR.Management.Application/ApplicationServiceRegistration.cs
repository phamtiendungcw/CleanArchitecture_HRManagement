using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HR.Management.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());    // Tự động tìm kiếm ánh xạ nếu có thì add
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}