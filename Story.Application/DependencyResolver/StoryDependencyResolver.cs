using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Story.Application.Mapping.AutoMapper;
using WriteTheRest.Core.IoC;
using Story.Data.Context;
using Story.Application.Abstract;
using Story.Application.Services;

namespace Story.Application.DependencyResolver
{
    public static class StoryDependencyResolver
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // DbContext ve generic servisler için
            GenericResolver.ConfigureServices<StoryContext>(services, configuration);

            // AutoMapper profili
            services.AddAutoMapper(typeof(MappingProfile));

            // Application servislerini ekle
            services.AddScoped<IChapterService, ChapterService>();
            services.AddScoped<IStoryService, StoryService>();
            services.AddScoped<IStoryVersionService, StoryVersionService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IUserService, UserService>();


            // Gerekirse repository katmanını da ekle
            // services.AddScopedServicesFromAssemblies(typeof(IGenericRepository<>).Assembly);
            // services.AddScopedFromAssemblies(typeof(IChapterService).Assembly);
        }
    }
}