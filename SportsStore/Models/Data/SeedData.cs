using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Repository.EntityFramework;
using SportsStore.Repository.EntityFramework.Entities;

#pragma warning disable CA2000 // Dispose objects before losing scope

namespace SportsStore.Models.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            _ = app ?? throw new ArgumentNullException(nameof(app));

            StoreDbContext context = app
                .ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<StoreDbContext>();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new ProductEntity
                    {
                        Name = "Kayak",
                        Description = "A boat for one person",
                        Category = "Watersports",
                        Price = 275,
                    },
                    new ProductEntity
                    {
                        Name = "Lifejacket",
                        Description = "Protective and fashionable",
                        Category = "Watersports",
                        Price = 48.95m,
                    },
                    new ProductEntity
                    {
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and weight",
                        Category = "Soccer",
                        Price = 19.50m,
                    },
                    new ProductEntity
                    {
                        Name = "Corner Flags",
                        Description = "Give your playing field a professional touch",
                        Category = "Soccer",
                        Price = 34.95m,
                    },
                    new ProductEntity
                    {
                        Name = "Stadium",
                        Description = "Flat-packed 35,000-seat stadium",
                        Category = "Soccer",
                        Price = 79500,
                    },
                    new ProductEntity
                    {
                        Name = "Thinking Cap",
                        Description = "Improve brain efficiency by 75%",
                        Category = "Chess",
                        Price = 16,
                    },
                    new ProductEntity
                    {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent a disadvantage",
                        Category = "Chess",
                        Price = 29.95m,
                    },
                    new ProductEntity
                    {
                        Name = "Human Chess Board",
                        Description = "A fun game for the family",
                        Category = "Chess",
                        Price = 75,
                    },
                    new ProductEntity
                    {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded King",
                        Category = "Chess",
                        Price = 1200,
                    });

                context.SaveChanges();
            }
        }
    }
}
