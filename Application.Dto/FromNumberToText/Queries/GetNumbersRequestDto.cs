using Application.Dto.Base;
using MediatR;

namespace Application.Dto.FromNumberToText.Queries;

public class GetNumbersRequestDto : IRequest<GenericResponseDto<ListNumbersResponseDto>>
{
    public int Page { get; set; }
    public int RecordPage { get; set; }
}
