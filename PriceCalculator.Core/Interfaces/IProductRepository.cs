using System.Collections.Generic;
using PriceCalculator.Core.Models;

namespace PriceCalculator.Core.Interfaces
{
    public interface IProductRepository
    {
        Product GetProductBySku(string sku);
        IEnumerable<Product> GetProducts();
    }
}