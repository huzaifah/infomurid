using System;
using Abp.Application.Services.Dto;

namespace DMHTechnology.InfoMurid.MaklumatAsas.Dto
{
    public class PagedTahunAkademikResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsLocked { get; set; }
    }
}
