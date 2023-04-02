namespace Sisreq.Identity.API.Config;

public static class SwaggerConfig
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Identity API", Version = "v1" , Description = "API responsible for managing Sisreq's Users and Accesses"});
        });

        services.AddSwaggerGen();
        services.AddControllers();
    }

    public static void Configure(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity API - Production");
            });
        }
        else if (env.IsStaging())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity API - Staging");
            });
        }
        else if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity API");
            });
        }
    }
}