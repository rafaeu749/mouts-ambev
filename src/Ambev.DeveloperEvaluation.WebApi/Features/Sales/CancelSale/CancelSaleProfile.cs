using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;

public class CancelSaleProfile : Profile
{
    public CancelSaleProfile()
    {
        CreateMap<int, Application.Sales.CancelSale.CancelSaleCommand>()
            .ConstructUsing(number => new Application.Sales.CancelSale.CancelSaleCommand(number));
    }
}
