using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace DMHTechnology.InfoMurid.MaklumatAsas
{
    [Table("LevelLabel")]
    public class LevelLabel : FullAuditedEntity<long>, IMustHaveTenant
    {
        public string Name { get; set; }
        public int TenantId { get; set; }

        [ForeignKey("LevelId")]
        public virtual Level Level { get; set; }
        public virtual int LevelId { get; set; }
    }
}
