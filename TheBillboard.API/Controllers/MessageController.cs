namespace TheBillboard.API.Controllers;

using Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheBillboard.API.Dtos;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageRepository _messageRepository;
    public MessageController(IMessageRepository messageRepository) => _messageRepository = messageRepository;

    [HttpGet]
    public IActionResult GetAllAsync() => Ok(_messageRepository.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (id <= 0)
            return NotFound();

        try
        {
            var message = await _messageRepository.GetByIdAsync(id);

            return message is not null
                ? Ok(message)
                : NotFound();
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(MessageForCreateDto message) 
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var newMessageId = await _messageRepository.CreateAsync(message);

            return newMessageId is not null
                ? Created($"{this.Request.Scheme}://{this.Request.Host}{this.Request.Path}/{newMessageId}", newMessageId)
                : NotFound();
        }
        catch (Exception e)
        {
            return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (id <= 0)
            return NotFound();

        try
        {
            var deletedMessageId = await _messageRepository.DeleteAsync(id);

            return deletedMessageId > 0
                ? Ok($"{this.Request.Scheme}://{this.Request.Host}{this.Request.Path}")
                : Problem(statusCode: StatusCodes.Status500InternalServerError);
        }
        catch (Exception e)
        {
            return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(MessageForUpdateDto message)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var updatedMessageId = await _messageRepository.UpdateAsync(message);

            return updatedMessageId > 0
                ? Ok(new { Uri = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.Path}" + updatedMessageId, Value = updatedMessageId })
                : Problem(statusCode: StatusCodes.Status500InternalServerError);
        }
        catch (Exception e)
        {
            return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}