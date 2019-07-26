using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DMHTechnology.InfoMurid.MultiTenancy.Dto;

namespace DMHTechnology.InfoMurid.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

