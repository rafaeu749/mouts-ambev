using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    public UpdateSaleRequestValidator()
    {
        RuleFor(sale => sale.Number).NotNull();
        RuleFor(sale => sale.Items).NotNull();
        RuleFor(sale => sale.Status).NotEqual(SaleStatus.Unknown);
    }
}