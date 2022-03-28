﻿using Microsoft.AspNetCore.Mvc;
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
        public AuthorController(IAuthorRepository authorRepository) => _authorRepository = authorRepository;

        [HttpGet]
        public IActionResult GetAllAsync() => Ok(_authorRepository.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id <= 0)
                return NotFound();

            try
            {
                var author = await _authorRepository.GetByIdAsync(id);

                return author is not null
                    ? Ok(author)
                    : NotFound();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AuthorForCreateDto author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var newAuthorId = await _authorRepository.CreateAsync(author);

                return newAuthorId is not null
                    ? Created($"{this.Request.Scheme}://{this.Request.Host}{this.Request.Path}/{newAuthorId}", newAuthorId)
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
                var affectedRows = await _authorRepository.DeleteAsync(id);

                return affectedRows > 0
                    ? Ok($"{this.Request.Scheme}://{this.Request.Host}{this.Request.Path}")
                    : affectedRows == 0
                        ? Problem("Author wasn't found", statusCode: StatusCodes.Status500InternalServerError)
                        : Problem("Author is in use", statusCode: StatusCodes.Status500InternalServerError);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(AuthorForUpdateDto author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedAuthorId = await _authorRepository.UpdateAsync(author);

                return updatedAuthorId > 0
                    ? Ok(new { Uri = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.Path}" + updatedAuthorId, Value = updatedAuthorId })
                    : Problem(statusCode: StatusCodes.Status500InternalServerError);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}