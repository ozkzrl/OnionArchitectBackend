using FluentValidation;
using GymSpotterAPI.Application.Commands.AppUser.CreateUser;
using GymSpotterAPI.Application.Commands.AppUser.GetUser;
using GymSpotterAPI.Application.Commands.AppUser.LoginUser;
using GymSpotterAPI.Application.Commands.AppUser.OnBoardingUser;
using GymSpotterAPI.Application.Commands.AppUser.OutLoginUser;
using GymSpotterAPI.Application.Commands.AppUser.SoftDeleteUser;
using GymSpotterAPI.Application.Commands.AppUser.UpdateUser;
using GymSpotterAPI.Application.Commands.SoftDeleteUser;
using GymSpotterAPI.Application.Validators.AppUsers;
using GymSpotterAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace GymSpotterAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;
        private UpdateUserCommandRequest updateUserCommandRequest;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            var validator = new CreateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(createUserCommandRequest);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }

            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }


        [HttpPost("[action]")]

        public async Task<IActionResult> OutLogin(OutLoginUserCommandRequest outLoginUserCommandRequest)
        {
            OutLoginUserCommandResponse result = await _mediator.Send(outLoginUserCommandRequest);
            return Ok(result);
        }



        [HttpPut("onboarding")]
        public async Task<IActionResult> OnBoarding([FromBody] OnBoardingUserCommandRequest request, [FromHeader] string accessToken)
        {
            var validator = new OnBoardingUserCommandValidator(); 
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }

            request.accessToken = accessToken;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(request);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet("getUser")]
        public async Task<IActionResult> GetUser([FromHeader] string accessToken)
        {
            try
            {
                var response = await _mediator.Send<GetUserCommandResponse>(new GetUserCommandRequest(accessToken));



                if (response.Success)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandRequest request, [FromHeader] string accessToken)
        {

            var validator = new UpdateUserCommandValidator(); 
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }

            request.accessToken = accessToken;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(request);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }


        [HttpDelete("softDeleteUser")]
        public async Task<IActionResult> SoftDeleteUser([FromBody] SoftDeleteUserCommandRequest request, [FromHeader] string accessToken)
        {
            request.accessToken = accessToken;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(request);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

    }
}    

    


