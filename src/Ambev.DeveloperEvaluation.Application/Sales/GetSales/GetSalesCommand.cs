using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public record GetSalesCommand : IRequest<List<GetSaleResult>>
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? BranchId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public GetSalesCommand(DateTime? startDate, DateTime? endDate, Guid? customerId, Guid? branchId, int pageNumber, int pageSize)
    {
        StartDate = startDate;
        EndDate = endDate;
        CustomerId = customerId;
        BranchId = branchId;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
