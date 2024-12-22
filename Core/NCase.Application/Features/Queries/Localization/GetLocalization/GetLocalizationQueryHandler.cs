using NCase.Application.Abstractions.Services.Localization;

namespace NCase.Application.Features.Queries.Localization.GetLocalization;
public class GetLocalizationQueryHandle : IRequestHandler<GetLocalizationQueryRequest, GetLocalizationQueryResponse>
{
    private readonly ILocalizationService _localizationService;

    public GetLocalizationQueryHandle(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
    }

    public Task<GetLocalizationQueryResponse> Handle(GetLocalizationQueryRequest request, CancellationToken cancellationToken)
    {
        var localizedText = _localizationService.GetString(request.Key);
        var response = new GetLocalizationQueryResponse(request.Key, localizedText);
        return Task.FromResult(response);
    }
}