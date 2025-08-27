using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriteTheRest.Core.Mapping.AutoMapper;
using WriteTheRest.Core.Mapping;
using WriteTheRest.Core.Repository.Abstract;
using WriteTheRest.Core.Repository.DbContexts;
using WriteTheRest.Core.Repository.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace WriteTheRest.Core.IoC
{
    public static class GenericResolver
    {
        public static void ConfigureServices<TDbContext>(
            IServiceCollection services,
            IConfiguration configuration)
            where TDbContext : DbContextBase
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<TDbContext>(options =>
                options.UseSqlServer(connectionString)); 
            services.AddScoped<DbContextBase, TDbContext>();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(EFGenericRepository<>));
            services.AddScoped<IGenericMapper, GenericAutoMapper>();
        }
    }
           
}
