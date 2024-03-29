using GymSpotterAPI.Application.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSpotterAPI.Application.Commands.AppUser.GetUser
{
    public class GetUserCommandRequest: IRequest<GetUserCommandResponse>
    {
        public GetUserCommandRequest(string accessToken)
        {
            this.accessToken = accessToken;
        }

        public string accessToken { get; set; }
       
    }
}
