using Microsoft.AspNetCore.Mvc;
using PayFlow.Application.Dtos;
using PayFlow.Application.Interfaces;


namespace PayFlow.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ICreateUserService _createUserService;

    public UserController(ICreateUserService createUserService)
    {
        _createUserService = createUserService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserRequestDto userDto)
    {
        try
        {
            var result = await _createUserService.CreateUserAsync(userDto);
            return StatusCode(201, result);
        }
        catch (ArgumentException e)
        {
           return BadRequest(e.Message);
        }
    }
    
}