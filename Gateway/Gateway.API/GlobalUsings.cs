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

// GrpcServices
global using Gateway.API.gRPC;
global using static OfferService.GrpcOffersService;
global using static ClientService.GrpcClientServices;
global using static ProjectService.GrpcProjectService;
global using static EmployeeService.GrpcEmployeeService;