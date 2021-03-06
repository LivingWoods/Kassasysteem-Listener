using Kassa.Models;
using Microsoft.EntityFrameworkCore;
using Kassa.Services;
using Kassa.Repositories;
using Kassa.Hubs;

namespace Kassa
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = String.Format("Host={0};Port={1};Database={2};Username={3};Password={4};", Environment.GetEnvironmentVariable("DATABASE_HOST"), Environment.GetEnvironmentVariable("DATABASE_PORT"), Environment.GetEnvironmentVariable("DATABASE_NAME"), Environment.GetEnvironmentVariable("DATABASE_USERNAME"), Environment.GetEnvironmentVariable("DATABASE_PASSWORD"));
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "CorsPolicy",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }
                );
            });

            services.AddControllers();
            services.AddScoped<IPrinterService, PrinterService>();
            services.AddScoped<IPrinterRepository, PrinterRepository>();
            services.AddDbContext<ApplicationDbContext>(
                options => options
                                //.UseLazyLoadingProxies()
                                .UseNpgsql(connectionString)
            );

            services.AddSwaggerGen(
                c => c.SwaggerDoc("v1", new() { Title = "Kassa API", Version = "v1" })
            );

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(
                    c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kassa API v1")
                );
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();

                context.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<PrinterHub>("/PrinterHub");
            });
        }
    }
}
