using Application.Dto.LoginUser;
using FromNumberToText.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FromNumberToText.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : FromNumberToTextControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(nameof(AuthorizationLogin))]
    public async Task<ActionResult<AuthorizationLoginResponseDto>> AuthorizationLogin([FromBody] AuthorizationLoginRequestDto request)
    {
        try
        {
            var result = await _mediator.Send(request).ConfigureAwait(false);

            if (result == null)
                return Unauthorized();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
