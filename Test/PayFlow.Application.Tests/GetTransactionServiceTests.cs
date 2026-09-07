using Moq;
using PayFlow.Application.Dtos;
using PayFlow.Application.Services;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interface;
using Xunit;

namespace PayFlow.Application.Tests;

public class GetTransactionServiceTests
{
    [Fact]
    public async Task GetById_WhenTransactionExists_ReturnsTransactionResponseDto()
    {
        Mock<ITransactionRepository> mock = new Mock<ITransactionRepository>();
        GetTransactionService service = new GetTransactionService(mock.Object);

        var id = Guid.NewGuid();
        var transactionFake = new Transaction
        {
            Id = id,
            Amount = 100,
            UserId = Guid.NewGuid()
        };

        mock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(transactionFake);
        var result = await service.GetById(id);

        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
    }

    [Fact]
    public async Task GetById_WhenTransactionDoesNotExist_ThrowsKeyNotFoundException()
    {
        Mock<ITransactionRepository> mock = new Mock<ITransactionRepository>();
        GetTransactionService service = new GetTransactionService(mock.Object);
        
        var id = Guid.NewGuid();
        
        mock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync((Transaction?)null);
    
        
        await Assert.ThrowsAsync<KeyNotFoundException>(()
            => service.GetById(id));
      
    }
}