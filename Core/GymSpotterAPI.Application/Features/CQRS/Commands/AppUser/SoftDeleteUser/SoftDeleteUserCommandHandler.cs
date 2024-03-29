using GymSpotterAPI.Application.Commands.AppUser.OnBoardingUser;
using GymSpotterAPI.Application.Commands.AppUser.SoftDeleteUser;
using GymSpotterAPI.Application.Commands.AppUser.UpdateUser;
using GymSpotterAPI.Application.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GymSpotterAPI.Application.Commands.SoftDeleteUser
{
    public class SoftDeleteUserCommandHandler : IRequestHandler<SoftDeleteUserCommandRequest, SoftDeleteUserCommandResponse>
    {

        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public SoftDeleteUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public  async Task<SoftDeleteUserCommandResponse> Handle(SoftDeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(request.accessToken))
                {
                    return new SoftDeleteUserCommandResponse { Success = false, Message = "Token is null or empty." };
                }

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(request.accessToken) as JwtSecurityToken;

                if (jsonToken == null)
                {
                    return new SoftDeleteUserCommandResponse { Success = false, Message = "Invalid token format." };
                }

                var UserId = jsonToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;

                if (!string.IsNullOrEmpty(UserId))
                {
                    var existingUser = await _userManager.FindByIdAsync(UserId);

                    if (existingUser != null)
                    {
                        existingUser.IsActive=false;

                        await _userManager.UpdateAsync(existingUser);
                        return new SoftDeleteUserCommandResponse { Success = true, Message = "User profile successfully deleted." };
                    }
                    else
                    {
                        return new SoftDeleteUserCommandResponse { Success = false, Message = "User not found." };
                    }
                }
                else
                {
                    return new SoftDeleteUserCommandResponse { Success = false, Message = "User ID not found in the token." };
                }
            }
            catch (Exception ex)
            {
                return new SoftDeleteUserCommandResponse { Success = false, Message = ex.Message };
            }
        }
    }
}

