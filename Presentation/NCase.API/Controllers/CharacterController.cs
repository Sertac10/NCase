using NCase.Application.Abstractions.Services.Character;
using NCase.Application.Abstractions.Services.Common;
using NCase.Application.Common.GenericObjects;
using NCase.Application.Features.Commands.Character.AddNewCharacter;
using NCase.Application.Features.Queries.Character.GetAllPagedCharacter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NCase.API.Controllers
{
    [Route("api/Character/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly IRickAndMortyApiService _rickAndMortyApiService;
        private readonly ICharacterService _characterService;
        private readonly IMediator _mediator;
        public CharacterController(IRickAndMortyApiService rickAndMortyApiService, ICharacterService characterService, IMediator mediator)
        {
            _rickAndMortyApiService = rickAndMortyApiService;
            _characterService = characterService;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("AddNewCharacter")]
        public async Task<IActionResult> AddNewCharacter(AddNewCharacterCommandRequest request)
        {
            OptResult<AddNewCharacterCommandResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllPagedCharacter")]
        public async Task<IActionResult> GetAllPagedCharacter([FromQuery] GetAllPagedCharacterQueryRequest request)
        {
            OptResult<PaginatedList<GetAllPagedCharacterQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("characters")]
        public async Task<IActionResult> GetCharacters()
        {
            try
            {
                var characters = _characterService.SaveAllCharactersToDatabase();
                return Ok(characters);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        
    }
}
