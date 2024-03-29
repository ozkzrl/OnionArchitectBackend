using GymSpotterAPI.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSpotterAPI.Application.Commands.AppUser.GetUser
{
    public class GetUserCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }


        public string? NameSurname { get; set; }
        public string? UserName { get; set; }
        
        public string  Email {  get; set; }
        public Gender Gender { get; set; }
        public string? DisplayNameGender { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public Level Level { get; set; }
        public string? DisplayNameLevel { get; set; }
        public Goal Goal { get; set; }
        public string? DisplayNameGoal { get; set; }
    }
}
