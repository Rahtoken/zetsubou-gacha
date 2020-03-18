using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ZetsubouGacha.Databases;
using ZetsubouGacha.Servants.Models;
using ZetsubouGacha.Services;
using ZetsubouGacha.Settings;

namespace ZetsubouGacha
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to
        // the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.Configure<DatabaseSettings>(
                Configuration.GetSection(nameof(DatabaseSettings)));
            services.AddSingleton(
                sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            services.AddSingleton<IMongoDatabaseFactory, MongoDatabaseFactory>();
            services.AddSingleton<IRepositoryFactory, RepositoryFactory>();

            services.AddSingleton<IDbContext, DbContext>(
                sp => 
                {
                    var dbSettings = sp.GetService<DatabaseSettings>();
                    return new DbContext(
                        sp.GetService<IRepositoryFactory>(), 
                        dbSettings.ConnectionString, 
                        dbSettings.Database);
                }
            );

            services.AddSingleton<IServantRepository>(
                sp => 
                {
                    var dbContext = sp.GetService<IDbContext>();
                    return dbContext.Servants;
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the
        // HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Development")
            {

                app.UseDeveloperExceptionPage();
                app.UseCors(builder =>
                            builder.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for
                // production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
