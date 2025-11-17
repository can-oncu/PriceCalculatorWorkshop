using System;
using System.Collections.Generic;
using System.Linq;
using PriceCalculator.Core.Interfaces;
using PriceCalculator.Core.Models;

namespace PriceCalculator.Core.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // In-memory storage for demo purposes
        // In a real application, this would connect to a database
        private readonly List<Product> _products;

        public ProductRepository()
        {
            // Initialize with sample data
            _products = new List<Product>
            {
                new Product 
                { 
                    Sku = "ABC12345", 
                    Name = "Wireless Headphones", 
                    Price = 99.99m, 
                    Category = "Electronics", 
                    IsActive = true,
                    CreatedDate = DateTime.Now.AddDays(-30)
                },
                new Product 
                { 
                    Sku = "DEF67890", 
                    Name = "Programming Book", 
                    Price = 45.00m, 
                    Category = "Books", 
                    IsActive = true,
                    CreatedDate = DateTime.Now.AddDays(-15)
                },
                new Product 
                { 
                    Sku = "GHI11111", 
                    Name = "Cotton T-Shirt", 
                    Price = 19.99m, 
                    Category = "Clothing", 
                    IsActive = false, // Inactive product
                    CreatedDate = DateTime.Now.AddDays(-60)
                },
                new Product 
                { 
                    Sku = "JKL22222", 
                    Name = "Coffee Mug", 
                    Price = 12.50m, 
                    Category = "Home & Garden", 
                    IsActive = true,
                    CreatedDate = DateTime.Now.AddDays(-7)
                },
                new Product 
                { 
                    Sku = "MNO33333", 
                    Name = "Smartphone Case", 
                    Price = 24.99m, 
                    Category = "Electronics", 
                    IsActive = true,
                    CreatedDate = DateTime.Now.AddDays(-3)
                }
            };
        }

        /// <summary>
        /// Retrieves a product by its SKU (Stock Keeping Unit)
        /// </summary>
        /// <param name="sku">The SKU to search for</param>
        /// <returns>The product with the matching SKU, or null if not found</returns>
        public Product GetProductBySku(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku))
                return null;

            return _products.FirstOrDefault(p => 
                string.Equals(p.Sku, sku, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Retrieves all active products
        /// </summary>
        /// <returns>A collection of all active products</returns>
        public IEnumerable<Product> GetProducts()
        {
            return _products.Where(p => p.IsActive).ToList();
        }
    }
}