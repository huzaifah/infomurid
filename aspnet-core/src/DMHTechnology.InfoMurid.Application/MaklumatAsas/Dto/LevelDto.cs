using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace DMHTechnology.InfoMurid.MaklumatAsas.Dto
{
    [AutoMapFrom(typeof(Level))]
    public class LevelDto : EntityDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
