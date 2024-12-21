using Azure;
using NCase.Application.Abstractions.Security;
using NCase.Application.Common.DTOs.User;
using NCase.Application.Common.Extensions;
using NCase.Application.Constants;
using NCase.Application.Features.Queries.Character.GetAllPagedCharacter;
using HospitalManagement.Application.Abstractions.Services.Users;

namespace NCase.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, OptResult<CreateUserCommandResponse>>
    {
        private readonly IUserService _userService;
        private readonly ICryptographyService _cryptoHelperService;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserService userService, ICryptographyService cryptoHelperService, IMapper mapper)
        {
            _userService = userService;
            _cryptoHelperService = cryptoHelperService;
            _mapper = mapper;
        }

        public async Task<OptResult<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await ExceptionHandler.HandleOptResultAsync(async () =>
            {
                var createUserDto = _mapper.Map<CreateUser_Dto>(request);
                createUserDto.IdentityNo = await _cryptoHelperService.EncryptString(request.IdentityNo);
                var createdUser = await _userService.CreateAsync(createUserDto);

                if (!createdUser.Succeeded)
                    return await OptResult<CreateUserCommandResponse>.FailureAsync(createdUser.Messages);

                var response = _mapper.Map<OptResult<CreateUserCommandResponse>>(createdUser.Data);

                return OptResult<CreateUserCommandResponse>.Success(response.Data, Messages.SuccessfullyAdded);

            });
        }
    }
}
