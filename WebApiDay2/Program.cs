using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebApiDay2.Models;

namespace WebApiDay2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. //IOC

            builder.Services.AddDbContext<appContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("con"));
            });
            builder.Services.AddCors(corsOptions => {
                corsOptions.AddPolicy("LocalPolciy",
                    corsPolicyBuilder=>corsPolicyBuilder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    );
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            app.UseCors("LocalPolciy");
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