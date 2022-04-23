using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportsStore.Models.Mappers;
using SportsStore.Repository;
using SportsStore.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        public const int PageSize = 4;
        private readonly ILogger<HomeController> logger;
        private readonly IStoreRepository repository;

        public HomeController(ILogger<HomeController> logger, IStoreRepository repository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public ViewResult Index(string category, int productPage = 1)
        {
            return this.View(new ProductsListViewModel
            {
                Products = this.repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductId)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize)
                    .Select(p => Mapper.MapProduct(p)),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        this.repository.Products.Count() :
                        this.repository.Products.Where(e => e.Category == category).Count(),
                },

                CurrentCategory = category,
            });
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
