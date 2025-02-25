﻿global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Options;
global using ECHO.Infrastructure.Core.Configuration;
global using ECHO.SharedKernel;
global using ECHO.SharedKernel.ApiService.Authentication;
global using ECHO.SharedKernel.ApiService.Authentication.JwtBearer;
global using ECHO.SharedKernel.ApiService.Authorization;
global using ECHO.SharedKernel.Application.Contracts.Dtos;
global using ECHO.SharedKernel.Const.Permissions.Usr;
global using ECHO.Usr.Contracts.Dtos;
global using ECHO.Usr.Contracts.Services;
global using System.IdentityModel.Tokens.Jwt;