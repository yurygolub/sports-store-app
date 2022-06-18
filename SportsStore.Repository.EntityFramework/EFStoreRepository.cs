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

        public void CreateProduct(Product p)
        {
            this.context.Products.Add(MapProduct(p));
            this.context.SaveChanges();
        }

        public void DeleteProduct(Product p)
        {
            var productEntity = MapProduct(p);
            var entity = this.context.Products.Find(productEntity.Id);
            this.context.Products.Remove(entity);
            this.context.SaveChanges();
        }

        public void SaveProduct(Product p)
        {
            this.context.SaveChanges();
        }

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

        private static ProductEntity MapProduct(Product product)
        {
            _ = product ?? throw new ArgumentNullException(nameof(product));

            return new ProductEntity
            {
                Name = product.Name,
                Category = product.Category,
                Description = product.Description,
                Price = product.Price,
                Id = product.ProductId,
            };
        }
    }
}
