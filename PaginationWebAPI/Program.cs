using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PaginationWebAPI.Data;
using PaginationWebAPI.Model;
using PaginationWebAPI.Services;


namespace PaginationWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
          /*  builder.Services.AddScoped<EmployeeRepository>();*/
            /*  builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
  */


            var mapperConfiguaration = new MapperConfiguration(cgf =>
            {
                cgf.AddProfile(typeof(AutoMapperProfile));

            });

            var mapper = mapperConfiguaration.CreateMapper();

            builder.Services.AddSingleton(mapperConfiguaration);
            builder.Services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<MapperConfiguration>(), sp.GetService));



            builder.Services.AddDbContext<EmployeeDbContext>(opt => opt.UseSqlServer(
                           builder.Configuration.GetConnectionString("cn")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
