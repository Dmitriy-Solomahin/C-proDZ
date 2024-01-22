using ASP_Dz3.Abstractions;
using ASP_Dz3.Mapper;
using ASP_Dz3.Mutatin;
using ASP_Dz3.Query;
using ASP_Dz3.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace ASP_Dz3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddMemoryCache();
            builder.Services.AddAutoMapper(typeof(MapperProfile));

            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<IStorageService, StorageService>();
            builder.Services.AddTransient<ICategoryService, CategoryService>();
            builder.Services.AddTransient<IProductsInStorageService, ProductsInStorageService>();
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(cb =>
            {
                cb.Register(c => new AppDbContext(builder.Configuration.GetConnectionString("db"))).InstancePerDependency();
            });


            builder.Services
                .AddGraphQLServer()
                .AddQueryType<MySimpleQuery>()
                .AddMutationType<MySimpleMutation>();


            var app = builder.Build();

            app.MapGraphQL();

            app.Run();
        }
    }
}
