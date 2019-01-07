using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillageApp.Infrastructure.SharedKernel;

namespace SkillageApp.Data.Entities
{
    [Table("Exchanges")]
    public class Exchange : DomainEntity<int>
    {
        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }
    }
}