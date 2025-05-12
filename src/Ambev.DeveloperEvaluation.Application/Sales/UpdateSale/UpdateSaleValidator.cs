using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
{   
    public UpdateSaleCommandValidator()
    {
        RuleFor(sale => sale.Number).NotNull().NotEmpty();
        RuleFor(sale => sale.Items).NotNull();
        RuleFor(sale => sale.Status).NotEqual(SaleStatus.Unknown);
    }
}