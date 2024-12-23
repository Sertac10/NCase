﻿using NCase.Application.Common.GenericObjects;
using NCase.Application.Features.Queries.Character.GetAllPagedCharacter;
using NCase.Client.HelperServices;
using NCase.Client.Models;
using NCase.Client.Models.Character;
using NCase.Client.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NCase.Client.Controllers;

public class HomeController : Controller
{
    private readonly IHttpClientService _httpClientService;

    public HomeController(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Index(Character_Index_ViewModel model)
    {
        var queryString = QueryStringHelperService.ToQueryString(model);

        var response = await _httpClientService.GetAsync<PaginatedList<GetAllPagedCharacterQueryResponse>>(
                new RequestParameters
                {
                    Action = "GetAllPagedCharacter",
                    Controller = "Character",
                    Folder = "Character",
                    QueryString = queryString
                }
            );

        List<Character_GridView_ViewModel> myData = new();

        foreach (var data in response.Data.Data)
        {
            myData.Add(new Character_GridView_ViewModel()
            {
                CharacterName = data.CharacterName,
                EpisodeName = data.EpisodeName,
                FirstSeenName = data.FirstSeenName,
                Gender = data.Gender,
                Image = data.Image,
                LastKnownLocationName = data.LastKnownLocationName,
                SpeciesName = data.SpeciesName,
                StatusName = data.StatusName
            });
        }

        Character_Index_ViewModel MYRESULT = new Character_Index_ViewModel()
        {
            PageTitle = "Yönetim",
            SubPageTitle = "Departmanlar",
            MyGridData = myData,
            MyPagination = response.Data.Pagination,
            SearchText = model.SearchText,
            LocationId = model.LocationId,
            SpeciesId = model.SpeciesId,
            StatusId = model.StatusId,
            Take = model.Take,
            PageIndex = model.PageIndex,
            OrderBy = model.OrderBy
        };

        return View(MYRESULT);

    }
}