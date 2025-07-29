using AbpDemo.Categories;
using AbpDemo.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace AbpDemo
{
    public class ProductStoreDataSeederContributor
 : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Product, long> _productRepository;
        private readonly IRepository<Category, long> _categoryRepository;

        public ProductStoreDataSeederContributor(IRepository<Product, long> productRepository, IRepository<Category, long> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            List<Category> categories = await _categoryRepository.GetListAsync();

            if (categories.Count <= 0)
            {
                categories = new List<Category>
                {
                    new() { Name = "Beverages"      },
                    new() { Name = "Snacks"         },
                    new() { Name = "Dairy"          },
                    new() { Name = "Personal Care"  },
                    new() { Name = "Cleaning"       },
                };

                await _categoryRepository.InsertManyAsync(categories, autoSave: true);
            }

            if (await _productRepository.GetCountAsync() <= 0)
            {
                var products = new List<Product>
                {
                    // ── Beverages ───────────────────────────────────────
                    new() {
                        SKU = "BEV‑COL‑330",
                        Name = "Cola 330 ml",
                        Description = "Carbonated drink",
                        Price = 1.50m,
                        Stock = 120,
                        Rating = 4.6,
                        CategoryId = categories.Single(c => c.Name == "Beverages").Id
                    },
                    new() {
                        SKU = "BEV‑WAT‑500",
                        Name = "Spring Water 500 ml",
                        Description = "Still water",
                        Price = 0.90m,
                        Stock = 200,
                        Rating = 4.2,
                        CategoryId = categories.Single(c => c.Name == "Beverages").Id
                    },

                    // ── Snacks ──────────────────────────────────────────
                    new() {
                        SKU = "SNK‑CHP‑160",
                        Name = "Potato Chips 160 g",
                        Description = "Salted snack",
                        Price = 2.20m,
                        Stock = 150,
                        Rating = 4.0,
                        CategoryId = categories.Single(c => c.Name == "Snacks").Id
                    },
                    new() {
                        SKU = "SNK‑BAR‑100",
                        Name = "Chocolate Bar 100 g",
                        Description = "Milk chocolate",
                        Price = 1.10m,
                        Stock = 300,
                        Rating = 4.5,
                        CategoryId = categories.Single(c => c.Name == "Snacks").Id
                    },

                    // ── Dairy ───────────────────────────────────────────
                    new() {
                        SKU = "DAR‑MIL‑1L",
                        Name = "Whole Milk 1 L",
                        Description = "Fresh milk",
                        Price = 1.25m,
                        Stock = 180,
                        Rating = 4.7,
                        CategoryId = categories.Single(c => c.Name == "Dairy").Id
                    },
                    new() {
                        SKU = "DAR‑YOG‑125",
                        Name = "Strawberry Yogurt 125 g",
                        Description = "Flavoured yogurt",
                        Price = 0.80m,
                        Stock = 250,
                        Rating = 4.3,
                        CategoryId = categories.Single(c => c.Name == "Dairy").Id
                    },

                    // ── Personal Care ───────────────────────────────────
                    new() {
                        SKU = "PER‑SOAP‑90",
                        Name = "Bath Soap 90 g",
                        Description = "Neutral soap",
                        Price = 0.60m,
                        Stock = 400,
                        Rating = 4.1,
                        CategoryId = categories.Single(c => c.Name == "Personal Care").Id
                    },
                    new() {
                        SKU = "PER‑SHA‑400",
                        Name = "Shampoo 400 ml",
                        Description = "Nourishing shampoo",
                        Price = 3.80m,
                        Stock = 140,
                        Rating = 4.4,
                        CategoryId = categories.Single(c => c.Name == "Personal Care").Id
                    },

                    // ── Cleaning ────────────────────────────────────────
                    new() {
                        SKU = "CLN‑DET‑1L",
                        Name = "Dish Detergent 1 L",
                        Description = "Dish‑washing liquid",
                        Price = 2.10m,
                        Stock = 110,
                        Rating = 4.2,
                        CategoryId = categories.Single(c => c.Name == "Cleaning").Id
                    },
                    new() {
                        SKU = "CLN‑BLH‑2L",
                        Name = "Bleach 2 L",
                        Description = "Disinfectant",
                        Price = 1.70m,
                        Stock = 130,
                        Rating = 4.5,
                        CategoryId = categories.Single(c => c.Name == "Cleaning").Id
                    }
                };

                await _productRepository.InsertManyAsync(products, autoSave: true);
            }
        }
    }
}
