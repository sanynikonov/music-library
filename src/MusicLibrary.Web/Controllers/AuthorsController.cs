using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Business.Authors;
using MusicLibrary.Business.Interfaces;
using MusicLibrary.Business.Models;
using MusicLibrary.Web.Extensions;

namespace MusicLibrary.Web.Controllers;

[Route("api/authors")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _service;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthorsController(IAuthorService service, IMediator mediator, IMapper mapper)
    {
        _service = service;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResponse<AuthorItem>>> GetAll([FromQuery] SearchFilterModel filter, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(_mapper.Map<ListAuthorsQuery>(filter), cancellationToken);
        return response.ToActionResult(_mapper);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorModel>> GetById([FromRoute] int id)
    {
        var author = await _service.GetAuthorAsync(id);
        return Ok(author);
    }
}