using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DMHTechnology.InfoMurid.MultiTenancy;

namespace DMHTechnology.InfoMurid.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
