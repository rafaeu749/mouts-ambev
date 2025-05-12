using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public record GetSaleCommand : IRequest<GetSaleResult>
{
    public int Number { get; }

    public GetSaleCommand(int number)
    {
        Number = number;
    }
}
