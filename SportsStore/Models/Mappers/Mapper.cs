using System;
using System.Linq;

namespace SportsStore.Models.Mappers
{
    internal static class Mapper
    {
        internal static Repository.Order MapOrder(Order order)
        {
            _ = order ?? throw new ArgumentNullException(nameof(order));

            return new Repository.Order
            {
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

        internal static Repository.CartLine MapCartLine(CartLine cartLine)
        {
            _ = cartLine ?? throw new ArgumentNullException(nameof(cartLine));

            return new Repository.CartLine
            {
                Product = MapProduct(cartLine.Product),
                Quantity = cartLine.Quantity,
            };
        }

        internal static Repository.Product MapProduct(Product product)
        {
            _ = product ?? throw new ArgumentNullException(nameof(product));

            return new Repository.Product
            {
                Name = product.Name,
                Category = product.Category,
                Description = product.Description,
                Price = product.Price,
                ProductId = product.ProductId,
            };
        }

        internal static Product MapProduct(Repository.Product product)
        {
            _ = product ?? throw new ArgumentNullException(nameof(product));

            return new Product
            {
                Name = product.Name,
                Category = product.Category,
                Description = product.Description,
                Price = product.Price,
                ProductId = product.ProductId,
            };
        }
    }
}
