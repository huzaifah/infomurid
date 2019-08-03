using System;
using Abp.Application.Services.Dto;

namespace DMHTechnology.InfoMurid.MaklumatAsas.Dto
{
    public class PagedLevelLabelResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public int LevelId { get; set; }
    }
}
