using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public class GetSalesValidator : AbstractValidator<GetSalesCommand>
{
    public GetSalesValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .WithMessage("Page must be greater than 0");

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 20)
            .WithMessage("Page size must be between 1 and 20");

        RuleFor(x => x)
            .Must(x => !(x.StartDate.HasValue && x.EndDate.HasValue && x.StartDate > x.EndDate))
            .WithMessage("Start date cannot be after end date.");
    }
}
