using AutoMapper;
using Forgor.Security.CQRS.Contracts.User.Quries;
using Forgor.Security.CQRS.Handlers.Logic.User.Helpers;
using Forgor.Security.CQRS.Handlers.ValidationExtensions.User;
using Forgor.Security.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Forgor.Security.CQRS.Handlers.Logic.User.Queries;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, IResult>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public LoginUserQueryHandler(IMapper mapper, IUserRepository userRepository, IConfiguration configuration)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<IResult> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var errors = request.LoginUser.Validate();

        if (errors.Count > 0)
            return Results.BadRequest(errors);

        var userSecurity = await _userRepository.GetUserSecurityByEmailAsync(request.LoginUser.Email);
        if (userSecurity is null)
            return Results.Unauthorized();

        var isPasswordValid = PasswordHelper.VerifyPassword(request.LoginUser.Password, userSecurity.PasswordHash, userSecurity.PasswordSalt);
        if (!isPasswordValid)
            return Results.Unauthorized();
        
        var accessToken = PasswordHelper.GenerateAccessToken(userSecurity.UserId, request.LoginUser.Email, _configuration["Jwt:Key"]!, _configuration["Jwt:Issuer"]!);

        return Results.Ok(accessToken);
    }
}
    