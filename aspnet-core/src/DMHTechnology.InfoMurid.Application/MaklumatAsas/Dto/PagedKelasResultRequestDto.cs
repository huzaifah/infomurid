using System;
using Abp.Application.Services.Dto;

namespace DMHTechnology.InfoMurid.MaklumatAsas.Dto
{
    public class PagedKelasResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
