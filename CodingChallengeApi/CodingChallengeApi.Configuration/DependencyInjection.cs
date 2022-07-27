using CodingChallengeApi.Data.Abstractions;
using CodingChallengeApi.Data.Implementations;
using CodingChallengeApi.Service.Abstractions;
using CodingChallengeApi.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using CodingChallengeApi.Service.Validators;

namespace CodingChallengeApi.Configuration;
public class DependencyInjection
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
        services.AddSingleton<IEmployeeService, EmployeeService>();

        services.AddValidatorsFromAssemblyContaining<EmployeeValidator>();
    }
}
