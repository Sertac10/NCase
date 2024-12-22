namespace NCase.Application.Features.Queries.Localization.GetLocalization;
public record GetLocalizationQueryRequest(string Key) : IRequest<GetLocalizationQueryResponse>;

