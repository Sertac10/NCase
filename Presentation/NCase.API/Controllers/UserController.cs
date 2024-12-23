﻿using NCase.Application.Common.GenericObjects;
using NCase.Application.Features.Commands.User.CreateUser;
using NCase.Application.Features.Queries.User.GetAllPagedUser;
using NCase.Application.Features.Queries.User.GetByIdOrGuidUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NCase.API.Controllers
{
    [Route("api/User/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllPagedUser")]
        public async Task<IActionResult> GetAllPagedUser([FromQuery] GetAllPagedUserQueryRequest request)
        {
            OptResult<PaginatedList<GetAllPagedUserQueryResponse>> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            OptResult<CreateUserCommandResponse> response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetByIdOrGuidUser")]
        public async Task<IActionResult> GetByIdOrGuidUser([FromQuery] GetByIdOrGuidUserQueryRequest request)
        {
            OptResult<GetByIdOrGuidUserQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
