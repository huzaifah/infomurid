using System.Threading.Tasks;
using Abp.Application.Services;
using DMHTechnology.InfoMurid.Sessions.Dto;

namespace DMHTechnology.InfoMurid.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
