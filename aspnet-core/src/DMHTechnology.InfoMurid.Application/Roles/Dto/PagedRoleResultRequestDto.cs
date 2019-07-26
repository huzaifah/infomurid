using Abp.Application.Services.Dto;

namespace DMHTechnology.InfoMurid.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

