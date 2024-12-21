using NCase.Application.Common.DTOs.RickAndMorty;
using NCase.Domain.Entities.Character;

namespace NCase.Application.Abstractions.Services.Common
{
    public interface IRickAndMortyApiService
    {
        Task<CharacterListDto> GetCharactersAsync(int pageNumber);
        Task<LocationListDto> GetLocationsAsync(int pageNumber);
        Task<EpisodeListDto> GetEpisodesAsync(int pageNumber);

    }
}
