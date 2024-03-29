using GymSpotterAPI.Application.Enums;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GymSpotterAPI.Application.Commands.AppUser.OnBoardingUser
{
    public class OnBoardingUserCommandRequest:IRequest<OnBoardingUserCommandResponse>
    {

        public OnBoardingUserCommandRequest(string accessToken)
        {
            this.accessToken = accessToken;
            
        }

        public string accessToken { get; set; } 
        public Gender? SelectedGender { get; set; } 
        public DateTime dateofBirth { get; set; }
        public int? SelectedWeight { get; set; }  
        public int? SelectedHeight { get; set; }
        public Level? SelectedLevel { get; set; }
        public Goal? SelectedGoal { get; set; }

    }
}
