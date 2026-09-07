using Microsoft.AspNetCore.Mvc;
using PayFlow.Application.Dtos;
using PayFlow.Application.Interfaces;

namespace PayFlow.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
   private readonly ICreateTransactionService _createTransactionService;
   private readonly IGetTransactionService _getTransactionService;


   public TransactionController(ICreateTransactionService createTransactionService , IGetTransactionService getTransactionService)
   {
      _createTransactionService = createTransactionService;
      _getTransactionService = getTransactionService;
   }

   [HttpPost]
   public async Task<IActionResult> CreateTransaction([FromBody] TransactionRequestDto transactionRequestDto)
   {
     try
     {
        var result = await _createTransactionService.CreateTransactionAsync(transactionRequestDto);
        return Ok(result);
     }
     catch (ArgumentException ex)
     {
        return BadRequest(ex.Message);
     }
      
      
   }

   [HttpGet("{id}")]
   public async Task<IActionResult> GetTransactionById(Guid id)
   {
      var transactionId = await _getTransactionService.GetById(id);
      return Ok(transactionId);
   }
   
      
   
   
}