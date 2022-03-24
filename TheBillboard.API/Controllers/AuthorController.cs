using Microsoft.AspNetCore.Mvc;
using TheBillboard.API.Abstract;
using TheBillboard.API.Dtos;
using TheBillboard.API.Repositories;

namespace TheBillboard.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _authorRepository.GetAllAsync());
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
                var author = await _authorRepository.GetByIdAsync(id);

                return author is not null
                    ? Ok(author)
                    : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost()]//fa in automatico così //così funziona, bast mettere in parametri in firma
        //committo su github così avete tutti il codice
        //cerco di capire i dto bene per domani, mandami il link per email che l ho chiuso
        // https://github.com/TrevisanLuca/the-billboard
        public async Task<IActionResult> Create(string Name, string Surname, string Email)//(AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var author = await _authorRepository.GetByIdAsync(1);

                return author is not null
                    ? Ok(author)
                    : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
