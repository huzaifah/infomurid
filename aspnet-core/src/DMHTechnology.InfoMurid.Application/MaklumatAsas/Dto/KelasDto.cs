using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace DMHTechnology.InfoMurid.MaklumatAsas.Dto
{
    [AutoMapFrom(typeof(Kelas))]
    public class KelasDto : EntityDto<long>
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int TenantId { get; set; }

        public DateTime CreationTime { get; set; }

        public int Tahap { get; set; }

        public string TahapText
        {
            get
            {
                return Enum.Parse<Tahap>(Tahap.ToString()).ToString();
            }
        }
    }
}
