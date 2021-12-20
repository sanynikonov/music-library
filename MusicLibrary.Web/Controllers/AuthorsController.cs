using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Business;

namespace MusicLibrary.Web.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorsController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorListItemModel>>> GetAll([FromQuery] SearchFilterModel filter)
        {
            var authors = await _service.GetAllAuthorsAsync(filter);
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorModel>> GetById([FromRoute] int id)
        {
            var author = await _service.GetAuthorAsync(id);
            return Ok(author);
        }
    }
}
