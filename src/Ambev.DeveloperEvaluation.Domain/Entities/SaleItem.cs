using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem
{
    public int Id { get; set; }
    public int SaleNumber { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

    public int Quantity { get; set; }
    public decimal UnitaryPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }
}