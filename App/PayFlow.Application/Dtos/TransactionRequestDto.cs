using PayFlow.Domain.Enums;

namespace PayFlow.Application.Dtos;

public class TransactionRequestDto
{
    public Guid UserId { get; set; }
    public decimal Amount  { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}