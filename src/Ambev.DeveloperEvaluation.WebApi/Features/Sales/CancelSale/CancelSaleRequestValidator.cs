using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;

public class CancelSaleRequestValidator : AbstractValidator<CancelSaleRequest>
{
    public CancelSaleRequestValidator()
    {
        RuleFor(x => x.Number)
            .NotEmpty()
            .WithMessage("Sale number is required");
    }
}
