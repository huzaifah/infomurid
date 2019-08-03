using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace DMHTechnology.InfoMurid.MaklumatAsas.Dto
{
    [AutoMapFrom(typeof(LevelLabel))]
    public class CreateLevelLabelDto : EntityDto<long>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int TenantId { get; set; }

        [Required]
        public int LevelId { get; set; }
    }
}
