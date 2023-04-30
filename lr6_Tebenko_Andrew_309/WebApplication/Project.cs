using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace WebApplication;

public class Project
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("version 1", new OpenApiInfo { Title = "First project - Tebenko Andrew", Version = "version 1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "First project - Tebenko Andrew");
            c.DocExpansion(DocExpansion.None);
        });
    }    
}