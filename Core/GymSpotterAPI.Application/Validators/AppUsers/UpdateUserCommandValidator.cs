using FluentValidation;
using GymSpotterAPI.Application.Commands.AppUser.UpdateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSpotterAPI.Application.Validators.AppUsers
{
    public class UpdateUserCommandValidator:AbstractValidator<UpdateUserCommandRequest>
    {
        public UpdateUserCommandValidator() {
        RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Name and surname are required.");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required.");
        RuleFor(x => x.Weight).InclusiveBetween(0, 300).WithMessage("Weight must be between 0 and 300.");
        RuleFor(x => x.Height).InclusiveBetween(0, 250).WithMessage("Height must be between 0 and 250.");
        RuleFor(x => x.Gender).IsInEnum().WithMessage("Invalid gender.");
        RuleFor(x => x.Level).IsInEnum().WithMessage("Invalid level.");
        RuleFor(x => x.Goal).IsInEnum().WithMessage("Invalid goal.");
        }
    }
}
