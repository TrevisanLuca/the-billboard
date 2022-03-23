namespace TheBillboard.API.Controllers;

using Abstract;
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
    public IEnumerable<Message> GetAll()
    {
        return _messageRepository.GetAll();
    }
    
    [HttpGet("{id:int}")]
    public Message GetById(int id)
    {
        return _messageRepository.GetById(id);
    }
}