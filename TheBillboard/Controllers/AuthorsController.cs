namespace TheBillboard.Controllers;

using Abstract;
using Microsoft.AspNetCore.Mvc;
using Models;

public class AuthorsController : Controller
{
    private readonly IAuthorGateway _authorGateway;

    public AuthorsController(IAuthorGateway authorGateway)
    {
        _authorGateway = authorGateway;
    }

    public IActionResult IndexAsync()
    {
        var authors = _authorGateway.GetAll();
        return View(authors);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(Author author)
    {
        if (!ModelState.IsValid) return View();

        await _authorGateway.Create(author);

        //TODO: Error handling (if author creation failed on the database)

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> CreateAsync(int? id)
    {
        return id is not null ? View(await _authorGateway.GetById((int) id)) : View();
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _authorGateway.Delete(id);
        return RedirectToAction("Index");
    }
}