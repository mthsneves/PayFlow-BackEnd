using PayFlow.Application.Dtos;

namespace PayFlow.Application.Interfaces;

public interface ICreateTransactionService
{
    Task<TransactionResponseDto> CreateTransactionAsync(TransactionRequestDto transactionRequestDto);
}