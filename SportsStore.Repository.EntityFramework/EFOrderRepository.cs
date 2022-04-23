using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SportsStore.Repository.EntityFramework.Entities;

namespace SportsStore.Repository.EntityFramework
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly StoreDbContext context;

        public EFOrderRepository(StoreDbContext ctx)
        {
            this.context = ctx;
        }

        public IQueryable<Order> Orders => this.context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product)
            .Select(o => MapOrder(o));

        public void SaveOrder(Order order)
        {
            var orderEntity = MapOrder(order);

            this.context.CartLines.AddRange(orderEntity.Lines);
            this.context.Orders.Add(orderEntity);

            this.context.SaveChanges();
        }

        private static Order MapOrder(OrderEntity orderEntity)
        {
            _ = orderEntity ?? throw new ArgumentNullException(nameof(orderEntity));

            return new Order
            {
                Id = orderEntity.Id,
                City = orderEntity.City,
                Country = orderEntity.Country,
                GiftWrap = orderEntity.GiftWrap,
                Line1 = orderEntity.Line1,
                Line2 = orderEntity.Line2,
                Line3 = orderEntity.Line3,
                Lines = orderEntity.Lines.Select(l => MapCartLine(l)).ToArray(),
                Name = orderEntity.Name,
                State = orderEntity.State,
                Zip = orderEntity.Zip,
                Shipped = orderEntity.Shipped,
            };
        }

        private static OrderEntity MapOrder(Order order)
        {
            _ = order ?? throw new ArgumentNullException(nameof(order));

            return new OrderEntity
            {
                Id = order.Id,
                City = order.City,
                Country = order.Country,
                GiftWrap = order.GiftWrap,
                Line1 = order.Line1,
                Line2 = order.Line2,
                Line3 = order.Line3,
                Lines = order.Lines.Select(l => MapCartLine(l)).ToArray(),
                Name = order.Name,
                State = order.State,
                Zip = order.Zip,
                Shipped = order.Shipped,
            };
        }

        private static CartLineEntity MapCartLine(CartLine cartLine)
        {
            _ = cartLine ?? throw new ArgumentNullException(nameof(cartLine));

            return new CartLineEntity
            {
                Product = MapProduct(cartLine.Product),
                Quantity = cartLine.Quantity,
            };
        }

        private static CartLine MapCartLine(CartLineEntity cartLineEntity)
        {
            _ = cartLineEntity ?? throw new ArgumentNullException(nameof(cartLineEntity));

            return new CartLine
            {
                Product = MapProduct(cartLineEntity.Product),
                Quantity = cartLineEntity.Quantity,
            };
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
