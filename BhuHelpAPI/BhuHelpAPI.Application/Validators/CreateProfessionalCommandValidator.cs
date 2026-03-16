namespace BhuHelpAPI.Application.Validators;

public class CreateProfessionalCommandValidator : AbstractValidator<CreateProfessionalCommand>
{
    public CreateProfessionalCommandValidator()
    {
        RuleFor(mod => mod.Name).NotNull().WithMessage("{Name} is required");
        RuleFor(mod => mod.Description).NotNull().WithMessage("{Description} is required");
    }
}