using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Repositories.Implementations;
using MyVaccine.WebApi.Services.Contracts;
using MyVaccine.WebApi.Services.Implementations;



namespace MyVaccine.WebApi.Configurations;

public static class DependencyInjections
{
    public static IServiceCollection SetDependencyInjection(this IServiceCollection services)
    {
        #region Repositories Injection
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBaseRepository<Dependent>, BaseRepository<Dependent>>();
        #endregion

        #region Services Injection
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IDependentService, DependentService>();

        #endregion
        return services;
    }
}
