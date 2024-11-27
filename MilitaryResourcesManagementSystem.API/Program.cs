
using Microsoft.EntityFrameworkCore;
using MilitaryResourcesManagementSystem.API.Data;
using MilitaryResourcesManagementSystem.API.Mapping;
using MilitaryResourcesManagementSystem.API.Repositories;

namespace MilitaryResourcesManagementSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<MrmsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MilitaryConnectionString")));
            builder.Services.AddScoped<IUnitRepository, SQLUnitRepository>();
            builder.Services.AddScoped<ISoldierRepository, SQLSoldierRepository>();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            var app = builder.Build();

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
