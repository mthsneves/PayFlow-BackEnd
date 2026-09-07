using PayFlow.Domain.Entities;
using PayFlow.Domain.Enums;
using TransactionStatus = PayFlow.Domain.Enums.TransactionStatus;

namespace PayFlow.Application.Dtos;

public class TransactionResponseDto
{

    public TransactionResponseDto()
    {
        
    }
    public TransactionResponseDto(Transaction transaction)
    {
        Id = transaction.Id;
        UserId = transaction.UserId;
        Amount = transaction.Amount;
        PaymentMethod = transaction.PaymentMethod;
        TransactionStatus = transaction.TransactionStatus;
        CreatedDate = transaction.CreatedDate;
        CompletedAt = transaction.CompletedAt;
    }

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public TransactionStatus TransactionStatus { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? CompletedAt { get; set; }
}