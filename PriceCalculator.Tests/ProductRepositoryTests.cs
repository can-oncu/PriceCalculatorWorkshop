using Xunit;
using PriceCalculator.Core.Repositories;
using PriceCalculator.Core.Models;
using System.Linq;

namespace PriceCalculator.Tests
{
    public class ProductRepositoryTests
    {
        private readonly ProductRepository _productRepository;

        public ProductRepositoryTests()
        {
            _productRepository = new ProductRepository();
        }

        #region GetProductBySku Tests

        [Fact]
        public void GetProductBySku_WithValidExistingSku_ReturnsCorrectProduct()
        {
            // TODO: Implement unit test for retrieving product by valid existing SKU
            
            // STEPS TO IMPLEMENT:
            // 1. Arrange:
            //    - Set existingSku = "ABC12345" (This SKU exists in ProductRepository sample data)
            
            // 2. Act:
            //    - Call _productRepository.GetProductBySku(existingSku)
            
            // 3. Assert:
            //    - Verify result is not null
            //    - Verify result.Sku equals existingSku
            //    - Verify result.Name equals "Wireless Headphones"
            //    - Verify result.Price equals 99.99m
            //    - Verify result.Category equals "Electronics"
            //    - Verify result.IsActive is true
            
            // LEARNING OBJECTIVES:
            // - Testing repository data retrieval
            // - Understanding sample data structure
            // - Verifying object properties
            // - Working with real implementations vs mocks
        }

        [Fact]
        public void GetProductBySku_WithValidExistingSku_CaseInsensitive_ReturnsCorrectProduct()
        {
            // TODO: Implement unit test for case-insensitive SKU lookup
            
            // STEPS TO IMPLEMENT:
            // 1. Arrange:
            //    - Set existingSkuLowerCase = "abc12345" (lowercase version of existing SKU)
            
            // 2. Act:
            //    - Call _productRepository.GetProductBySku(existingSkuLowerCase)
            
            // 3. Assert:
            //    - Verify result is not null
            //    - Verify result.Sku equals "ABC12345" (original casing should be preserved)
            //    - Verify result.Name equals "Wireless Headphones"
            
            // LEARNING OBJECTIVES:
            // - Testing case-insensitive string comparison
            // - Understanding StringComparison.OrdinalIgnoreCase behavior
            // - Testing search functionality robustness
        }

        [Fact]
        public void GetProductBySku_WithNonExistentSku_ReturnsNull()
        {
            // TODO: Implement unit test for non-existent SKU handling
            
            // STEPS TO IMPLEMENT:
            // 1. Arrange:
            //    - Set nonExistentSku = "XYZ99999" (this SKU does not exist in sample data)
            
            // 2. Act:
            //    - Call _productRepository.GetProductBySku(nonExistentSku)
            
            // 3. Assert:
            //    - Verify result is null
            
            // LEARNING OBJECTIVES:
            // - Testing not-found scenarios
            // - Understanding LINQ FirstOrDefault behavior
            // - Testing negative cases
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("\t")]
        public void GetProductBySku_WithInvalidSku_ReturnsNull(string invalidSku)
        {
            // TODO: Implement theory-based unit test for invalid SKU input handling
            
            // STEPS TO IMPLEMENT:
            // 1. Arrange:
            //    - The invalidSku parameter comes from InlineData (null, empty, whitespace, tab)
            
            // 2. Act:
            //    - Call _productRepository.GetProductBySku(invalidSku)
            
            // 3. Assert:
            //    - Verify result is null
            
            // LEARNING OBJECTIVES:
            // - Testing input validation at repository level
            // - Theory tests for multiple invalid scenarios
            // - Understanding string.IsNullOrWhiteSpace behavior
            // - Defensive programming in data access layer
        }

        [Fact]
        public void GetProductBySku_WithInactiveProduct_ReturnsInactiveProduct()
        {
            // TODO: Implement unit test for retrieving inactive product
            
            // STEPS TO IMPLEMENT:
            // 1. Arrange:
            //    - Set inactiveProductSku = "GHI11111" (This is an inactive product in sample data)
            
            // 2. Act:
            //    - Call _productRepository.GetProductBySku(inactiveProductSku)
            
            // 3. Assert:
            //    - Verify result is not null
            //    - Verify result.Sku equals inactiveProductSku
            //    - Verify result.Name equals "Cotton T-Shirt"
            //    - Verify result.IsActive is false
            
            // NOTE: Repository should return inactive products (filtering happens at service layer)
            
            // LEARNING OBJECTIVES:
            // - Understanding repository vs service layer responsibilities
            // - Testing that repository doesn't filter data
            // - Understanding separation of concerns
        }

        #endregion

        #region GetProducts Tests

        [Fact]
        public void GetProducts_ReturnsOnlyActiveProducts()
        {
            // TODO: Implement unit test to verify only active products are returned
            
            // STEPS TO IMPLEMENT:
            // 1. Arrange:
            //    - No arrangement needed (testing method with no parameters)
            
            // 2. Act:
            //    - Call _productRepository.GetProducts().ToList()
            
            // 3. Assert:
            //    - Verify result is not empty (Assert.NotEmpty)
            //    - Verify all products have IsActive = true (Assert.All(result, product => Assert.True(product.IsActive)))
            //    - Verify count equals 4 (based on sample data, should return 4 active products)
            
            // LEARNING OBJECTIVES:
            // - Testing collection filtering logic
            // - Using Assert.All for collection assertions
            // - Understanding LINQ Where clause behavior
        }

        [Fact]
        public void GetProducts_DoesNotReturnInactiveProducts()
        {
            // TODO: Implement unit test to verify inactive products are excluded
            
            // STEPS TO IMPLEMENT:
            // 1. Arrange:
            //    - No arrangement needed
            
            // 2. Act:
            //    - Call _productRepository.GetProducts().ToList()
            
            // 3. Assert:
            //    - Verify result does not contain product with SKU "GHI11111" (the inactive product)
            //    - Use: Assert.DoesNotContain(result, p => p.Sku == "GHI11111")
            
            // LEARNING OBJECTIVES:
            // - Testing exclusion logic
            // - Using Assert.DoesNotContain for negative assertions
            // - Understanding filtering requirements
        }

        [Fact]
        public void GetProducts_ReturnsExpectedActiveProducts()
        {
            // TODO: Implement unit test to verify specific expected active products are returned
            
            // STEPS TO IMPLEMENT:
            // 1. Arrange:
            //    - Create expectedSkus array: { "ABC12345", "DEF67890", "JKL22222", "MNO33333" }
            
            // 2. Act:
            //    - Call _productRepository.GetProducts().ToList()
            //    - Extract SKUs: actualSkus = result.Select(p => p.Sku).ToArray()
            
            // 3. Assert:
            //    - Verify actualSkus.Length equals expectedSkus.Length
            //    - For each expectedSku, verify it exists in actualSkus using Assert.Contains
            
            // LEARNING OBJECTIVES:
            // - Testing specific data expectations
            // - Working with collections and LINQ projections
            // - Validating data completeness
        }

        [Fact]
        public void GetProducts_ReturnsProductsWithCorrectProperties()
        {
            // TODO: Implement unit test to verify all returned products have valid properties
            
            // STEPS TO IMPLEMENT:
            // 1. Arrange:
            //    - No arrangement needed
            
            // 2. Act:
            //    - Call _productRepository.GetProducts().ToList()
            
            // 3. Assert:
            //    - Use Assert.All(result, product => { ... }) to verify each product has:
            //      * SKU is not null
            //      * Name is not null
            //      * Price > 0
            //      * Category is not null
            //      * IsActive is true
            //      * CreatedDate is not default(DateTime)
            
            // LEARNING OBJECTIVES:
            // - Testing data integrity
            // - Using Assert.All for complex validations
            // - Understanding business rules for valid data
        }

        [Fact]
        public void GetProducts_ReturnsDifferentCategories()
        {
            // TODO: Implement unit test to verify products from multiple categories are returned
            
            // STEPS TO IMPLEMENT:
            // 1. Arrange:
            //    - No arrangement needed
            
            // 2. Act:
            //    - Call _productRepository.GetProducts().ToList()
            //    - Extract categories: categories = result.Select(p => p.Category).Distinct().ToList()
            
            // 3. Assert:
            //    - Verify categories.Count > 1 (should have products from multiple categories)
            //    - Verify specific categories exist:
            //      * Assert.Contains("Electronics", categories)
            //      * Assert.Contains("Books", categories)
            //      * Assert.Contains("Home & Garden", categories)
            
            // LEARNING OBJECTIVES:
            // - Testing data diversity
            // - Using LINQ Distinct() for uniqueness
            // - Validating business data requirements
        }

        #endregion

        #region Integration-like Tests

        [Fact]
        public void ProductRepository_ConsistentDataBetweenMethods()
        {
            // TODO: Implement integration test to verify data consistency between GetProducts and GetProductBySku
            
            // STEPS TO IMPLEMENT:
            // 1. Arrange:
            //    - No arrangement needed
            
            // 2. Act:
            //    - Get all active products: allActiveProducts = _productRepository.GetProducts().ToList()
            
            // 3. Assert:
            //    - For each product in allActiveProducts:
            //      a) Call retrievedProduct = _productRepository.GetProductBySku(product.Sku)
            //      b) Verify retrievedProduct is not null
            //      c) Verify retrievedProduct.Sku equals product.Sku
            //      d) Verify retrievedProduct.Name equals product.Name
            //      e) Verify retrievedProduct.Price equals product.Price
            //      f) Verify retrievedProduct.Category equals product.Category
            //      g) Verify retrievedProduct.IsActive equals product.IsActive
            
            // LEARNING OBJECTIVES:
            // - Testing data consistency across different access methods
            // - Understanding data integrity requirements
            // - Integration testing within a single class
        }

        [Fact]
        public void ProductRepository_SampleDataIntegrity()
        {
            // TODO: Implement test to verify sample data integrity and expected structure
            
            // STEPS TO IMPLEMENT:
            // 1. Arrange:
            //    - No arrangement needed
            
            // 2. Act:
            //    - Get all active products: allActiveProducts = _productRepository.GetProducts().ToList()
            //    - Get specific product: specificProduct = _productRepository.GetProductBySku("ABC12345")
            
            // 3. Assert:
            //    - Verify allActiveProducts.Count equals 4 (expected number of active products)
            //    - Verify specificProduct is not null
            //    - Verify specificProduct.Name equals "Wireless Headphones"
            //    - Verify specificProduct.Category equals "Electronics"
            //    - Verify allActiveProducts does not contain product with SKU "GHI11111"
            //    - Get inactive product: inactiveProduct = _productRepository.GetProductBySku("GHI11111")
            //    - Verify inactiveProduct is not null
            //    - Verify inactiveProduct.IsActive is false
            
            // LEARNING OBJECTIVES:
            // - Testing sample data assumptions
            // - Understanding test data setup
            // - Validating both positive and negative scenarios
            // - Integration testing with known data
        }

        #endregion
    }
}