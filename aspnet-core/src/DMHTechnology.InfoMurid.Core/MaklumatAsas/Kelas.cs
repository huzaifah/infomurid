using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace DMHTechnology.InfoMurid.MaklumatAsas
{ 
    [Table("Kelas")]
    public class Kelas : FullAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        public virtual string Code { get; set; }

        [Required]
        public virtual string Name { get; set; }
        public int TenantId { get; set; }

        [Required]
        public Tahap Tahap { get; set; }
    }
}
