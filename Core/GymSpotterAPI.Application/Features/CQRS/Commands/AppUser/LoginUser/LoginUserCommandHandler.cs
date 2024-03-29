﻿using GymSpotterAPI.Application.Abstractions.Token;
using GymSpotterAPI.Application.Commands.AppUser.LoginUser;
using GymSpotterAPI.Application.DTOs;
using GymSpotterAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable


namespace GymSpotterAPI.Application.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {

        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

       readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;

        private readonly ITokenHandler _tokenHandler;

        
        public LoginUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, SignInManager<Domain.Entities.Identity.AppUser>  signInManager,ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            
        }

     



        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(request.UserNameorEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UserNameorEmail);

            if (user == null)
                throw new NotFoundUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)//Authentication başarılı.
            {
                Token token = _tokenHandler.CreateAccessToken(5, user.Id);
                return new LoginUserSuccessCommandResponse()
                {
                    Token = token
                };
            }
            throw new AuthenticationErrorException();
        }
    }
}


