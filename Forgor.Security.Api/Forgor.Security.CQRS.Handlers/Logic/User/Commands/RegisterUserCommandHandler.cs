using AutoMapper;
using Forgor.Security.CQRS.Contracts.User.Commands;
using Forgor.Security.CQRS.Handlers.Logic.User.Helpers;
using Forgor.Security.CQRS.Handlers.ValidationExtensions.User;
using Forgor.Security.Domain.Entities.User;
using Forgor.Security.Domain.Enums;
using Forgor.Security.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Forgor.Security.CQRS.Handlers.Logic.User.Commands;

internal sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IResult>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<IResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var errors = request.RegisterUser.Validate();

        if (errors.Count > 0)
            return Results.BadRequest(errors);

        var user = _mapper.Map<UserEntity>(request.RegisterUser);
        var userSecurity = _mapper.Map<UserSecurityEntity>(request.RegisterUser);

        userSecurity.UserStatusId = UserStatus.PendingActivation;
        userSecurity.RetryCount = 0;
        userSecurity.UseTwoFactor = false;

        (userSecurity.PasswordHash, userSecurity.PasswordSalt) = PasswordHelper.GeneratePasswordHashAndSalt(request.RegisterUser.Password);

        Console.WriteLine(userSecurity.PasswordHash);
        Console.WriteLine(userSecurity.PasswordSalt);

        userSecurity.UserId = await _userRepository.AddUserAsync(user);
        await _userRepository.AddUserSecurityAsync(userSecurity);

        return Results.Ok();
    }
}
