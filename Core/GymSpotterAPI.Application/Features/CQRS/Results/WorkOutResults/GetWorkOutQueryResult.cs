using GymSpotterAPI.Domain.Entities;
using GymSpotterAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSpotterAPI.Application.Features.CQRS.Results.WorkOutResults
{
    public class GetWorkOutQueryResult
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string description { get; set; }
        public string Imgurl { get; set; }
        public WorkOutType WorkOutType { get; set; }

        public string DisplayNameWorkOut { get; set; }

        public DateTime CreateDateTime {  get; set; }
    }
}
