using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProductManagement.Domain.Handlers;
using ProductManagement.Domain.Queries;
using ProductManagement.Domain.Repositories;
using ProductManagement.Infrastructure.Context;
using ProductManagement.Infrastructure.Repositories;
using ProductManagement.Services.Queries;
using System.Configuration;

namespace ProductManagement.API
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
            services.AddControllers();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductManagement.Api", Version = "v1" });                
            });

            var connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            services.AddTransient<AssociateProductWithCategoryHandler, AssociateProductWithCategoryHandler>();
            services.AddTransient<CategoryHandler, CategoryHandler>();
            services.AddTransient<ProductHandler, ProductHandler>();
            services.AddTransient<IAssociateProductWithCategoryRepository, AssociateProductWithCategoryRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IAssociateProductWithCategoryQueries>(provider => new AssociateProductWithCategoryQueries(connection));            
            services.AddTransient<ICategoryQueries>(provider => new CategoryQueries(connection));
            services.AddTransient<IProductQueries>(provider => new ProductQueries(connection));

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductManagement.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
