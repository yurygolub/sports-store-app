﻿using System.Linq;

namespace SportsStore.Repository
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }

        void SaveOrder(Order order);
    }
}
