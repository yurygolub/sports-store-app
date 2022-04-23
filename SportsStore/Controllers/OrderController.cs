using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.Mappers;

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
                this.repository.SaveOrder(Mapper.MapOrder(order));
                this.cart.Clear();
                return this.View("Completed", order.OrderID);
            }

            return this.View();
        }
    }
}
