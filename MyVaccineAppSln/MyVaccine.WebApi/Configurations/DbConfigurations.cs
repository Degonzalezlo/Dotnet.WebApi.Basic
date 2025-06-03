using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Literals;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations;

public static class DbConfigurations
{
    public static IServiceCollection SetDatabaseConfiguration(this IServiceCollection services)
    {
        //var conecctionString = Environment.GetEnvironmentVariable(MyVaccineLiterals.CONNECTION_STRING);
        var conecctionString = "Server=localhost,14330;Database=MyVaccineAppDb;User=sa;Password=OtraClaveSegura123!;TrustServerCertificate=true;";
        services.AddDbContext<MyVaccineAppDbContext>( options =>
                options.UseSqlServer(
                            conecctionString
                    )
                );
      
        return services;
    }
}
