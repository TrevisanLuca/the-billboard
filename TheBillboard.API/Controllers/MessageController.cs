namespace TheBillboard.API.Controllers;

using Abstract;
using Bogus;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageRepository _messageRepository;

    public MessageController(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        //prende i message await _messageRepository.GetAllAsync()
        //per ogni message creai un messageDTO 
        return Ok(await _messageRepository.GetAllAsync());
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var message = await _messageRepository.GetByIdAsync(id);

            return message is not null
                ? Ok(message)
                : NotFound();    
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}