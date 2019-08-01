using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace DMHTechnology.InfoMurid.MaklumatAsas
{
    [Table("Level")]
    public class Level : Entity
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
