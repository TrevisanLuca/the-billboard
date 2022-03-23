namespace TheBillboard.API.Controllers;

using Abstract;
using Bogus;
using Domain;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAll()
    {
        return Ok(_messageRepository.GetAll());
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var message = _messageRepository.GetById(id);

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