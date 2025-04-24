using Business.Factories;
using Business.Interfaces;
using Data.Interfaces;
using Domain.Models;
using Domain.Models.ResponseHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Business.Services;

public class StatusService(IStatusRepository statusRepository) : IStatusService
{
    private readonly IStatusRepository _statusRepository = statusRepository;


    public async Task<StatusResponse<IEnumerable<Status>>> GetAllStatusAsync()
    {
        try
        {
            var statusEntities = await _statusRepository.GetAllAsync();
            if (statusEntities.Content.IsNullOrEmpty())
            {
                return new StatusResponse<IEnumerable<Status>>()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "The list is null or empty.",
                    Content = []
                };
            }

            var statuses = statusEntities.Content.Select(StatusFactory.Create);
            return new StatusResponse<IEnumerable<Status>>()
            {
                Success = true,
                StatusCode = 200,
                Content = statuses
            };
        }
        catch (Exception ex) 
        {
            return new StatusResponse<IEnumerable<Status>>()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}",
                Content = []
            };
        }
    }



}
