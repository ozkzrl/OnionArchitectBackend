using GymSpotterAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSpotterAPI.Domain.Entities.Common
{
    public class BaseEntity
    {

        public int Id { get; set; } 

        public DateTime CreateDateTime { get; set; }
        

    }
}
