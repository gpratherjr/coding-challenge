using CodingChallengeApi.Data.Abstractions;
using CodingChallengeApi.Data.Implementations;
using CodingChallengeApi.Service.Abstractions;
using CodingChallengeApi.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace CodingChallengeApi.Configuration;
public class DependencyInjection
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
        services.AddSingleton<IEmployeeService, EmployeeService>();
    }
}
