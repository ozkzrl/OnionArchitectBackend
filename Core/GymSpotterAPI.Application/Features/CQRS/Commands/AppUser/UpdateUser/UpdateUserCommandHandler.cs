using GymSpotterAPI.Application.Commands.AppUser.OnBoardingUser;
using GymSpotterAPI.Application.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GymSpotterAPI.Application.Commands.AppUser.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;


        public UpdateUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }

       
        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {

            try
            {
                if (string.IsNullOrEmpty(request.accessToken))
                {
                    return new UpdateUserCommandResponse { Success = false, Message = "Token is null or empty." };
                }

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(request.accessToken) as JwtSecurityToken;

                if (jsonToken == null)
                {
                    return new UpdateUserCommandResponse { Success = false, Message = "Invalid token format." };
                }

                var userId = jsonToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;

                if (!string.IsNullOrEmpty(userId))
                {
                    var existingUser = await _userManager.FindByIdAsync(userId);

                    if (existingUser != null)
                    {
                        // Update işlemi


                        existingUser.NameSurname = request.NameSurname;
                        existingUser.Gender = request.Gender ?? existingUser.Gender;
                        existingUser.DisplayNameGender = request.Gender != null ? Enum.GetName(typeof(Gender), existingUser.Gender) : existingUser.DisplayNameGender;
                        existingUser.Age = request.dateofBirth != null ? CalculateAge(request.dateofBirth) : existingUser.Age;
                        existingUser.Goal = request.Goal ?? existingUser.Goal;
                        existingUser.DisplayNameGoal = request.Goal != null ? Enum.GetName(typeof(Goal), existingUser.Goal) : existingUser.DisplayNameGoal;
                        existingUser.Height = request.Height ?? existingUser.Height;
                        existingUser.Level = request.Level ?? existingUser.Level;
                        existingUser.DisplayNameLevel = request.Level != null ? Enum.GetName(typeof(Level), existingUser.Level) : existingUser.DisplayNameLevel;         
                        existingUser.Weight = request.Weight ?? existingUser.Weight;
                        
                        
                        


                        

                        await _userManager.UpdateAsync(existingUser);
                        return new UpdateUserCommandResponse { Success = true, Message = "User profile successfully updated." };
                    }
                    else
                    {
                        return new UpdateUserCommandResponse { Success = false, Message = "User not found." };
                    }
                }
                else
                {
                    return new UpdateUserCommandResponse { Success = false, Message = "User ID not found in the token." };
                }
            }
            catch (Exception ex)
            {
                return new UpdateUserCommandResponse { Success = false, Message = ex.Message };
            }

        }
        private int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
