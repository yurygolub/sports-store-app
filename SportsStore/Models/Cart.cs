using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine viewModel = this.Lines.FirstOrDefault(p => p.Product.ProductId == product.ProductId);

            if (viewModel == null)
            {
                this.Lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity,
                });
            }
            else
            {
                viewModel.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product) =>
            this.Lines.RemoveAll(l => l.Product.ProductId == product.ProductId);

        public decimal ComputeTotalValue() =>
            this.Lines.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() => this.Lines.Clear();
    }
}
