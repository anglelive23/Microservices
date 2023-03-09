global using Serilog;
global using Mapster;
global using Grpc.Net.Client;
global using Google.Protobuf.WellKnownTypes;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using System.ComponentModel.DataAnnotations;
global using Microservices.API.Entities.Data;
global using Microservices.API.Entities.Repos;
global using Microservices.API.Entities.Models;
global using Microservices.API.Entities.Dtos.DTO.Response;


// GrpcServices
global using static OfferService.GrpcOffersService;
global using static ClientService.GrpcClientServices;