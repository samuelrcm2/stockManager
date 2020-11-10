using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StockManager.Core.Application.Concrete;
using StockManager.Core.Application.Contract;
using StockManager.Core.Application.ViewModels;
using StockManager.Core.Domain.Concrete;
using StockManager.Core.Domain.Contract;
using StockManager.Core.Domain.Models;
using StockManager.Infracstruture.DataAccess;
using StockManager.Infracstruture.DataAccess.Repositories;
using StockManager.Infracstruture.DataAccess.Repositories.Caontract;
using System;

namespace StockManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration["DatabaseConnectionString"];
            //services.AddDbContext<StockItenContext>(options =>
            //    options.UseSqlite(connection)
            //);

            RegisterCors(services);
            // Add framework services.
            services.AddMvc();

            services.AddControllers();

            //Add swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Stock Manager API"
                });
            });

            MapperConfiguration config = configureAutoMapper();
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            AddDependenciesInjection(services);

            SqlMapper.AddTypeHandler(new SqlGuidTypeHandler());
            SqlMapper.RemoveTypeMap(typeof(Guid));
            SqlMapper.RemoveTypeMap(typeof(Guid?));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAnyOrigin");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/api", async context =>
                {
                    await context.Response.WriteAsync("Stock Manager API");
                });
            });

            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.RoutePrefix = string.Empty;
                s.SwaggerEndpoint("swagger/v1/swagger.json", "Stock Manager API");
            });

        }

        private void AddDependenciesInjection(IServiceCollection services)
        {
            //Domain
            services.AddSingleton<IStockItemDomain, StockItemDomain>();
            services.AddSingleton<IStockItemService, StockItemService>();

            //Repositories
            services.AddSingleton<IStockItemRepository, StockItemRepository>();
            services.AddSingleton<IBaseRepository, BaseRepository>();

        }

        private void RegisterCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin", 
                builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
        }

        private MapperConfiguration configureAutoMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StockItemViewModel, StockItem>()
                    .ConstructUsing(c => new StockItem()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Amount = c.Amount,
                        UnitPrice = c.UnitPrice,
                        IsDeleted = true
                    });
                cfg.CreateMap<StockItem, StockItemViewModel>();
            });
        }
    }
}
