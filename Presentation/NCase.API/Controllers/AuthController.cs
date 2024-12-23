﻿using NCase.Application.Common.GenericObjects;
using NCase.Application.Features.Commands.User.LoginUser;
using NCase.Application.Features.Commands.User.RefreshTokenLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NCase.API.Controllers
{
    [Route("api/Auth/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            OptResult<LoginUserCommandResponse> response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        {
            RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);
            return Ok(response);
        }
    }
}
