using GymSpotterAPI.Application.Commands.AppUser.GetUser;
using GymSpotterAPI.Application.Commands.AppUser.OnBoardingUser;
using GymSpotterAPI.Application.Enums;
using GymSpotterAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class GetUserCommandHandler : IRequestHandler<GetUserCommandRequest, GetUserCommandResponse>
{
    private readonly UserManager<AppUser> _userManager;

    public GetUserCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<GetUserCommandResponse> Handle(GetUserCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (string.IsNullOrEmpty(request.accessToken))
            {
                return new GetUserCommandResponse { Success = false, Message = "Token is null or empty." };
            }

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(request.accessToken) as JwtSecurityToken;

            if (jsonToken == null)
            {
                return new GetUserCommandResponse { Success = false, Message = "Invalid token format." };
            }

            var userId = jsonToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrEmpty(userId))
            {
                var existingUser = await _userManager.FindByIdAsync(userId);

                if (existingUser != null)
                {
                    var userResponse = new GetUserCommandResponse
                    {
                        Success = true,
                        Message = "User profile successfully listed.",
                        NameSurname = existingUser.NameSurname,
                        UserName = existingUser.UserName,
                        Email=existingUser.Email,
                        Gender = existingUser.Gender,
                        DisplayNameGender = existingUser.DisplayNameGender,
                        Age = existingUser.Age,
                        Weight = existingUser.Weight,
                        Height = existingUser.Height,
                        Level = existingUser.Level,
                        DisplayNameLevel = existingUser.DisplayNameLevel,
                        Goal = existingUser.Goal,
                        DisplayNameGoal = existingUser.DisplayNameGoal
                    };

                    return userResponse;
                }
                else
                {
                    return new GetUserCommandResponse { Success = false, Message = "User not found." };
                }
            }
            else
            {
                return new GetUserCommandResponse { Success = false, Message = "User ID not found in the token." };
            }
        }
        catch (Exception ex)
        {
            // Hata işleme
            return new GetUserCommandResponse { Success = false, Message = $"An error occurred: {ex.Message}" };
        }
    }
}
