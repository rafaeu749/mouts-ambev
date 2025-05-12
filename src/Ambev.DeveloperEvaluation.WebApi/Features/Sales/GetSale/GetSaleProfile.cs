using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<int, Application.Sales.GetSale.GetSaleCommand>()
            .ConstructUsing(number => new Application.Sales.GetSale.GetSaleCommand(number));
        CreateMap<GetSaleResult, GetSaleResponse>();
    }
}
