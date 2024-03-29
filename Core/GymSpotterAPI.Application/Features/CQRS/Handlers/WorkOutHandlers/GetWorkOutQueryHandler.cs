using GymSpotterAPI.Application.Enums;
using GymSpotterAPI.Application.Features.CQRS.Results.WorkOutResults;
using GymSpotterAPI.Domain.Entities;
using GymSpotterAPI.Domain.Enums;
using MediatR;
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
    public class GetWorkOutQueryHandler
    {

        private readonly IRepository<WorkOut> _Repository;

        public GetWorkOutQueryHandler(IRepository<WorkOut> repository)
        {
            _Repository = repository;
        }

        public async Task<List<GetWorkOutQueryResult>> Handle(string accessToken)
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
            var values = await _Repository.GetAllAsync();
            return values.Select(x => new GetWorkOutQueryResult
            {
                Id = x.Id,
                WorkOutType = x.WorkOutType,
                DisplayNameWorkOut = x.DisplayNameWorkOut,
                title = x.title,
                subtitle = x.subtitle,
                description = x.description,
                Imgurl = x.Imgurl,
                CreateDateTime = x.CreateDateTime
            }).ToList();
        }
    }
}