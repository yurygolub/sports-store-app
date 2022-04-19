using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Repository.EntityFramework.Entities
{
    public class ProductEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("name")]
        public string Name { get; set; }

        [Column("description", TypeName = "ntext")]
        public string Description { get; set; }

        [Column("price", TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [StringLength(50)]
        [Column("category")]
        public string Category { get; set; }
    }
}
