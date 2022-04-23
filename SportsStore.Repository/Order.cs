using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Repository
{
    public class Order
    {
        public int Id { get; set; }

        public ICollection<CartLine> Lines { get; set; }

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

        public bool Shipped { get; set; }
    }
}
