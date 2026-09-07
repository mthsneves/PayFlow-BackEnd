using PayFlow.Domain.Entities;

namespace PayFlow.Domain.Interface;

public interface ITransactionRepository
{
    Task<Transaction> AddAsync(Transaction transaction);
    Task<Transaction?> GetByIdAsync(Guid id);
}