using GymSpotterAPI.Domain.Entities.Identity;
using GymSpotterAPI.Application.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GymSpotterAPI.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string Id { get; set; }
        public string? NameSurname { get; set; }
        public override string? UserName { get; set; }
        public override string? Email { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
        public bool IsActive { get; set; }
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


