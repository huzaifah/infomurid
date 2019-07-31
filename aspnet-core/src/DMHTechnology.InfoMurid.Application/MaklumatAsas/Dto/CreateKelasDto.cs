using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace DMHTechnology.InfoMurid.MaklumatAsas.Dto
{
    [AutoMapFrom(typeof(Kelas))]
    public class CreateKelasDto : EntityDto<long>
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int TenantId { get; set; }

        [Required]
        public int Tahap { get; set; }
    }
}
