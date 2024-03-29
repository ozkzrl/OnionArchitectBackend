using GymSpotterAPI.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSpotterAPI.Application.Commands.AppUser.UpdateUser
{
    public class UpdateUserCommandResponse
    {
        
        public bool Success { get; set; }
        public string Message { get; set; }
        public string? NameSurname { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public Level Level { get; set; }
        public Goal Goal { get; set; }

    }
}
