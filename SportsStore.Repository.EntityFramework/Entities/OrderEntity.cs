using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Repository.EntityFramework.Entities
{
    public class OrderEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [InverseProperty(nameof(CartLineEntity.Order))]
        public virtual ICollection<CartLineEntity> Lines { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Line3 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        public string Zip { get; set; }

        [Required]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
