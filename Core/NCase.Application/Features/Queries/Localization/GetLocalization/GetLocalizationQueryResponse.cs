namespace NCase.Application.Features.Queries.Localization.GetLocalization;
public class GetLocalizationQueryResponse
{
    public string Key { get; set; }
    public string LocalizedText { get; set; }

    public GetLocalizationQueryResponse(string key, string localizedText)
    {
        Key = key;
        LocalizedText = localizedText;
    }
}
