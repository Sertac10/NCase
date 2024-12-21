using NCase.Application.Common.DTOs._0RequestResponse;
using NCase.Application.Common.DTOs.Management;
using NCase.Application.Common.DTOs.RickAndMorty;
using NCase.Application.Common.DTOs.User;
using NCase.Application.Features.Commands.Character.AddNewCharacter;
using NCase.Application.Features.Commands.User.CreateUser;
using NCase.Application.Features.Queries.Character.GetAllPagedCharacter;
using NCase.Application.Features.Queries.DbParameter.GetAllDbParameter;
using NCase.Application.Features.Queries.DbParameter.GetByIdorGuidDbParameter;
using NCase.Application.Features.Queries.DbParameter.GetDataListDbParameter;
using NCase.Application.Features.Queries.DbParameter.GetPagedDbParameter;
using NCase.Application.Features.Queries.DbParameterType.GetAllDbParameterType;
using NCase.Application.Features.Queries.DbParameterType.GetAllPagedDbParameterType;
using NCase.Application.Features.Queries.Episodes.GetAllEpisode;
using NCase.Application.Features.Queries.Episodes.GetDataListEpisodes;
using NCase.Application.Features.Queries.User.GetAllPagedUser;
using NCase.Application.Features.Queries.User.GetByIdOrGuidUser;
using NCase.Application.Utilities.Converters;
using NCase.Domain.Entities.Character;
using NCase.Domain.Entities.Identity;
using NCase.Domain.Entities.Management;

namespace NCase.Application.Common.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            #region GENERAL
            CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>)).ConvertUsing(typeof(PaginatedListConverter<,>));
            CreateMap<string, GetValueXQueryResponse>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src));
            CreateMap<DataList1, GetDataListXQueryResponse>();

            #endregion

            #region USER
            CreateMap<CreateUserCommandRequest, CreateUser_Dto>()
            .ForMember(dest => dest.Guid, opt => opt.Ignore())
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<CreateUser_Dto, AppUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<CreateUser_Dto, CreateUserCommandResponse>().ReverseMap();

            CreateMap<CreateUserCommandResponse, OptResult<CreateUserCommandResponse>>();

            CreateMap<AppUser, GetByIdOrGuidUserQueryResponse>();


            CreateMap<AppUser, GetAllPagedUserQueryResponse>();
            CreateMap<GetAllPagedUserQueryRequest, GetAllPagedUser_Index_Dto>();
            CreateMap<AppUser, GetAllPagedUserQueryRequest>();

            #endregion

            #region CHARACTER
            CreateMap<Character, GetAllPagedCharacterQueryResponse>();
            CreateMap<GetAllPagedCharacterQueryRequest, Character_Index_Dto>();
            CreateMap<Character, GetAllPagedCharacterQueryRequest>();
            CreateMap<Character, GetAllPagedCharacterQueryResponse>();
            CreateMap<Character_GridView_Dto, GetAllPagedCharacterQueryResponse>();

            CreateMap<AddNewCharacterCommandRequest, Character_AddNew_Dto>();
            CreateMap<Character, Character_AddNew_Dto>().ReverseMap();
            CreateMap<Character, AddNewCharacterCommandResponse>();
            CreateMap<CharacterDetail_AddNew_Dto, CharacterDetail>();
            #endregion

            #region EPISODE
            CreateMap<DataList1, GetDataListEpisodesQueryResponse>();
            CreateMap<Episode, GetAllEpisodeQueryResponse>();

            #endregion

            #region LOCATION

            #endregion

            #region DBPARAMETER
            CreateMap<DataList1, GetDataListDbParameterQueryResponse>();
            CreateMap<DbParameter, GetAllDbParameterQueryResponse>();
            CreateMap<DbParameter, GetByIdOrGuidDbParameterQueryResponse>();

            CreateMap<DbParameter, GetAllDbParameterQueryResponse>();

            CreateMap<GetPagedDbParameterQueryRequest, GetAllPaged_DBParameter_Index_Dto>();
            CreateMap<DbParameter, GetPagedDbParameterQueryResponse>();
            #endregion

            #region DBPARAMETERTYPE
            CreateMap<DbParameterType, GetAllDbParameterTypeQueryResponse>();
            CreateMap<GetAllPagedDbParameterTypeQueryRequest, GetAllPaged_DBParameterType_Index_Dto>();
            CreateMap<DbParameterType, GetAllPagedDbParameterTypeQueryResponse>();
            #endregion
        }
    }
}
