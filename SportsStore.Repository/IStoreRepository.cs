using System.Collections.Generic;

namespace SportsStore.Repository
{
    public interface IStoreRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
