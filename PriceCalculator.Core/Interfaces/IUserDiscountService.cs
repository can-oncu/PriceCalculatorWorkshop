using PriceCalculator.Core.Models;

namespace PriceCalculator.Core.Interfaces
{
    public interface IUserDiscountService
    {
        decimal GetUserDiscount(string userId);
        bool IsEligibleForDiscount(string userId, Product product);
    }
}