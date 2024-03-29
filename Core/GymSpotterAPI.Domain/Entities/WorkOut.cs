using GymSpotterAPI.Domain.Entities.Common;
using GymSpotterAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSpotterAPI.Domain.Entities
{
    public class WorkOut:BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string title { get; set; }
        public string subtitle {  get; set; }
        public string description { get; set; }
        public string Imgurl {  get; set; }
        public WorkOutType WorkOutType { get; set; }
        public string? DisplayNameWorkOut { get; set; }
    }
}
