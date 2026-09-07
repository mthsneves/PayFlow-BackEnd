using Moq;
using PayFlow.Application.Dtos;
using PayFlow.Application.Services;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interface;
using Xunit;

namespace PayFlow.Application.Tests;

public class CreateTransactionServiceTests
{
    [Fact]
    public async Task CreateTransactionAsync_AmountIsZero_ThrowsArgumentException()
    {
        Mock<ITransactionRepository> mock = new Mock<ITransactionRepository>();
        CreateTransactionService service = new CreateTransactionService(mock.Object);
        var transactionDto = new TransactionRequestDto();
        transactionDto.Amount = 0;

        await Assert.ThrowsAsync<ArgumentException>(()
            => service.CreateTransactionAsync(transactionDto));

        mock.Verify(x => x.AddAsync(It.IsAny<Transaction>()), Times.Never);
    }

    [Fact]
    public async Task CreateTransactionAsync_ValidRequest_ReturnsTransactionAndSavesIt()
    {
        Mock<ITransactionRepository> mock = new Mock<ITransactionRepository>();
        CreateTransactionService service = new CreateTransactionService(mock.Object);
        var transactionDto = new TransactionRequestDto();
        transactionDto.Amount = 1;

        var result = await service.CreateTransactionAsync(transactionDto);

        Assert.NotNull(transactionDto);
        Assert.Equal(transactionDto.Amount, result.Amount);
        mock.Verify(x => x.AddAsync(It.IsAny<Transaction>()), Times.Once);
    }
}