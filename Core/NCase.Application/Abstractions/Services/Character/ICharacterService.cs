﻿using NCase.Application.Common.DTOs.RickAndMorty;
using a=NCase.Domain.Entities.Character;

namespace NCase.Application.Abstractions.Services.Character
{
    public interface ICharacterService
    {
        Task<OptResult<a.Character>> AddNewAsync(Character_AddNew_Dto model);
        Task<OptResult<PaginatedList<Character_GridView_Dto>>> GetAllPagedCharacterAsync(Character_Index_Dto model);

       // Task<OptResult<PaginatedList<Character_GridView_Dto>>> GetAllPagedCharacterAsync2(Character_Index_Dto model); 

        Task SaveCharacterToDatabase(CharacterDto characterDto);
        Task SaveAllCharactersToDatabase();
    }
}
