using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSpotterAPI.Domain.Entities.Identity;

namespace GymSpotterAPI.Application.Commands.AppUser.CreateUser
{
   

    public class CreateUserCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
