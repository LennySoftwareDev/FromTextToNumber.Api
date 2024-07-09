using Application.Dto.Base;
using Application.Dto.FromNumberToText.Commands;
using AutoMapper;
using FromNumberToText.Domain.FromNumberToText;
using Humanizer;
using MediatR;
using System.Net;

namespace Application.Core.FromNumberToText.Commands;

public class CreateTextOfTheNumber : IRequestHandler<CreateTextOfTheNumberRequestDto, GenericResponseDto<string>>
{
    private readonly IMapper _mapper;
    private readonly IFromNumberToTextRepository _fromNumberToTextRepository;

    public CreateTextOfTheNumber(IMapper mapper, IFromNumberToTextRepository fromNumberToTextRepository)
    {
        _mapper = mapper;
        _fromNumberToTextRepository = fromNumberToTextRepository;
    }

    public async Task<GenericResponseDto<string>> Handle(CreateTextOfTheNumberRequestDto request, CancellationToken cancellationToken)
    {
        var listErrors = new List<string>();

        var result = string.Empty;
        try
        {
            if (request.Number >= 0 && request.Number <= 999999999999)
            {
                result = request.Number.ToWords();
                _mapper.Map<CreateTextOfTheNumberRequestDto>(await _fromNumberToTextRepository.Create(_mapper.Map<FromNumberToTextEntity>(request)));
            }
            else
            {
                result = $"El número {request.Number} no es permitido";
            }
        }
        catch (Exception ex)
        {
            listErrors.Add("Error CreateTextOfTheNumber");
            listErrors.Add(ex.Message);
        }

        return new GenericResponseDto<string>
        {
            Result = result,
            StatusCode = listErrors.Count == 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
            StatusDescription = listErrors.Count == 0 ? "Correcto" : "Error",
            Errors = listErrors.Count == 0 ? null : listErrors,
        };
    }
}
