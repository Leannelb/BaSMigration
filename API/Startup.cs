using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using API.Middleware;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using API.Errors;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        //configure sets up our dependancy injection functionality allowing us to inject services
        //we'll add our own services for
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();
            services.AddDbContext<StoreContext>(X => 
                X.UseSqlite(_config.GetConnectionString("DefaultConnection")));
        
            services.Configure<ApiBehaviorOptions>( options => 
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                var errorResponse = new ApiValidationErrorResponse
                {
                    Errors = errors
                };
                return new BadRequestObjectResult(errorResponse);
                };
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SkiNet API", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // This is the execption handling middlewaear, we are only handling dev mode errors atm 
            // responses#

            /* Were going to replace this dev middlewear with our own: 
            *   if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            *
            */

// the order here is important, its the order their run

//the block of text above, within the /**/ is reoplaced by
           app.UseMiddleware<ExceptionMiddleware>();
            
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            
            // have an error telling me 'ApiValidationErrorResponse' does not contain a definition for 'Errors' [API]
            // Continue on however as the code for section 5 surpasses this and will change again - there is no code for comparision so get to end of 5 and see where you stand
            app.UseSwaggerUI(c => 
                {c.SwaggerEndpoint("/swagger/v1/swagger.json", "Skinet API v1");});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
