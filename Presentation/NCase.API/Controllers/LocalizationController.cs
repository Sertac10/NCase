using MediatR;
using Microsoft.AspNetCore.Mvc;
using NCase.Application.Features.Queries.Localization.GetLocalization;

namespace NCase.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LocalizationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocalizationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{key}")]
    public async Task<IActionResult> GetLocalizedText(string key)
    {
        var localizedText = await _mediator.Send(new GetLocalizationQueryRequest(key));
        return Ok(new { key, localizedText });
    }
}
