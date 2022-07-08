
using Repository.Repository;
using Repository.IRepository;
using Models.Configuration;
using Microsoft.EntityFrameworkCore;
using Repository.DTO;
using Repository;
using AutoMapper;

namespace WebHosting.Configure
{
    public static class ServicesExtencion
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", build =>
                {
                    build.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            });
        }

        public static void ConfigureISSIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(option =>
            {
                // Configuracion basica
            });
        }

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWord, UnitOfWord>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("ConnectionSQL"));
            });
        }

        public static void ConfigurDTO(this IServiceCollection s)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperInitilizer());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            s.AddSingleton(mapper);
        }
    }
}
