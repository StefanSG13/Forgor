using AutoMapper;
using Forgor.Security.CQRS.Contracts.User.Dtos;
using Forgor.Security.Domain.Entities.User;
using System.Diagnostics.CodeAnalysis;

namespace Forgor.Security.CQRS.Handlers.Profiles;

[ExcludeFromCodeCoverage]
internal sealed class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<RegisterUserDto, UserEntity>();
        CreateMap<RegisterUserDto, UserSecurityEntity>();
    }
}
