using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ZetsubouGacha.Models;
using ZetsubouGacha.Services;
using ZetsubouGacha.Settings;

namespace ZetsubouGacha {
public class Startup {
  public Startup(IConfiguration configuration) {
    Configuration = configuration;
  }

  public IConfiguration Configuration { get; }

  // This method gets called by the runtime. Use this method to add services to
  // the container.
  public void ConfigureServices(IServiceCollection services) {
    services.AddCors();
    services.AddControllers();
    services.Configure<DatabaseSettings>(
        Configuration.GetSection(nameof(DatabaseSettings)));

    services.AddSingleton(
        sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

    services.AddSingleton<IServantRepository, ServantService>();
  }

  // This method gets called by the runtime. Use this method to configure the
  // HTTP request pipeline.
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
    if (env.EnvironmentName == "Development") {

      app.UseDeveloperExceptionPage();
    } else {
      app.UseExceptionHandler("/Error");
      // The default HSTS value is 30 days. You may want to change this for
      // production scenarios, see https://aka.ms/aspnetcore-hsts.
      app.UseHsts();
    }

    // STRICTLY DEVELOPMENT ONLY.
    app.UseCors(builder =>
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();
    app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
  }
}
}