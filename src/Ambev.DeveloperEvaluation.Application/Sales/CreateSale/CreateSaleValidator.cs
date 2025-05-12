using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{   
    public CreateSaleCommandValidator()
    {
        RuleFor(sale => sale.Items).NotNull();
        RuleFor(sale => sale.Status).NotEqual(SaleStatus.Unknown);
    }   
}