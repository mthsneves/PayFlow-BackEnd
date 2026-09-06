using PayFlow.Application.Dtos;
using PayFlow.Application.Interfaces;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Enums;
using PayFlow.Domain.Interface;

namespace PayFlow.Application.Services;

public class CreateTransactionService : ICreateTransactionService
{
    private readonly ITransactionRepository _repository;

    public CreateTransactionService(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<TransactionResponseDto> CreateTransactionAsync(TransactionRequestDto transactionRequestDto)
    {
        if (transactionRequestDto.Amount <= 0)
            throw new ArgumentException("Valor deve ser maior que zero");

        var transaction = new Transaction()
        {
            Id = Guid.NewGuid(),
            TransactionStatus = TransactionStatus.Created,
            UserId = transactionRequestDto.UserId,
            Amount = transactionRequestDto.Amount,
            PaymentMethod = transactionRequestDto.PaymentMethod,
            CreatedDate = DateTime.UtcNow,
        };
        
         await _repository.AddAsync(transaction);
         return new TransactionResponseDto(transaction);
    }
    
}