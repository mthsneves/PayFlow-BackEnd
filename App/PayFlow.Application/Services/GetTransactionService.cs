using PayFlow.Application.Dtos;
using PayFlow.Application.Interfaces;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interface;

namespace PayFlow.Application.Services;

public class GetTransactionService : IGetTransactionService
{
    private readonly ITransactionRepository _repository;

    public GetTransactionService(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<TransactionResponseDto> GetById(Guid id)
    {
        var transaction = await _repository.GetByIdAsync(id);
        if(transaction is null)
            throw new KeyNotFoundException($"Transação com Id {id} não encontrado");
        
        return new TransactionResponseDto(transaction);
    }
    
}