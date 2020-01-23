using AutoMapper;
using CoreCodeCamp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CoreCodeCamp
{
    public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<CampContext>();
        services.AddScoped<ICampRepository, CampRepository>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddApiVersioning(opt =>
        {
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.DefaultApiVersion = new ApiVersion(1,1);
            opt.ReportApiVersions = true;
            opt.ApiVersionReader = new HeaderApiVersionReader("X-Version");
            //opt.ApiVersionReader = new QueryStringApiVersionReader("ver");


        });  

        services.AddMvc(opt => opt.EnableEndpointRouting = false)
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      
      app.UseMvc();
    }
  }
}
