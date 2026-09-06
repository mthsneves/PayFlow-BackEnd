namespace PayFlow.Domain.Enums;

public enum PaymentMethod
{
    Money = 1,
    Pix = 2,
    DebitCard = 3,
    CreditCard = 4,
    BankSlip = 5,
    DigitalWallet = 6,
    InternalBalance = 7
}