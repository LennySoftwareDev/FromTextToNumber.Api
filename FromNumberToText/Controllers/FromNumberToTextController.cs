using Application.Dto.Base;
using Application.Dto.FromNumberToText;
using Application.Dto.FromNumberToText.Commands;
using Application.Dto.FromNumberToText.Queries;
using FromNumberToText.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FromNumberToText.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FromNumberToTextController : FromNumberToTextControllerBase
{
    private readonly IMediator _mediator;

    public FromNumberToTextController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpPost(nameof(CreateTextOfNumber))]

    public async Task<ActionResult<string>> CreateTextOfNumber(CreateTextOfTheNumberRequestDto request)
    {
        try
        {
            var result = await _mediator.Send(request).ConfigureAwait(false);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpGet(nameof(GetNumbers))]
    public async Task<ActionResult<GenericResponseDto<ListNumbersResponseDto>>> GetNumbers(int page = 0, int recordPage = 0)
    {
        try
        {
            var result = await _mediator.Send(new GetNumbersRequestDto()
            {
                Page = page,
                RecordPage = recordPage
            })
             .ConfigureAwait(false);

            return result.StatusCode == HttpStatusCode.OK ? Ok(result) : BadRequest(result);
        }
        catch (Exception ex)
        {
            var listError = new List<string>()
            {
                ex.Message
            };
            return BadRequest(new GenericResponseDto<ListNumbersResponseDto>
            {
                Errors = listError.Count > 0 ? listError : null,
                StatusCode = listError.Count > 0 ? HttpStatusCode.BadRequest : HttpStatusCode.OK,
                StatusDescription = listError.Count > 0 ? "Sin resultados" : "Correcto",
                Result = null
            });
        }
    }
}
