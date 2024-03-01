
using Bussiness.Service;
using Data.Context;
using Data.Interface;
using Data.Repository;
using Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace StoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "cors",
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin();
                                      policy.AllowAnyMethod();
                                      policy.AllowAnyHeader();
                                  });
            });
            // Add services to the container.

            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ClienteService>();
            builder.Services.AddScoped<TiendaService>();
            builder.Services.AddScoped<ArticuloService>();
            builder.Services.AddScoped<ArticuloTiendaService>();
            builder.Services.AddScoped<IVentaRepository,VentaRepository>();
            builder.Services.AddScoped<IDetalleVentaRepository, DetalleVentaRepository>();
            builder.Services.AddScoped<VentaService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using(var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<StoreContext>();
                    DbInitializer.Inizialize(context);
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("cors");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}