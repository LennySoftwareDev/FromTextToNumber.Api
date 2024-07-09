using Application.Dto.Base;
using MediatR;

namespace Application.Dto.FromNumberToText.Commands;

public class CreateTextOfTheNumberRequestDto : IRequest<GenericResponseDto<string>>
{
    public int NumberId { get; set; }

    public long Number { get; set; }
}
