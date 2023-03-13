global using Serilog;
global using Mapster;
global using Grpc.Net.Client;
global using Google.Protobuf.WellKnownTypes;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using System.ComponentModel.DataAnnotations;
global using Gateway.API.Entities.Data;
global using Gateway.API.Entities.Models;
global using Gateway.API.Entities.Dtos.DTO.Response;
global using Microsoft.AspNetCore.OutputCaching;

// OData
global using Microsoft.OData.Edm;
global using Microsoft.OData.ModelBuilder;
global using Microsoft.AspNetCore.OData.Query;

// GrpcServices
global using Gateway.API.Entities.gRPC;
global using static OfferService.GrpcOffersService;
global using static ClientService.GrpcClientServices;
global using static ProjectService.GrpcProjectService;
global using static EmployeeService.GrpcEmployeeService;