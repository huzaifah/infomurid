using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DMHTechnology.InfoMurid.Roles.Dto;
using DMHTechnology.InfoMurid.Users.Dto;

namespace DMHTechnology.InfoMurid.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
