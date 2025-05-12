using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleRepository
{
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);

    Task<Sale?> GetByNumberAsync(int number, CancellationToken cancellationToken = default);
    
    Task<PaginatedList<Sale>> GetSalesAsync(
        DateTime? startDate = null,
        DateTime? endDate = null,
        Guid? customerId = null,
        Guid? branchId = null,
        int pageNumber = 1,
        int pageSize = 20,
        CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);

    Task<bool> CancelAsync(int number, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(int number, CancellationToken cancellationToken = default);
}
