﻿using NCase.Application.Common.DTOs.Common;
using NCase.Domain.Entities.Common;

namespace NCase.Application.Abstractions.Services.Common
{
    public interface IErrorService
    {
        Task<OptResult<Error>> AddErrorAsync(Create_Error_Dto model);
        Task<OptResult<PaginatedList<Error>>> GetAllPagedErrorAsync(GetAllPaged_Error_Dto model);
    }
}
