using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

public class GetSalesRequestValidator : AbstractValidator<GetSalesRequest>
{
    public GetSalesRequestValidator()
    {
        RuleFor(x => x.Page)
            .NotEmpty()
            .WithMessage("Page is required");

        RuleFor(x => x.Total)
            .NotEmpty()
            .WithMessage("Total is required")
            .InclusiveBetween(1, 10)
            .WithMessage("Total must be between 1 and 10");            
    }
}
