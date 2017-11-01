using System;
using MeetUp.Data.DBContext;
using MeetUp.Repositories;
using MeetUp.Repositories.IRepositories;
using MeetUp.Services;
using MeetUp.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Http;
using FluentValidation.AspNetCore;
using AutoMapper;
using MeetUp.Data.DBSeed;

namespace MeetUp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
            .AddFluentValidation(fvc =>
            fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ASP.NET Core MeetUp API",
                    Description = "ASP.NET Core/Angular MeetUp Swagger Documentation",
                });
            });
            services.AddAutoMapper();
            
            services.AddDbContext<MeetUpContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("MeetUpSqliteConnectionString"));
            });

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IMeetUpRepository, MeetUpRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IMeetUpService, MeetUpService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionHandlerFeature != null)
                    {
                        var logger = loggerFactory.CreateLogger("Global exception logger");
                        logger.LogError(500,
                            exceptionHandlerFeature.Error,
                            exceptionHandlerFeature.Error.Message);
                        if (env.IsDevelopment())
                        {
                            context.Response.StatusCode = 500;
                            await context.Response.WriteAsync($"Message: {exceptionHandlerFeature.Error.Message}{Environment.NewLine}" +
                                                              $"Error: { exceptionHandlerFeature.Error}");
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    }
                });
            });


            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            // Visit http://localhost:5000/swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseMvc();

            MeetUpDbSeeder.SeedAsync(app.ApplicationServices).Wait();
        }
    }
}
