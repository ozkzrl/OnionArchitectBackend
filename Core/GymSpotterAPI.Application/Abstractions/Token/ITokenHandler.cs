using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;



namespace GymSpotterAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {

        DTOs.Token CreateAccessToken(int minute, string userId);
        
    }
}

