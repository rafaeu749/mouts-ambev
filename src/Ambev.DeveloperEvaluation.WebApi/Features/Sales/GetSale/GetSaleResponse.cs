using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleResponse
{
    public DateTime Date { get; set; }

    public virtual required Customer Customer { get; set; }

    public decimal TotalValue { get; set; } = 0;

    public virtual required Branch Branch { get; set; }

    public virtual required ICollection<SaleItem> Items { get; set; }

    public SaleStatus Status { get; set; }
}
