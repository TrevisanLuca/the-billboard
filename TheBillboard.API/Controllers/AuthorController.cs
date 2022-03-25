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
        [HttpPost]        
        public async Task<IActionResult> Create(AuthorInMessageDto newAuthor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdId = await _authorRepository.Create(newAuthor);
                return createdId > 0
                    ? Created($"{this.Request.Scheme}://{this.Request.Host}{this.Request.Path}/{createdId}", "Created author "+ createdId)
                    : NotFound();
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            //todo check if author is already used
            if (await _authorRepository.Delete(id))
                return Ok("Deleted author " + id);
            else
                return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> Update()
        {

        }
    }
}
