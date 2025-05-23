﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequest
{
    public DateTime Date { get; set; } = DateTime.Now;
    public int CustomerId { get; set; }
    public decimal TotalValue { get; set; } = 0;
    public int BranchId { get; set; }
    public required ICollection<SaleItem> Items { get; set; }
    public SaleStatus Status { get; set; }
}