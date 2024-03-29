using GymSpotterAPI.Application.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSpotterAPI.Application.Commands.AppUser.UpdateUser
{
    public class UpdateUserCommandRequest:IRequest<UpdateUserCommandResponse>
    {

        public UpdateUserCommandRequest(string accessToken)
        {
            this.accessToken = accessToken;

        }


        public string accessToken { get; set; }
        public string? NameSurname { get; set; }
        public string? UserName { get; set; }
        public Gender? Gender { get; set; } 
        public DateTime dateofBirth { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public Level? Level { get; set; }
        public Goal? Goal { get; set; }
       
    }
}
