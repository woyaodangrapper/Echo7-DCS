﻿global using Castle.DynamicProxy;
global using FluentValidation;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using ECHO.Infrastructure.Core.DependencyInjection;
global using ECHO.Infrastructure.Core.Interfaces;
global using ECHO.Infrastructure.Core.Json;
global using ECHO.Infrastructure.Entities;
global using ECHO.Infrastructure.Helper;
global using ECHO.Infrastructure.IdGenerater.Yitter;
global using ECHO.Infrastructure.IRepositories;
global using ECHO.Infrastructure.Mapper;
global using ECHO.Infrastructure.Redis;
global using ECHO.Infrastructure.Redis.Caching;
global using ECHO.Infrastructure.Redis.Caching.Core;
global using ECHO.Infrastructure.Redis.Caching.Core.Diagnostics;
global using ECHO.Infrastructure.Redis.Configurations;
global using ECHO.Infrastructure.Redis.Core;
global using ECHO.SharedKernel.Application.BloomFilter;
global using ECHO.SharedKernel.Application.Caching;
global using ECHO.SharedKernel.Application.Contracts.Attributes;
global using ECHO.SharedKernel.Application.Contracts.Enums;
global using ECHO.SharedKernel.Application.Contracts.Interfaces;
global using ECHO.SharedKernel.Application.Contracts.ResultModels;
global using ECHO.SharedKernel.Application.Interceptors;
global using ECHO.SharedKernel.Const.Caching.Common;
global using ECHO.SharedKernel.Repository.EfEntities;
global using ECHO.SharedKernel.Repository.MongoEntities;
global using Polly;
global using SkyApm;
global using SkyApm.Common;
global using SkyApm.Config;
global using SkyApm.Diagnostics;
global using SkyApm.Tracing;
global using SkyApm.Tracing.Segments;
global using SkyApm.Utilities.DependencyInjection;
global using System.Diagnostics.CodeAnalysis;
global using System.Linq.Expressions;
global using System.Net;
global using System.Reflection;
global using System.Text.Json;