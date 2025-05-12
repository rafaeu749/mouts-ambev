using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Sale entity class.
/// Tests cover status changes, value calculations, and validation scenarios.
/// </summary>
public class SaleTests
{
    /// <summary>
    /// Tests that when a sale is activated, its status changes to Active.
    /// </summary>
    [Fact(DisplayName = "Sale status should change to Active when activated")]
    public void Given_NewSale_When_Activated_Then_StatusShouldBeActive()
    {
        // Arrange
        var sale = new Sale { Status = SaleStatus.Cancelled };

        // Act
        sale.Activate();

        // Assert
        Assert.Equal(SaleStatus.Active, sale.Status);
    }

    /// <summary>
    /// Tests that when a sale is cancelled, its status changes to Cancelled.
    /// </summary>
    [Fact(DisplayName = "Sale status should change to Cancelled when cancelled")]
    public void Given_ActiveSale_When_Cancelled_Then_StatusShouldBeCancelled()
    {
        // Arrange
        var sale = new Sale { Status = SaleStatus.Active };

        // Act
        sale.Cancel();

        // Assert
        Assert.Equal(SaleStatus.Cancelled, sale.Status);
    }

    /// <summary>
    /// Tests that validation passes when all sale properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid sale data")]
    public void Given_ValidSaleData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        var result = sale.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }


    /// <summary>
    /// Tests that validation fails when sale properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid sale data")]
    public void Given_InvalidSaleData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var sale = new Sale
        {
            // Missing required Customer and Branch
            Items = new List<SaleItem>(),
            Status = (SaleStatus)999 // Invalid status
        };

        // Act
        var result = sale.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }


    /// <summary>
    /// Tests that the total value is calculated correctly with no discounts.
    /// </summary>
    [Fact(DisplayName = "Total value should be calculated correctly with no discounts")]
    public void Given_SaleWithItems_When_CalculatingValues_Then_TotalShouldBeSumOfItems()
    {
        // Arrange
        var sale = SaleTestData.GenerateSaleWithItems(3, 10.0m, 2); // 3 items, R$10.00 each, quantity 2

        // Act
        sale.CalculateValues();

        // Assert
        Assert.Equal(60.0m, sale.TotalValue); // 3 items * R$10.00 * 2 = R$60.00
    }

    /// <summary>
    /// Tests that the correct discount is applied when quantity is between 4 and 9.
    /// </summary>
    [Fact(DisplayName = "10% discount should be applied when quantity is between 4 and 9")]
    public void Given_SaleWith5Items_When_CalculatingValues_Then_Apply10PercentDiscount()
    {
        // Arrange
        var sale = SaleTestData.GenerateSaleWithItems(1, 10.0m, 5); // 1 item, R$10.00 each, quantity 5

        // Act
        sale.CalculateValues();
        var item = sale.Items.First();

        // Assert
        var expectedTotal = 50.0m; // 5 * 10.00 = 50.00
        var expectedDiscount = 5.0m; // 10% of 50.00 = 5.00
        var expectedFinalPrice = 45.0m; // 50.00 - 5.00 = 45.00

        Assert.Equal(expectedDiscount, item.Discount);
        Assert.Equal(expectedFinalPrice, item.TotalPrice);
        Assert.Equal(expectedFinalPrice, sale.TotalValue);
    }

    /// <summary>
    /// Tests that the correct discount is applied when quantity is 10 or more.
    /// </summary>
    [Fact(DisplayName = "20% discount should be applied when quantity is 10 or more")]
    public void Given_SaleWith10Items_When_CalculatingValues_Then_Apply20PercentDiscount()
    {
        // Arrange
        var sale = SaleTestData.GenerateSaleWithItems(1, 10.0m, 10); // 1 item, R$10.00 each, quantity 10

        // Act
        sale.CalculateValues();
        var item = sale.Items.First();

        // Assert
        var expectedTotal = 100.0m; // 10 * 10.00 = 100.00
        var expectedDiscount = 20.0m; // 20% of 100.00 = 20.00
        var expectedFinalPrice = 80.0m; // 100.00 - 20.00 = 80.00

        Assert.Equal(expectedDiscount, item.Discount);
        Assert.Equal(expectedFinalPrice, item.TotalPrice);
        Assert.Equal(expectedFinalPrice, sale.TotalValue);
    }

    /// <summary>
    /// Tests that no discount is applied when quantity is less than 4.
    /// </summary>
    [Fact(DisplayName = "No discount should be applied when quantity is less than 4")]
    public void Given_SaleWith3Items_When_CalculatingValues_Then_NoDiscountShouldBeApplied()
    {
        // Arrange
        var sale = SaleTestData.GenerateSaleWithItems(1, 10.0m, 3); // 1 item, R$10.00 each, quantity 3

        // Act
        sale.CalculateValues();
        var item = sale.Items.First();

        // Assert
        var expectedTotal = 30.0m; // 3 * 10.00 = 30.00
        var expectedDiscount = 0m; // No discount
        var expectedFinalPrice = 30.0m; // 30.00 - 0 = 30.00

        Assert.Equal(expectedDiscount, item.Discount);
        Assert.Equal(expectedFinalPrice, item.TotalPrice);
        Assert.Equal(expectedFinalPrice, sale.TotalValue);
    }
}
