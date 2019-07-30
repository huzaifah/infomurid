using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace DMHTechnology.InfoMurid.MaklumatAsas.Dto
{
    [AutoMapFrom(typeof(TahunAkademik))]
    public class TahunAkademikDto : EntityDto
    {
        [Required]
        public int Year { get; set; }

        [Required]
        public int TenantId { get; set; }

        [Required]
        public bool IsLocked { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
