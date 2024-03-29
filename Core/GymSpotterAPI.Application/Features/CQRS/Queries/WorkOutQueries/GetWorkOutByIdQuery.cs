using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSpotterAPI.Application.Features.CQRS.Queries.WorkOutQueries
{
    public class GetWorkOutByIdQuery
    {
        public int Id { get; set; }

        public GetWorkOutByIdQuery(int id)
        {
            Id = id;
        }
    }
}
