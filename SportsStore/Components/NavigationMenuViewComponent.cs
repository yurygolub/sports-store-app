using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Repository;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IStoreRepository repository;

        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            this.repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            this.ViewBag.SelectedCategory = this.RouteData?.Values["category"];

            return this.View(this.repository.Products
               .Select(x => x.Category)
               .Distinct()
               .OrderBy(x => x));
        }

        private static Models.Product MapProduct(Product product)
        {
            _ = product ?? throw new ArgumentNullException(nameof(product));

            return new Models.Product
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
