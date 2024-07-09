using Application.Dto.Base;
using MediatR;

namespace Application.Dto.LoginUser;

public class AuthorizationLoginRequestDto : IRequest<GenericResponseDto<AuthorizationLoginResponseDto>>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
