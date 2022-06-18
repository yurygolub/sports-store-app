using System.Collections.Generic;

namespace SportsStore.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }

        int SaveOrder(Order order);
    }
}
