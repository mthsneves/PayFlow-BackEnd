namespace PayFlow.Domain.Enums;

public enum TransactionStatus
{
    Created = 1,
    Pending = 2,
    Processing = 3,
    Approved = 4,
    Refunded = 5,
    Cancelled = 6,
    Rejected = 7
}