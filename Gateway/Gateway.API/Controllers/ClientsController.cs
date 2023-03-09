﻿using Microservices.API.gRPC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        #region Services
        private readonly IClientsGrpcDataClient _grpc;
        #endregion

        #region Construcotors
        public ClientsController(IClientsGrpcDataClient grpc)
        {
            _grpc = grpc;
        }
        #endregion

        [HttpGet("Clients")]
        [ProducesResponseType(200, Type = typeof(List<ClientResponseDto>))]
        [OutputCache(PolicyName = "Clients")]
        public async Task<IActionResult> GetAllClients()
        {
            try
            {
                Log.Information("Starting controller Company action GetAllClients.");
                var clients = _grpc.GetAllClients();

                return await Task.FromResult(Ok(clients));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}