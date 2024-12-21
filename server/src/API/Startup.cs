using API.Filters;
using Application.Extensions;
using Application.Mapper;
using Application.Middleware;
using Domain;
using Domain.IRepositories;
using Infrastructure.Behaviors;
using Infrastructure.Data;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Startup
    {
        public IConfiguration ConfigRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            ConfigRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            AutoMapperConfig.Configure(services);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<TreasureHuntDbContext>(options => options.UseSqlite("Data Source=treasurehunt.db"));

            services.AddMediatR(typeof(Startup).Assembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.RegisterCommandHandlers();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllers(options =>
            {
                options.Filters.Add<HttpResponseExceptionFilter>();
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5173") 
                              .AllowAnyHeader() 
                              .AllowAnyMethod();
                    });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);
            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("AllowFrontend");
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();
            app.UseMiddleware<ResponseWrapperMiddleware>();
            app.UseRouting();
            app.Run();
        }
    }
}
