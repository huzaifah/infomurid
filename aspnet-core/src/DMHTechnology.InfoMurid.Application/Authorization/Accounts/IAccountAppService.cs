using System.Threading.Tasks;
using Abp.Application.Services;
using DMHTechnology.InfoMurid.Authorization.Accounts.Dto;

namespace DMHTechnology.InfoMurid.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
