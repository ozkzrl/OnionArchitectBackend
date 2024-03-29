using GymSpotterAPI.Application.Exceptions;
using MediatR;
using MediatR.Wrappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSpotterAPI.Application.Commands.AppUser.OutLoginUser;
using Microsoft.AspNetCore.Mvc;

namespace GymSpotterAPI.Application.Commands.AppUser.OutLoginUser
{

    public class OutLoginUserCommandHandler : IRequestHandler<OutLoginUserCommandRequest, OutLoginUserCommandResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

   
        


        public OutLoginUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
            

        }

        public async Task<OutLoginUserCommandResponse> Handle(OutLoginUserCommandRequest request, CancellationToken cancellationToken)
        {


            Domain.Entities.Identity.AppUser user = await _userManager.FindByEmailAsync(request.email);

            if (user == null)
            {
                return new OutLoginUserCommandResponse
                {
                    Success = false,
                    Message= "Email bulunamadı."
                };
            }

            Domain.Entities.Identity.AppUser result=  _userManager.Users.FirstOrDefault(u=>u.Email ==request.email);

            if(result!=null)
            {
                return new OutLoginUserCommandResponse
                {
                    Success = true,
                    Message = "Email başarıyla bulundu."
                };
            }

            throw new Exception();
        }
    }
}

