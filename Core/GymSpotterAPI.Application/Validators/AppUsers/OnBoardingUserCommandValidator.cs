using FluentValidation;
using GymSpotterAPI.Application.Commands.AppUser.OnBoardingUser;

namespace GymSpotterAPI.Application.Validators.AppUsers
{
    public class OnBoardingUserCommandValidator:AbstractValidator<OnBoardingUserCommandRequest>
    {
        public OnBoardingUserCommandValidator()
        {

            RuleFor(x => x.SelectedWeight).InclusiveBetween(0, 300).WithMessage("Weight must be between 0 and 300.");
            RuleFor(x => x.SelectedHeight).InclusiveBetween(0, 250).WithMessage("Height must be between 0 and 250.");
            RuleFor(x => x.SelectedGender).IsInEnum().WithMessage("Invalid gender.");
            RuleFor(x => x.SelectedLevel).IsInEnum().WithMessage("Invalid level.");
            RuleFor(x => x.SelectedGoal).IsInEnum().WithMessage("Invalid goal.");

        }
    }
}
