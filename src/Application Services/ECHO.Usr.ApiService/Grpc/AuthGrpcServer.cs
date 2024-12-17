﻿using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ECHO.Infrastructure.Mapper;
using ECHO.SharedKernel.Rpc.Grpc.Messages;
using ECHO.SharedKernel.Rpc.Grpc.Services;

namespace ECHO.User.ApiService.Grpc;

public class AuthGrpcServer : AuthGrpc.AuthGrpcBase
{
    private readonly IOptions<JWTOptions> _jwtOptions;
    private readonly IAccountAppService _accountService;
    private readonly IObjectMapper _mapper;

    public AuthGrpcServer(
        IOptions<JWTOptions> jwtOptions
        , IAccountAppService accountService
        , IObjectMapper mapper)
    {
        _jwtOptions = jwtOptions;
        _accountService = accountService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    public override async Task<GrpcResponse> Login(LoginRequest request, ServerCallContext context)
    {
        var loginDto = _mapper.Map<UserLoginDto>(request);
        var loginResult = await _accountService.LoginAsync(loginDto);
        var grpcResponse = new GrpcResponse() { IsSuccessStatusCode = loginResult.IsSuccess };
        if (!grpcResponse.IsSuccessStatusCode)
        {
            grpcResponse.Error = loginResult.ProblemDetails?.Detail;
            return grpcResponse;
        }

        var validatedInfo = loginResult.Content;
        var loginReply = new LoginReply
        {
            Token = JwtTokenHelper.CreateAccessToken(_jwtOptions.Value, validatedInfo.ValidationVersion, validatedInfo.Account, validatedInfo.Id.ToString(), validatedInfo.Name, validatedInfo.RoleIds, JwtBearerDefaults.Manager).Token,
            RefreshToken = JwtTokenHelper.CreateRefreshToken(_jwtOptions.Value, validatedInfo.ValidationVersion, validatedInfo.Id.ToString()).Token
        };
        grpcResponse.Content = Any.Pack(loginReply);
        return grpcResponse;
    }
}