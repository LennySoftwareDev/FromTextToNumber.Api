using Application.Dto.Base;

namespace Application.Dto.FromNumberToText;

public class ListNumbersResponseDto : BasePaginationResponseDto
{
    public List<FromNumberToTextDto>? ListNumbersDto { get; set; }
}
