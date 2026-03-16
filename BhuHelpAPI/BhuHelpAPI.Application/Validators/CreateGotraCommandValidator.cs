namespace BhuHelpAPI.Application.Validators;

public class CreateGotraCommandValidator : AbstractValidator<CreateGotraCommand>
{
    public CreateGotraCommandValidator()
    {
        RuleFor(mod => mod.Name).NotEmpty().WithMessage("{Name} is required.");
    }
}
