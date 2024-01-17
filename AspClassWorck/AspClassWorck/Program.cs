
using AspClassWorck.Abstraction;
using AspClassWorck.Models;
using AspClassWorck.Repo;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace AspClassWorck
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Host.ConfigureContainer<ContainerBuilder>(cb =>
            {
                cb.Register(c => new ProductContext(builder.Configuration.GetConnectionString("db")));
                cb.RegisterType<ProductRepository>().As<IProductRepository>();
                cb.RegisterType<GroupRepository>().As<IGroupRepository>();
            });
            //builder.Services.AddTransient<IProductRepository, ProductRepository>();  //2й чаще используемый вариант
            //builder.Services.AddSingleton<IGroupRepository, GroupRepository>();
            //builder.Services.AddDbContext<ProductContext>(conf => conf.UseSqlServer(builder.Configuration.GetConnectionString("db")));

            builder.Services.AddMemoryCache(o => o.TrackStatistics = true);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var staticFilePath = Path.Combine(Directory.GetCurrentDirectory(), "CacheFiles");
            Directory.CreateDirectory(staticFilePath);

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(staticFilePath),RequestPath = "/static"
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
