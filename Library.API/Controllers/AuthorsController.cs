using Library.API.Models;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.API.Helpers;
using Library.API.Entities;
using AutoMapper;

namespace Library.API.Controllers
{
    [Route("api/authors")]
    public class AuthorsController : Controller
    {
        private ILibraryRepository _libraryRepository;

        public AuthorsController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _libraryRepository.GetAuthors();
            // Map entities to dto models
            var authors = Mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo);
            // return new JsonResult(authors); //No status code
            return Ok(authors);
        }

        [HttpGet("{id}", Name="GetAuthor")]
        // Get single resource 
        // http://localhost:5000/api/authors/<id>
        public IActionResult GetAuthor(Guid id)
        {
            var authorFromRepo = _libraryRepository.GetAuthor(id);

            if (authorFromRepo == null)
            {
                return NotFound(); // 404 
            }

            var author = Mapper.Map<AuthorDto>(authorFromRepo);
            return Ok(author);
        }

        //[FormBody] Deserialize form body to dto
        [HttpPostAttribute()]
        public IActionResult CreateAuthor([FromBodyAttribute]AuthorForCreationDto author)
        {
            if(author == null)
            {
                return BadRequest();
            }
            var authorEntity = Mapper.Map<Author>(author);
            _libraryRepository.AddAuthor(authorEntity);
            if (!_libraryRepository.Save())
            {
                // Use global error handler
                throw new Exception("Creating an author failed on save.");
            }
            var authorToReturn = Mapper.Map<AuthorDto>(authorEntity);
            //return code 201: Created
            return CreatedAtRoute("GetAuthor", new {id= authorToReturn.Id}, authorToReturn);
        }
    }
}
