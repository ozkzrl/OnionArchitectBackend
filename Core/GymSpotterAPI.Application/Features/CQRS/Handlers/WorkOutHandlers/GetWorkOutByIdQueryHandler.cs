using GymSpotterAPI.Application.Features.CQRS.Results.WorkOutResults;
using GymSpotterAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces;

namespace GymSpotterAPI.Application.Features.CQRS.Handlers.WorkOutHandlers
{
    public class GetWorkOutByIdQueryHandler
    {

        private readonly IRepository<WorkOut> _Repository;

        public GetWorkOutByIdQueryHandler(IRepository<WorkOut> repository)
        {
            _Repository = repository;
        }

        public async Task<GetWorkOutByIdQueryResult> Handle([FromHeader] string accessToken, int id)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                // Handle case where access token is null or empty
                return null; // Or handle appropriately based on your requirements
            }

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(accessToken) as JwtSecurityToken;

            if (jsonToken == null)
            {
                // Handle case where access token is invalid
                return null; // Or handle appropriately based on your requirements
            }
            var userId = jsonToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
            var value = await _Repository.GetByIdAsync(id);

            // Check if value is null, if yes, handle it accordingly
            if (value == null)
            {
                // Handle case where the item with the given id is not found
                return null; // Or handle appropriately based on your requirements
            }

            return new GetWorkOutByIdQueryResult
            {
                Id = value.Id,
                WorkOutType = value.WorkOutType,
                DisplayNameWorkOut = value.DisplayNameWorkOut,
                title = value.title,
                subtitle = value.subtitle,
                description = value.description,
                Imgurl = value.Imgurl,
                CreateDateTime = value.CreateDateTime
            };
        }

    }
}
