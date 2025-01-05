using BlogApp.BL.DTOs.Options;

namespace BlogApp.API;

public static class ServiceRegistration
{
    public static IServiceCollection AddJwtOptions(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.Jwt));
        return services;
    }
}
