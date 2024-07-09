using Application.Dto;
using Application.Dto.FromNumberToText.Commands;
using AutoMapper;
using FromNumberToText.Domain.FromNumberToText;
using FromNumberToText.Domain.User;

namespace Application.Core;

public class FromNumberToTextProfile : Profile
{
    public FromNumberToTextProfile()
    {
        CreateMap<FromNumberToTextEntity, CreateTextOfTheNumberRequestDto>().ReverseMap();
        CreateMap<FromNumberToTextEntity, FromNumberToTextDto>().ReverseMap();
        CreateMap<UserEntity, UserDto>().ReverseMap();
    }
}
