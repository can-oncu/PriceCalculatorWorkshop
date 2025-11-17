using System.Collections.Generic;
using System.Linq;
using PriceCalculator.Core.Interfaces;
using PriceCalculator.Core.Models;

namespace PriceCalculator.Core.Services
{
    public class PriceCalculatorService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserDiscountService _userDiscountService;

        public PriceCalculatorService(IProductRepository productRepository, IUserDiscountService userDiscountService)
        {
            _productRepository = productRepository;
            _userDiscountService = userDiscountService;
        }

        // Calculate the total price for a single cart item
        public decimal CalculateItemTotal(CartItem cartItem, string userId = null)
        {
            if (cartItem?.Product == null)
                return 0;

            // Use the unit price from the cart item, or fall back to product price
            var unitPrice = cartItem.UnitPrice > 0 ? cartItem.UnitPrice : cartItem.Product.Price;
            var baseTotal = unitPrice * cartItem.Quantity;

            // Apply user discount if userId is provided
            if (!string.IsNullOrWhiteSpace(userId))
            {
                return ApplyUserDiscount(baseTotal, userId, cartItem.Product);
            }

            return baseTotal;
        }

        // Calculate the total price for multiple cart items
        public decimal CalculateCartTotal(IEnumerable<CartItem> cartItems, string userId = null)
        {
            if (cartItems == null)
                return 0;

            return cartItems.Sum(item => CalculateItemTotal(item, userId));
        }

        // Get product by SKU with validation
        public Product GetProduct(string sku)
        {
            // Validate SKU format first
            if (!ValidationHelper.IsValidSku(sku))
                return null;

            // Retrieve product from repository
            var product = _productRepository.GetProductBySku(sku);

            // Only return active products
            if (product != null && !product.IsActive)
                return null;

            return product;
        }

        // Apply discount to a price based on user eligibility
        public decimal ApplyUserDiscount(decimal originalPrice, string userId, Product product)
        {
            if (string.IsNullOrWhiteSpace(userId) || product == null || originalPrice <= 0)
                return originalPrice;

            // Check if user is eligible for discount on this product
            if (!_userDiscountService.IsEligibleForDiscount(userId, product))
                return originalPrice;

            // Get the user's discount rate
            var discountRate = _userDiscountService.GetUserDiscount(userId);

            // Ensure discount rate is valid (between 0 and 1)
            if (discountRate < 0 || discountRate > 1)
                return originalPrice;

            // Apply the discount
            var discountAmount = originalPrice * discountRate;
            return originalPrice - discountAmount;
        }
    }
}