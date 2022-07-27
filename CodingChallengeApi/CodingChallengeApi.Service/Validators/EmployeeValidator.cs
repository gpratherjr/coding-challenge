using CodingChallengeApi.Core.Models;
using FluentValidation;

namespace CodingChallengeApi.Service.Validators;
public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(e => e.FirstName).NotEmpty();
        RuleFor(e => e.LastName).NotEmpty();
    }
}
