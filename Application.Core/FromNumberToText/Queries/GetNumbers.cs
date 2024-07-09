using Application.Dto;
using Application.Dto.Base;
using Application.Dto.FromNumberToText;
using Application.Dto.FromNumberToText.Queries;
using AutoMapper;
using FromNumberToText.Domain.FromNumberToText;
using MediatR;
using System.Net;

namespace Application.Core.FromNumberToText.Queries;

public class GetNumbers : IRequestHandler<GetNumbersRequestDto, GenericResponseDto<ListNumbersResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IFromNumberToTextRepository _fromNumberToTextRepository;

    public GetNumbers(IMapper mapper, IFromNumberToTextRepository fromNumberToTextRepository)
    {
        _mapper = mapper;
        _fromNumberToTextRepository = fromNumberToTextRepository;
    }

    public async Task<GenericResponseDto<ListNumbersResponseDto>> Handle(GetNumbersRequestDto request, CancellationToken cancellationToken)
    {
        var listErrors = new List<string>();

        var result = new ListNumbersResponseDto();

        List<FromNumberToTextDto>? resultList = null;

        try
        {
            var actualPage = (request.Page - 1) * request.RecordPage;
            resultList = _mapper.Map<List<FromNumberToTextDto>>(await _fromNumberToTextRepository
                .SearchMatching(x => x.NumberId != 0, actualPage, request.RecordPage));
            var totalRecords = (await _fromNumberToTextRepository.SearchMatching(x => x.NumberId != 0).ConfigureAwait(false)).Count();

            result.ActualPage = request.Page;
            result.RecordsPage = request.RecordPage;
            result.TotalRecords = totalRecords;
            result.ListNumbersDto = resultList;
        }
        catch (Exception ex)
        {
            listErrors.Add("Error Numbers-GetAll");
            listErrors.Add(ex.Message);
        }
        if (resultList == null)
            listErrors.Add("Error GetNumbers-Null");

        return new GenericResponseDto<ListNumbersResponseDto>
        {
            Result = result,
            StatusCode = listErrors.Count == 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
            StatusDescription = listErrors.Count == 0 ? "Correcto" : "Error",
            Errors = listErrors.Count == 0 ? null : listErrors,
        };
    }
}
