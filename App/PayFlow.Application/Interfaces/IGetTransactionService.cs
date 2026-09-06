using PayFlow.Application.Dtos;

namespace PayFlow.Application.Interfaces;

public interface IGetTransactionService
{
    Task<TransactionResponseDto> GetById(Guid id);
}