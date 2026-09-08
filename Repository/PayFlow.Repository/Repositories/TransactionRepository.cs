using PayFlow.Domain.Entities;
using PayFlow.Domain.Interface;

namespace PayFlow.Repository.Data.DataConfiguration;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _context;

    public TransactionRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Transaction> AddAsync(Transaction transaction)
    {
        _context.Add(transaction);
        await _context.SaveChangesAsync();
        return transaction;
    }

    public async Task<Transaction?> GetByIdAsync(Guid id)
    {
        var transaction = await _context.FindAsync<Transaction>(id);
        return transaction;
    }
}