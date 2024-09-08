
using Microsoft.EntityFrameworkCore;
using SalesDateProduction.Business.Service;
using SalesDateProduction.DataAccess.Context;
using SalesDateProduction.DataAccess.OrderConfig.Contract;
using SalesDateProduction.DataAccess.OrderConfig.Implementation;

namespace SDPWebAppi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var NewPolice = "_NewPolice";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: NewPolice, app =>
                {
                    app.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<SDP_DBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<SalesDateProductionConfigurationBusiness>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(NewPolice);

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
