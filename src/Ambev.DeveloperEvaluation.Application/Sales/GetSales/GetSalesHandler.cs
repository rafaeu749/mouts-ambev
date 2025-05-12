using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public class GetSalesHandler : IRequestHandler<GetSalesCommand, List<GetSaleResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetSalesHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<List<GetSaleResult>> Handle(GetSalesCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetSalesValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sales = await _saleRepository.GetSalesAsync(
            request.StartDate,
            request.EndDate,
            request.CustomerId,
            request.BranchId,
            request.PageNumber,
            request.PageSize,
            cancellationToken);

        if (sales is null)
            throw new KeyNotFoundException($"No sales found");

        return _mapper.Map<List<GetSaleResult>>(sales);
    }
}
