using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSpotterAPI.Application.Commands.SoftDeleteUser
{
    public class SoftDeleteUserCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
