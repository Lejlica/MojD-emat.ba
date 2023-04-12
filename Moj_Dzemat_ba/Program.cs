//using FIT_Api_Example.Data;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Identity.Web;
//using FIT_Api_Example;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//using Microsoft.Extensions.Configuration;

//var config = new ConfigurationBuilder()
//    .AddJsonFile("appsettings.json", false)
//    .Build();



//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();



//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseDefaultFiles();
//app.UseStaticFiles();

//app.UseCors(
//    options => options
//        .SetIsOriginAllowed(x => _ = true)
//        .AllowAnyMethod()
//        .AllowAnyHeader()
//        .AllowCredentials()
//); //This needs to set everything allowed


//app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using FIT_Api_Example;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT_Api_Examples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}


