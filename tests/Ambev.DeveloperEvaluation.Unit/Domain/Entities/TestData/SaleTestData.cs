using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data for Sale entities.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleTestData
{
    private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
        .RuleFor(s => s.Date, f => f.Date.Recent())
        .RuleFor(s => s.Status, f => f.PickRandom<SaleStatus>())
        .RuleFor(s => s.TotalValue, 0);

    private static readonly Faker<Customer> CustomerFaker = new Faker<Customer>()
        .RuleFor(c => c.Id, f => f.Random.Int(1, 1000))
        .RuleFor(c => c.Name, f => f.Person.FullName);

    private static readonly Faker<Branch> BranchFaker = new Faker<Branch>()
        .RuleFor(b => b.Id, f => f.Random.Int(1, 1000))
        .RuleFor(b => b.Name, f => f.Company.CompanyName());

    private static readonly Faker<SaleItem> SaleItemFaker = new Faker<SaleItem>()
        .RuleFor(i => i.ProductId, f => f.Random.Int(1, 1000))
        .RuleFor(i => i.Quantity, f => f.Random.Int(1, 20))
        .RuleFor(i => i.UnitaryPrice, f => f.Finance.Amount(1, 100, 2))
        .RuleFor(i => i.TotalPrice, 0)
        .RuleFor(i => i.Discount, 0);

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated sale will have all required properties populated with valid values.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static Sale GenerateValidSale()
    {
        var sale = SaleFaker.Generate();
        sale.Customer = CustomerFaker.Generate();
        sale.Branch = BranchFaker.Generate();
        sale.Items = GenerateSaleItems(1, 10.0m, 2); // Default: 1 item, R$10.00 each, quantity 2
        
        sale.CalculateValues();
        return sale;
    }

    /// <summary>
    /// Generates a sale with the specified number of items, unitary price, and quantity per item.
    /// </summary>
    /// <param name="itemCount">Number of different items in the sale.</param>
    /// <param name="unitaryPrice">Price per unit for each item.</param>
    /// <param name="quantityPerItem">Quantity for each item.</param>
    /// <returns>A list of sale items.</returns>
    public static ICollection<SaleItem> GenerateSaleItems(int itemCount, decimal unitaryPrice, int quantityPerItem)
    {
        var items = new List<SaleItem>();
        
        for (int i = 0; i < itemCount; i++)
        {
            var item = SaleItemFaker.Generate();
            item.UnitaryPrice = unitaryPrice;
            item.Quantity = quantityPerItem;
            item.TotalPrice = unitaryPrice * quantityPerItem;
            items.Add(item);
        }
        
        return items;
    }

    /// <summary>
    /// Generates a sale with the specified number of items, unitary price, and quantity per item.
    /// </summary>
    /// <param name="itemCount">Number of different items in the sale.</param>
    /// <param name="unitaryPrice">Price per unit for each item.</param>
    /// <param name="quantityPerItem">Quantity for each item.</param>
    /// <returns>A sale with the specified items.</returns>
    public static Sale GenerateSaleWithItems(int itemCount, decimal unitaryPrice, int quantityPerItem)
    {
        var sale = GenerateValidSale();
        sale.Items = GenerateSaleItems(itemCount, unitaryPrice, quantityPerItem);
        sale.CalculateValues();
        return sale;
    }
}
