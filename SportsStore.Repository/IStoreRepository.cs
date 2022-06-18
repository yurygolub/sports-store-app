using System.Collections.Generic;

namespace SportsStore.Repository
{
    public interface IStoreRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product p);

        void CreateProduct(Product p);

        void DeleteProduct(Product p);
    }
}
