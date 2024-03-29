using GymSpotterAPI.Application.Features.CQRS.Handlers.WorkOutHandlers;
using GymSpotterAPI.Application.Features.CQRS.Queries.WorkOutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymSpotterAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOutsController : ControllerBase
    {
        private readonly GetWorkOutQueryHandler _getWorkOutQueryHandler;

        private readonly GetWorkOutByIdQueryHandler _getWorkOutByIdQueryHandler;

        public WorkOutsController(GetWorkOutQueryHandler getWorkOutQueryHandler, GetWorkOutByIdQueryHandler getWorkOutByIdQueryHandler)
        {
            _getWorkOutQueryHandler = getWorkOutQueryHandler;
            _getWorkOutByIdQueryHandler = getWorkOutByIdQueryHandler;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromHeader] string accessToken, string? titleFilter, string? subtitleFilter, string? descriptionFilter)
        {

            var values = await _getWorkOutQueryHandler.Handle(accessToken);

            if (!string.IsNullOrEmpty(titleFilter) || !string.IsNullOrEmpty(subtitleFilter) || !string.IsNullOrEmpty(descriptionFilter))
            {
                values = values.Where(workout =>
                    (string.IsNullOrEmpty(titleFilter) || workout.title.Contains(titleFilter)) &&
                    (string.IsNullOrEmpty(subtitleFilter) || workout.subtitle.Contains(subtitleFilter)) &&
                    (string.IsNullOrEmpty(descriptionFilter) || workout.description.Contains(descriptionFilter))
                ).ToList();
            }
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromHeader] string accessToken, int id)
        {
            

            var value = await _getWorkOutByIdQueryHandler.Handle(accessToken, id);

            
            if (value == null)
            {
                return NotFound();
            }

            return Ok(value);
        }
    }
}
