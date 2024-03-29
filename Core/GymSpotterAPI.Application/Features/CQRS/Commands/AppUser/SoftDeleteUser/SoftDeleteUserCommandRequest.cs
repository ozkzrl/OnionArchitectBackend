using GymSpotterAPI.Application.Commands.SoftDeleteUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSpotterAPI.Application.Commands.AppUser.SoftDeleteUser
{
    public class SoftDeleteUserCommandRequest : IRequest<SoftDeleteUserCommandResponse>
    {
        public SoftDeleteUserCommandRequest(string accessToken)
        {
            this.accessToken = accessToken;

        }

        public string accessToken { get; set; }
    }
}
