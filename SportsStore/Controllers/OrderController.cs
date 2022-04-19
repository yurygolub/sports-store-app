using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly Repository.IOrderRepository repository;
        private readonly Cart cart;

        public OrderController(Repository.IOrderRepository repoService, Cart cartService)
        {
            this.repository = repoService;
            this.cart = cartService;
        }

        [HttpGet]
        public ViewResult Checkout() => this.View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (!this.cart.Lines.Any())
            {
                this.ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (this.ModelState.IsValid)
            {
                order.Lines = this.cart.Lines.ToArray();
                this.repository.SaveOrder(MapOrder(order));
                this.cart.Clear();
                return this.View("Completed", order.OrderID);
            }

            return this.View();
        }

        private static Repository.Order MapOrder(Order order)
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
            };
        }

        private static Repository.CartLine MapCartLine(CartLine cartLine)
        {
            _ = cartLine ?? throw new ArgumentNullException(nameof(cartLine));

            return new Repository.CartLine
            {
                Product = MapProduct(cartLine.Product),
                Quantity = cartLine.Quantity,
            };
        }

        private static Repository.Product MapProduct(Product product)
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
    }
}
