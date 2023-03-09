using Microservices.API.Entities.Dtos.DTO.Response;
using Microservices.API.gRPC;
using Microsoft.AspNetCore.OutputCaching;

namespace Microservices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOffersGrpcDataClient _offersGrpc;
        private readonly IClientsGrpcDataClient _clitentsGrpc;

        public CompanyController(IUnitOfWork unitOfWork, IOffersGrpcDataClient offersGrpc, IClientsGrpcDataClient clitentsGrpc)
        {
            _unitOfWork = unitOfWork;
            _offersGrpc = offersGrpc;
            _clitentsGrpc = clitentsGrpc;
        }

        [HttpGet("Services")]
        [ProducesResponseType(200, Type = typeof(List<ServicesResponseDto>))]
        [OutputCache(PolicyName = "Services")]
        public IActionResult GetAllServices()
        {
            try
            {
                var services = _offersGrpc.GetAllServices();
                return Ok(services);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Projects")]
        [ProducesResponseType(200, Type = typeof(List<ProjectResponseDto>))]
        [OutputCache(PolicyName = "Projects")]
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                Log.Information("Starting controller Company action GetAllProjects.");
                var projects = await _unitOfWork.Projects.GetAllAsync();

                if (!projects.Any())
                    return NotFound("Projects is null or empty.");

                Log.Information("Returning all Projects to the caller.");
                return Ok(projects.Adapt<List<ProjectResponseDto>>());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Clients")]
        [ProducesResponseType(200, Type = typeof(List<ClientResponseDto>))]
        [OutputCache(PolicyName = "Clients")]
        public async Task<IActionResult> GetAllClients()
        {
            try
            {
                Log.Information("Starting controller Company action GetAllClients.");
                var clients = _clitentsGrpc.GetAllClients();

                return await Task.FromResult(Ok(clients));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Employees")]
        [ProducesResponseType(200, Type = typeof(List<EmployeeResponseDto>))]
        [OutputCache(PolicyName = "Employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                Log.Information("Starting controller Company action GetAllEmployees.");
                var employees = await _unitOfWork.Employees.GetAllAsync();

                if (!employees.Any())
                    return NotFound("Employees is null or empty.");

                Log.Information("Returning all Clients to the caller.");
                return Ok(employees.Adapt<List<EmployeeResponseDto>>());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
