using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PcPartsStore.Application.Contracts.Persistence;
using PcPartsStore.Persistence.Repositories;

namespace PcPartsStore.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PcPartsStoreDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("PcPartsStoreDbConnectionString"))
            );

            services.AddScoped(typeof(IAsyncReposotory<>), typeof(BaseRepository<>));

            services.AddScoped<IPartsReposotory, PartsRepository>();
            services.AddScoped<ICategoryRepository, CategoryReposotory>();
            services.AddScoped<IOrderReposotory, OrderRepository>();

            return services;
        }
    }
}
