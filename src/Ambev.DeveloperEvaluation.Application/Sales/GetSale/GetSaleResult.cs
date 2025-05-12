using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleResult
{
    public int Number { get; set; }
    public DateTime Date { get; set; }
    public Customer Customer { get; set; }
    public decimal TotalValue { get; set; } = 0;
    public Branch Branch { get; set; }
    public ICollection<SaleItem> Items { get; set; }
    public SaleStatus Status { get; set; }
}
