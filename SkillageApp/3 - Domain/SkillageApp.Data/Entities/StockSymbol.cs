using SkillageApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillageApp.Data.Entities
{
    [Table("StockSymbols")]
    public class StockSymbol : DomainEntity<int>
    {
        [Required]
        [StringLength(255)]
        public string Code { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }
    }
}