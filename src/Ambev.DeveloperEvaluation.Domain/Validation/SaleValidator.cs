using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.Items)
            .NotNull()
            .WithMessage("Items cannot be null")
            
            .Must(items => items?.Count > 0)
            .WithMessage("Sale items cannot be empty");

        RuleFor(sale => sale.Status)
            .NotEqual(SaleStatus.Unknown)
            .WithMessage("Sale status cannot be Unknown.");
    }
}
