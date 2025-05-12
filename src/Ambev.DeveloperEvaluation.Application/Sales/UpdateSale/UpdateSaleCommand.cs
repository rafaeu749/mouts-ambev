using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    public int Number { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

    public int CustomerId { get; set; }

    public decimal TotalValue { get; set; } = 0;

    public int BranchId { get; set; }

    public ICollection<SaleItem> Items { get; set; }

    public SaleStatus Status { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new UpdateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}