namespace TheBillboard.Controllers;

using Abstract;
using Microsoft.AspNetCore.Mvc;
using Models;
using ViewModels;

public class MessagesController : Controller
{
    private readonly IAuthorGateway _authorGateway;
    private readonly ILogger<MessagesController> _logger;
    private readonly IMessageGateway _messageGateway;

    public MessagesController(IMessageGateway messageGateway, ILogger<MessagesController> logger, IAuthorGateway authorGateway)
    {
        _logger = logger;
        _messageGateway = messageGateway;
        _authorGateway = authorGateway;
    }

    public IActionResult Index()
    {
        var messages = _messageGateway.GetAll();
        var authors = _authorGateway.GetAll();

        var createViewModel = new MessageCreationViewModel(new Message(), authors);
        var indexModel = new MessagesIndexViewModel(createViewModel, messages);
        return View(indexModel);
    }

    [HttpGet]
    public async Task<IActionResult> CreateAsync(int? id)
    {
        var message = id is not null ? await _messageGateway.GetById((int) id) : new Message();

        if (message is null) return View("Error");

        var viewModel = new MessageCreationViewModel(message, _authorGateway.GetAll());
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(Message message)
    {
        if (!ModelState.IsValid) return View(new MessageCreationViewModel(message, _authorGateway.GetAll()));

        if (message.Id == default)
            await _messageGateway.Create(message);
        else
            await _messageGateway.Update(message);

        _logger.LogInformation($"Message received: {message.Title}");
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DetailAsync(int id)
    {
        var message = await _messageGateway.GetById(id);
        if (message is null) return View("Error");

        return View(message);
    }

    public async Task<IActionResult> DeleteAsync(int id)
    {
        _ = await _messageGateway.Delete(id);
        return RedirectToAction("Index");
    }
}