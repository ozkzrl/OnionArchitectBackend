using FluentValidation;
using GymSpotterAPI.Application.Commands.AppUser.CreateUser;

namespace GymSpotterAPI.Application.Validators.AppUsers
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Name and surname are required.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
            RuleFor(x => x.PasswordConfirm).Equal(x => x.Password).WithMessage("Passwords do not match.");
            
        }

     
    }
}
