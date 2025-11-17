using System;

namespace PriceCalculator.Core
{
    public static class ValidationHelper
    {
        // SKUs must be 8 characters and alphanumeric
        public static bool IsValidSku(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku) || sku.Length != 8)
            {
                return false;
            }
            // Simple check for alphanumeric
            foreach (char c in sku)
            {
                if (!char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }
    }
}
