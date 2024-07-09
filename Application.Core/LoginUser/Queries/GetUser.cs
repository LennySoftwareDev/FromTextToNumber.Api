using Application.Core.LoginUser.Utils;
using Application.Dto;
using Application.Dto.Base;
using Application.Dto.LoginUser;
using AutoMapper;
using FromNumberToText.Domain.User;
using MediatR;
using System.Net;

namespace Application.Core.LoginUser.Queries;

public class GetUser : IRequestHandler<AuthorizationLoginRequestDto, GenericResponseDto<AuthorizationLoginResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly CreateToken _createToken;

    public GetUser(IMapper mapper, IUserRepository userRepository, CreateToken createToken)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _createToken = createToken;
    }
    public async Task<GenericResponseDto<AuthorizationLoginResponseDto>> Handle(AuthorizationLoginRequestDto request, CancellationToken cancellationToken)
    {
        var listErrors = new List<string>();

        string tokenCreated = string.Empty;

        var response = new AuthorizationLoginResponseDto();

        var result = _mapper.Map<UserDto>(await _userRepository.FirstBySearchMatching(x => x.UserName == request.UserName && x.Password == request.Password));
        if (result == null)
        {
            listErrors.Add("Error User-NotExist");
        }
        else
        {
            response.Token = _createToken.GenerateToken(result.UserId.ToString());
            response.Result = true;
        }

        return new()
        {
            Result = response,
            StatusCode = listErrors.Count == 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
            StatusDescription = listErrors.Count == 0 ? "Correcto" : "Error",
            Errors = listErrors.Count == 0 ? null : listErrors,
        };
    }
}
