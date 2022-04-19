using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Repository.EntityFramework.Entities
{
    public class CartLineEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public long? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        [NotMapped]
        public virtual ProductEntity Product { get; set; }

        public int Quantity { get; set; }

        public int? OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("Lines")]
        public virtual OrderEntity Order { get; set; }
    }
}
