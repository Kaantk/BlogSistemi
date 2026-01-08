using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependecyResolvers.Autofac;
using Business.Mapping;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.EntityFramework.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // AutoMapper konfigürasyonu
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            // Identity konfigürasyonu
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BlogSistemiContext>()
                .AddDefaultTokenProviders();

            // Autofac entegrasyonu
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            // Autofac modüllerini kaydet
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                // Business katmaný modülü
                containerBuilder.RegisterModule<AutofacBusinessModule>();
            });

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DbContext
            builder.Services.AddDbContext<BlogSistemiContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Seed identity data
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await IdentitySeed.SeedAsync(services);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
