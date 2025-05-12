using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleResponse
{
    public int Number { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public required Customer Customer { get; set; }

    public decimal TotalValue { get; set; } = 0;

    public required Branch Branch { get; set; }

    public required ICollection<SaleItem> Items { get; set; }

    public SaleStatus Status { get; set; }
}
