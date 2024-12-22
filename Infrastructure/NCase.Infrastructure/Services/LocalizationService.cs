using Microsoft.Extensions.Localization;
using NCase.Application.Abstractions.Services.Localization;
using NCase.Application.Resources;

namespace NCase.Infrastructure.Services;
public class LocalizationService : ILocalizationService
{
    private readonly IStringLocalizer<Resource1> _stringLocalizer;

    public LocalizationService(IStringLocalizer<Resource1> factory)
    {

        _stringLocalizer = factory;
    }

    public string GetString(string key)
    {
        var res1 = _stringLocalizer[key];
        return res1;
    }
}
