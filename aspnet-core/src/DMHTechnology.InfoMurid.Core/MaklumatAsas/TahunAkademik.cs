using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace DMHTechnology.InfoMurid.MaklumatAsas
{
    [Table("TahunAkademik")]
    public class TahunAkademik : FullAuditedEntity, IMustHaveTenant
    {
        [Required]
        public virtual int Year { get; set; }
        public int TenantId { get; set; }
        public bool IsLocked { get; set; }
    }
}
