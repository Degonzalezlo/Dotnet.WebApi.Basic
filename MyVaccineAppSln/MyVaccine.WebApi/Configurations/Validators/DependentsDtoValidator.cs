using FluentValidation;
using MyVaccine.WebApi.Dtos.Dependent;

namespace MyVaccine.WebApi.Configurations.Validators;

public class DependentsDtoValidator : AbstractValidator<DependentRequestDto>
{
    public DependentsDtoValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().MaximumLength(255);
        RuleFor(dto => dto.DateOfBirth).NotEmpty();
        RuleFor(dto => dto.UserId).NotEmpty().GreaterThan(0);
    }
}
