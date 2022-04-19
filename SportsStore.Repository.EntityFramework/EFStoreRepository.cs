using System;
using System.Collections.Generic;
using System.Linq;
using SportsStore.Repository.EntityFramework.Entities;

namespace SportsStore.Repository.EntityFramework
{
    public class EFStoreRepository : IStoreRepository
    {
        private readonly StoreDbContext context;

        public EFStoreRepository(StoreDbContext ctx)
        {
            this.context = ctx;
        }

        public IEnumerable<Product> Products => this.context.Products.Select(p => MapProduct(p));

        private static Product MapProduct(ProductEntity product)
        {
            _ = product ?? throw new ArgumentNullException(nameof(product));

            return new Product
            {
                Name = product.Name,
                Category = product.Category,
                Description = product.Description,
                Price = product.Price,
                ProductId = product.Id,
            };
        }
    }
}
