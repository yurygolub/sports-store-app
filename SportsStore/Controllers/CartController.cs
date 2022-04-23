using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.Mappers;
using SportsStore.ViewModels;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private readonly Repository.IStoreRepository repository;
        private readonly Cart cart;

        public CartController(Repository.IStoreRepository repo, Cart cartService)
        {
            this.repository = repo;
            this.cart = cartService;
        }

        [HttpGet]
        public IActionResult Index(string returnUrl)
        {
            return this.View(new CartViewModel
            {
                ReturnUrl = returnUrl ?? "/",
            });
        }

        [HttpPost]
        public IActionResult Index(long productId, string returnUrl)
        {
            var product = this.repository.Products.FirstOrDefault(p => p.ProductId == productId);
            this.cart.AddItem(Mapper.MapProduct(product), 1);
            return this.View(new CartViewModel
            {
                Cart = this.cart,
                ReturnUrl = returnUrl,
            });
        }

        [HttpPost]
        public IActionResult Remove(long productId, string returnUrl)
        {
            this.cart.RemoveLine(this.cart.Lines.First(cl => cl.Product.ProductId == productId).Product);

            return this.View("Index", new CartViewModel
            {
                Cart = this.cart,
                ReturnUrl = returnUrl ?? "/",
            });
        }
    }
}
