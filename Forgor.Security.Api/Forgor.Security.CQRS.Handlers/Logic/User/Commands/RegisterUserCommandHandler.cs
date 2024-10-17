using AutoMapper;
using Forgor.Security.CQRS.Contracts.User.Commands;
using Forgor.Security.CQRS.Handlers.ValidationExtensions.User;
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
        request.RegisterUser.Validate();
    }
}
