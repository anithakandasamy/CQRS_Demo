using FluentValidation;

namespace CQRS_Implementation.Features.Users.Commands.Create
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(model => model.Id).NotNull().NotEmpty().WithMessage("Id can't be empty");
            RuleFor(model => model.Id).LessThanOrEqualTo(0).WithMessage("Id must be greater than 0");
            RuleFor(model => model.Name).NotNull().NotEmpty().WithMessage("The Name can't be empty.");
            RuleFor(model => model.Name).MaximumLength(100).WithMessage("Name must not exceed 100 characters");
            RuleFor(model => model.EmailId).NotNull().NotEmpty();
            RuleFor(model => model.EmailId).MaximumLength(50).WithMessage("EmailId must not exceed 50 characters");
            RuleFor(model => model.ShortId).NotNull().NotEmpty();
            RuleFor(model => model.ShortId).MaximumLength(6).WithMessage("ShortId must not exceed 6 characters");
        }
    }
}
