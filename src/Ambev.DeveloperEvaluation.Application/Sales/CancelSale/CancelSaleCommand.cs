using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public record CancelSaleCommand : IRequest<CancelSaleResponse>
{
    public int Number { get; }

    public CancelSaleCommand(int number)
    {
        Number = number;
    }
}
