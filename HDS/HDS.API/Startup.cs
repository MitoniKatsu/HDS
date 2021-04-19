using System;
using System.IO;
using System.Reflection;
using HDS.Data;
using HDS.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HDS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IHDSContext, HDSContext>(o =>
            {
                var coostring = Configuration.GetValue<string>("HDS_ConnectionString");
                Console.Error.WriteLine(coostring);
                o.UseSqlServer(Configuration.GetValue<string>("HDS_ConnectionString"));
                if (Environment.IsDevelopment())
                {
                    o.EnableSensitiveDataLogging();
                }
            });

            services.AddTransient<ContactMethodRepository>();
            services.AddTransient<CustomerRepository>();
            services.AddTransient<EmployeePositionRepository>();
            services.AddTransient<EmployeeRepository>();
            services.AddTransient<EntityAddressRepository>();
            services.AddTransient<InventoryRepository>();
            services.AddTransient<OrderDetailRepository>();
            services.AddTransient<OrderRepository>();
            services.AddTransient<ServiceRepository>();
            services.AddTransient<StoreRepository>();
            services.AddTransient<StoreRoleRepository>();
            services.AddTransient<TypesRepository>();

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();

            }));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HDS API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HDS API");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
