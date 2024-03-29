using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSpotterAPI.Application.Commands.AppUser.OutLoginUser
{
    public class OutLoginUserCommandRequest:IRequest<OutLoginUserCommandResponse>
    {
        public string email { get; set; }

    }
}
