using Microsoft.OpenApi.Models;

namespace Sisreq.Identity.API.Config;

public static class SwaggerConfig
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });


        services.AddSwaggerGen();
        services.AddControllers();
    }

    public static void Configure(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            // Configuração do Swagger para o ambiente de desenvolvimento
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
        else if (env.IsStaging())
        {
            // Configuração do Swagger para o ambiente de staging
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1 - Staging");
            });
        }
        else if (env.IsProduction())
        {
            // Configuração do Swagger para o ambiente de produção
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1 - Production");
            });
        }
    }
}