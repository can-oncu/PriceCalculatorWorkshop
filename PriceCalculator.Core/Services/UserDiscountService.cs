using System;
using System.Collections.Generic;
using System.Linq;
using PriceCalculator.Core.Interfaces;
using PriceCalculator.Core.Models;

namespace PriceCalculator.Core.Services
{
    public class UserDiscountService : IUserDiscountService
    {
        // In-memory storage for demo purposes
        // In a real application, this would connect to a database or external service
        private readonly Dictionary<string, decimal> _userDiscounts;
        private readonly Dictionary<string, List<string>> _userEligibleCategories;

        public UserDiscountService()
        {
            // Initialize with sample discount data
            _userDiscounts = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase)
            {
                { "user1", 0.10m }, // 10% discount
                { "user2", 0.15m }, // 15% discount
                { "user3", 0.05m }, // 5% discount
                { "premiumuser", 0.20m }, // 20% discount
                { "vipuser", 0.25m } // 25% discount
            };

            // Define which categories users are eligible for discounts
            _userEligibleCategories = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "user1", new List<string> { "Electronics", "Books" } },
                { "user2", new List<string> { "Electronics", "Clothing" } },
                { "user3", new List<string> { "Books" } },
                { "premiumuser", new List<string> { "Electronics", "Books", "Clothing", "Home & Garden" } },
                { "vipuser", new List<string> { "Electronics", "Books", "Clothing", "Home & Garden" } }
            };
        }

        /// <summary>
        /// Gets the discount rate for a specific user
        /// </summary>
        /// <param name="userId">The user ID to get discount for</param>
        /// <returns>The discount rate (0.0 to 1.0), or 0 if user has no discount</returns>
        public decimal GetUserDiscount(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return 0;

            return _userDiscounts.TryGetValue(userId, out var discount) ? discount : 0;
        }

        /// <summary>
        /// Checks if a user is eligible for discount on a specific product
        /// </summary>
        /// <param name="userId">The user ID to check</param>
        /// <param name="product">The product to check eligibility for</param>
        /// <returns>True if the user is eligible for discount on this product, false otherwise</returns>
        public bool IsEligibleForDiscount(string userId, Product product)
        {
            if (string.IsNullOrWhiteSpace(userId) || product == null)
                return false;

            // Check if user has any discount at all
            if (!_userDiscounts.ContainsKey(userId))
                return false;

            // Check if user is eligible for discount on this product category
            if (_userEligibleCategories.TryGetValue(userId, out var eligibleCategories))
            {
                return eligibleCategories.Any(category => 
                    string.Equals(category, product.Category, StringComparison.OrdinalIgnoreCase));
            }

            return false;
        }
    }
}